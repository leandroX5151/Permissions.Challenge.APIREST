using System;
using Microsoft.IdentityModel.Tokens;

namespace Permissions.Challenge.Security.Auth
{
    public class TokenAuthOption
    {
        public static string Audience { get; } = "BancorPopAudience";
        public static string Issuer { get; } = "BancorPopIssuer";
        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromDays(7);
        public static string TokenType { get; } = "Bearer";
    }
}
