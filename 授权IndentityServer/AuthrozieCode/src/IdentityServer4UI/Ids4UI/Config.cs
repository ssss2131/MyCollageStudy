// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace Ids4UI
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),//包括用户的姓名，地址，电话，电子邮件...scope
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResources.Email(),
                
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope("api1","My Api")              
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {               
               new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,

                    // 登录后重定向到哪里
                    RedirectUris = { "https://localhost:5099/signin-oidc" },

                    // 注销后重定向到哪里
                    PostLogoutRedirectUris = { "https://localhost:5099/signout-callback-oidc" },
                    
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true, //AllowOfflineAccess属性启用对刷新令牌的支持
                    AccessTokenLifetime = 60, // 60 seconds
                    
                    
                    //添加所允许的服务
                    AllowedScopes = new List<string>
                    {                                           
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1"  //将"API1"从第一个位置放到了最后位置
                        //注释掉了mvc program里面的Clear()方法 
                    }
                }
            };
    }
}