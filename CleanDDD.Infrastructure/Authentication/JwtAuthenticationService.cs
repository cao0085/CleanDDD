using CleanDDD.Application.Shared;
using CleanDDD.Infrastructure.Persistence.BaseDb;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;
using CleanDDD.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace CleanDDD.Infrastructure.Authentication
{
    public class JwtAuthenticationService : IAuthenticationService
    {
        private readonly BaseDbContext _baseDbContext;
        private readonly IOptions<AppSettings> _options;

        public JwtAuthenticationService(BaseDbContext baseDbContext, IOptions<AppSettings> options)
        {
            _baseDbContext = baseDbContext;
            _options = options;
        }

        public async Task<(string accessToken, string refreshToken)> RequestTokenUsingPasswordGrantAsync(string username, string password)
        {
            JwtResponse? jwtResponse = null;

            var authOptions = _options.Value.Authentication;
            var userInfo = await _baseDbContext.UserInfo.FirstOrDefaultAsync(x => x.Name == username);
            if (userInfo == null || !HashHelper.Verify(password, userInfo.PasswordHash))
            {
                throw new ApplicationException("帳號或密碼錯誤");
            }

            if (userInfo != null)
            {
                var token = GenerateToken(userInfo);
                var refreshToken = GenerateRefreshToken();

                userInfo.RefreshToken = refreshToken;
                userInfo.RefreshTokenExpires = DateTime.Now.AddHours(1);
                _baseDbContext.SaveChanges();

                jwtResponse = new JwtResponse(token, refreshToken);
            }

            if (jwtResponse is null || string.IsNullOrEmpty(jwtResponse.AccessToken) || string.IsNullOrEmpty(jwtResponse.RefreshToken))
            {
                throw new ApplicationException("Invalid authentication response received from the server.");
            }

            return (jwtResponse.AccessToken, jwtResponse.RefreshToken);
        }

        public async Task<(string accessToken, string refreshToken)> RefreshAccessTokenAsync(string refreshToken)
        {
            //JwtResponse? jwtResponse = null;

            //var authOptions = _options.Value.Authentication;

            //var tokenHandler = new JwtSecurityTokenHandler();

            //var validationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuer = true,
            //    ValidIssuer = authOptions.Issuer,
            //    ValidateAudience = true,
            //    ValidAudience = authOptions.Audience,
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SecretKey)),
            //    ValidateLifetime = false // 因為是 Refresh Token，允許過期的 Access Token
            //};

            //var principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken securityToken);
            //if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            //    !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            //{
            //    throw new ApplicationException("Invalid refreshToken."); ;
            //}

            //var name = principal.FindFirstValue(ClaimTypes.Name);

            //var userInfo = await _baseDbContext.UserInfo.FirstOrDefaultAsync(x => x.Name == name && x.RefreshToken == refreshToken && x.RefreshTokenExpires <= DateTime.Now);

            //if (userInfo != null)
            //{
            //    var token = GenerateToken(userInfo);
            //    var newRefreshToken = GenerateRefreshToken();

            //    userInfo.RefreshToken = newRefreshToken;
            //    userInfo.RefreshTokenExpires = DateTime.Now.AddHours(1);
            //    _baseDbContext.SaveChanges();

            //    jwtResponse = new JwtResponse(token, newRefreshToken);
            //}

            //if (jwtResponse is null || string.IsNullOrEmpty(jwtResponse.AccessToken) || string.IsNullOrEmpty(jwtResponse.RefreshToken))
            //{
            //    throw new ApplicationException("Invalid response received from OAuth2 server while refreshing the token.");
            //}

            //return (jwtResponse.AccessToken, jwtResponse.RefreshToken);

            // 1. 直接找符合 refreshToken & 未過期的使用者
            var userInfo = await _baseDbContext.UserInfo.FirstOrDefaultAsync(x =>
                x.RefreshToken == refreshToken);            // 尚未過期

            if (userInfo is null)
                throw new ApplicationException("Refresh token 無效或已過期");

            // 2. 產生新 access / refresh token
            var newAccessToken = GenerateToken(userInfo);
            var newRefreshToken = GenerateRefreshToken();

            userInfo.RefreshToken = newRefreshToken;
            userInfo.RefreshTokenExpires = DateTime.Now.AddHours(1);
            await _baseDbContext.SaveChangesAsync();

            return (newAccessToken, newRefreshToken);
        }

        public string GenerateToken(UserInfo user)
        {
            var authOptions = _options.Value.Authentication;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authOptions.SecretKey);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.UserInfoId.ToString()),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64)
            };

            // 加入角色 Claims
            //foreach (var role in user.Roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(authOptions.Expired),
                Issuer = authOptions.Issuer,
                Audience = authOptions.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    public record JwtResponse(
        [property: JsonPropertyName("access_token")] string AccessToken,
        [property: JsonPropertyName("refresh_token")] string RefreshToken
    );

    public static class HashHelper
    {
        public static string ToMd5(string input)
        {
            using var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = md5.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        public static bool Verify(string rawInput, string storedHash)
        {
            return ToMd5(rawInput) == storedHash;
        }
    }

}
