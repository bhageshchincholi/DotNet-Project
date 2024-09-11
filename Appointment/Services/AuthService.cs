using Appointment.Interfaces;
using Appointment.Models;
using Appointment.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Appointment.Services
{
    public class AuthService : IAuthService
    {

        private readonly AppointmentDbContext appointmentDbContext;
        private readonly IConfiguration configuration;

        public AuthService(AppointmentDbContext appointmentDbContext,IConfiguration configuration)
        {
              this.appointmentDbContext = appointmentDbContext;
             this.configuration = configuration;
        }
        User IAuthService .addUser(User user)
        {
            var addedUser = appointmentDbContext.Add(user);
            appointmentDbContext.SaveChanges();
            return addedUser.Entity;

        }

        string IAuthService.Login(LoginRequest loginRequest)
        {
            if (loginRequest.Email != null && loginRequest.Password != null)
            {
                var user = appointmentDbContext.users.SingleOrDefault(
                    s => s.Email == loginRequest.Email && s.Password == loginRequest.Password);

                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()), // Standard claim for user ID
                        new Claim(ClaimTypes.Name, user.Name), // Standard claim for username
                        new Claim(ClaimTypes.Email, user.Email) // Standard claim for email
                    };

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims,
                        expires: DateTime.UtcNow.AddMinutes(120),
                        signingCredentials: credentials);

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return jwtToken;
                }
                else
                {
                    throw new Exception("User is not valid");  
                }
            }
            else
            {
                throw new Exception("Credentials are not valid");
            }
        }
    }
}
