// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Ids4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
                new ApiScope("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "Console AppId",
                    ClientName = "Console App",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    AllowedScopes = { "api1"}
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "mvc client",
                    ClientSecrets = { new Secret("mvc secret".Sha256()) },
    
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "http://localhost:5058/signin-oidc" },
                    //FrontChannelLogoutUri = "http://localhost:5058/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:5058/signout-callback-oidc" },
                    //AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                 /*   AccessTokenLifetime = 60, */// 60 seconds
                    AllowedScopes = {  
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        //IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Profile 
                    }
                },             
            };
    }
}