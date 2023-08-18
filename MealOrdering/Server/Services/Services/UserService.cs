using AutoMapper;
using MealOrdering.Client.Utils;
using MealOrdering.Server.Data.Context;
using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MealOrdering.Server.Services.Services
{
    public class UserService : GenericService<UserDTO>, IUserService
    {
        public IMapper Mapper { get; }
        public MealOrderingDbContext Context { get; }
        IConfiguration _configuration;
        public UserService(IMapper mapper, MealOrderingDbContext context, IConfiguration configuration) : base(mapper, context)
        {
            Mapper = mapper;
            Context = context;
            _configuration = configuration;
        }

        public async Task<string> Login(string email, string password)
        {

            var hashPass = PasswordManager.Encrypt(password, "key", "iv");
            var user = await Context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == hashPass);
            if (user == null)
                throw new Exception("wrong password or email");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            double days = double.Parse(_configuration["JWT:JwtExpireDate"]);
            var expireTime = DateTime.Now.AddDays(days);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,email),
            };
            var securityToken = new JwtSecurityToken(issuer: _configuration["JWT:JwtIssuer"],
                audience: _configuration["JWT:JwtAuidence"],
                claims: claims,
                notBefore: null,
                expires: expireTime,
                signingCredentials: credential);
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }

}
