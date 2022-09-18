using JwtAuthenticationManager.Model;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "68E14C96-E021-41DC-8AB7-50C7E273D07C";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccountList;
        public JwtTokenHandler()
        {
            _userAccountList = new List<UserAccount> {
                new UserAccount { UserName = "admin" , Password = "admin123" , Role = "Administrator" } ,
                new UserAccount{ UserName = "user01", Password = "user01", Role = "User" }
            };
        }
        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
                return null;
            var userAccount = _userAccountList.Where(x => x.UserName == authenticationRequest.UserName && x.Password == authenticationRequest.Password).FirstOrDefault();
            if (userAccount == null) return null;
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenkey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim ( JwtRegisteredClaimNames.Name , authenticationRequest.UserName ) ,
                new Claim ( ClaimTypes.Role , userAccount.Role )
            });
            var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenkey),
            SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return new AuthenticationResponse
            {
                UserName = userAccount.UserName,
                ExpiresIn=(int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JatToken = token
            };
        }
    }
}