using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using Microsoft.IdentityModel.Tokens;
using SessionInterface;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BusinessLogic
{
    [ExcludeFromCodeCoverage]
    public class SessionLogic : ISessionLogic
    {
        private IAdministratorRepository administratorRepository;
        private string secretKey;

        public SessionLogic(IAdministratorRepository administratorRepository)
        {
            this.administratorRepository = administratorRepository;
            this.secretKey = ReadSecretKeyFromFile();
        }

        private string ReadSecretKeyFromFile()
        {
            try
            {
                var sr = new StreamReader("Key.txt");
                var secretKey = sr.ReadLine();
                return secretKey;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return "";
            }
        }

        public bool IsCorrectToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.secretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var adminEmail = jwtToken.Claims.First(x => x.Type == "email").Value;
                var existsAdmin = this.administratorRepository.GetByEmail(adminEmail);
                if (existsAdmin != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public class TokenNotVerified : APIException
        {
            public TokenNotVerified() : base("Not Valid Token", 403)
            { }
        }

        public string GenerateToken(Administrator admin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", admin.Email) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
