using ASP_ANGULAR_API.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using UnitOfWork;

namespace ASP_ANGULAR_API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unitOfWork;
        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public JsonWebToken Post([FromBody]User userLogin)
        {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email, userLogin.Pssword);
            if (user==null)
            {
                throw new UnauthorizedAccessException();
            }
            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480 // minutos de vida del token
            };
            return token;
        }
    }
}