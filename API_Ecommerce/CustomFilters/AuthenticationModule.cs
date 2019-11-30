using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace API_Ecommerce.CustomFilters
{
    public class AuthenticationModule
    {
        private const string communicationKey = "GQDstc21ewfffffffffffFiwDffVvVBrk";
        SecurityKey signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));


        // The Method is used to generate token for user
        public string GenerateTokenForUser(string userName, int userId)
        {


            var signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(signingKey,
               SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            }, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                AppliesToAddress = "http://www.example.com",
                TokenIssuerName = "self",
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Lifetime = new Lifetime(now, now.AddYears(1)),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;

        }

        /// Using the same key used for signing token, user payload is generated back
        public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        {

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudiences = new string[]
                      {
                    "http://www.example.com",
                      },

                ValidIssuers = new string[]
                  {
                      "self",
                  },
                IssuerSigningKey = signingKey
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;

            try
            {

                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return null;

            }

            return validatedToken as JwtSecurityToken;

        }

        public JWTAuthenticationIdentity PopulateUserIdentity(JwtSecurityToken userPayloadToken)
        {
            string name = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "unique_name").Value;
            string userId = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "nameid").Value;
            return new JWTAuthenticationIdentity(name) { UserId = Convert.ToInt32(userId), UserName = name };

        }
    }

    public class JWTAuthenticationIdentity : GenericIdentity
    {

        public string UserName { get; set; }
        public int UserId { get; set; }

        public JWTAuthenticationIdentity(string userName)
            : base(userName)
        {
            UserName = userName;
        }


    }

    public class ResponseDTO
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}