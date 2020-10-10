using ASP_ANGULAR_API.Authentication;
using ASP_ANGULAR_API.GlobalErrorHandling;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemsBusinnessLogic.Implementations;
using SystemsBusinnessLogic.Interfaces;
using UnitOfWork;

namespace ASP_ANGULAR_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISupplierLogic, SupplierLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ITokenLogic, TokenLogic>();
            services.AddCors(c =>{
		    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
			});
            services.AddSingleton<IUnitOfWork>(option => new DAUnitOfWork(
                Configuration.GetConnectionString("ASP_ANGULAR")));

            var tokenProvider = new JwtProvider("issuer", "audience", "bearer");
            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();

                });
            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                                     .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                                     .RequireAuthenticatedUser()
                                     .Build();
            });
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

	        app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
            app.UseRouting();
	    
	        app.UseAuthentication();

            app.UseAuthorization();

            app.ConfigureExceptionHandler();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
