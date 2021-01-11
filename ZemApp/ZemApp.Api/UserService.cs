using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZemApp.Api.Model;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Services;

namespace ZemApp.Api
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthModel model);

        User GetById(string id);
    }

    public class UserService : IUserService
    {
        public IConfiguration _configuration;
        private IUserAppService _userAppService;
        private List<User> _users = new List<User>();

        public UserService(IConfiguration config, IUserAppService userAppService)
        {
            _configuration = config;
            _userAppService = userAppService;
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(string id)
        {
            return _userAppService.GetUserById(id);
        }

        public AuthenticateResponse Authenticate(AuthModel model)
        {
            var user = _userAppService.ValidateUserByCredentials(model.Username, model.Password);
            if (user == null) return null;

            var token = generateJwtToken(user);
            _users.Add(user);
            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()),
                            new Claim(ClaimTypes.Role,user.Role.Rol_Name.ToString()),
                            new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                            new Claim(ClaimTypes.Actor,user.Username),
                            new Claim(ClaimTypes.NameIdentifier,user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}