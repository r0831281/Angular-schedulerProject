using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StaffSchedulerApi.Data;
using StaffSchedulerApi.Helpers;
using StaffSchedulerApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace StaffSchedulerApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appsettings;
        private readonly ScheduleContext _context;

        public UserService(IOptions<AppSettings> appsettings, ScheduleContext scheduleContext)
        {
            _appsettings = appsettings.Value;
            _context = scheduleContext;

        }
        public User Authenticate(string username, string password)
        {
            var user = _context.users.Include(u => u.Role).SingleOrDefault(u => u.UserName == username && u.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("Username", user.UserName),
                    new Claim("Role", user.Role.RoleName)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;

        }
    }
}

