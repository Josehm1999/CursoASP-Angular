using ASP_ANGULAR_API.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using SystemsBusinnessLogic.Interfaces;

namespace ASP_ANGULAR_API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenProvider _tokenProvider;
        private ITokenLogic _logic;
        public TokenController(ITokenProvider tokenProvider, ITokenLogic logic)
        {
            _tokenProvider = tokenProvider;
            _logic = logic;
        }
        [HttpPost]
        public JsonWebToken Post([FromBody]User userLogin)
        {
            var user = _logic.ValidateUser(userLogin.Email, userLogin.Password);
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