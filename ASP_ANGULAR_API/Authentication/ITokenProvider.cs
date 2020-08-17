using Microsoft.IdentityModel.Tokens;
using Models;
using System;

namespace ASP_ANGULAR_API.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expires);
        TokenValidationParameters GetValidationParameters(); 
    }
}
