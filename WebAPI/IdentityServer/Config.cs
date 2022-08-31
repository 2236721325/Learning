using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
           new List<ApiScope>
           {
                new ApiScope("thisApi", "thisApi")
           };


        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",

                // 没有交互式用户，使用 clientid/secret 进行身份验证
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // 用于身份验证的密钥
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                // 客户端有权访问的范围
                AllowedScopes = { "thisApi" }
            }
    };

    }
}
