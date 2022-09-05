// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
       //授权服务器里面存储的资源 例如用户信息 openId 手机号码 地址
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };
        //注册在授权服务器 受保护的资源
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope("api1","My API")
            };
        //注册在授权服务其中的客户 例如一些应用程序
        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
                new Client
                {         
                    IdentityTokenLifetime = 5,  

                    ClientId ="client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // 用于身份验证的密钥
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // 客户端有权访问的范围
                    AllowedScopes = { "api1" }
                }

            };
    }
}