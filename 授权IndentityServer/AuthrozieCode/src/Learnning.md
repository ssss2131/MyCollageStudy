###AuthorizeCode

    Oauth2.0对其定义:
       当应用程序为访问令牌交换授权码时，使用授权码授予。用户通过重定向URL返回应用程序后，应用程序将从URL获取授权代码，并使用它请求访问令牌。
       将向令牌端点发出此请求。


###授权服务器

    一、环境准备
        1、在解决方案中添加模板 dotnet new -i IdentityServer4.Templates :不加的话无法自动添加相关的nuget
        2、创建一个Ids4空模板 dotnet new is4empty -n IdentityServer4UI
        3、在IdentityServer4UI.csproj 目录下 添加QuickStart获取页面的控制 dotnet new is4ui 
        4、将startup文件夹下与MVC有关的注释取消 确保Isd4项目添加mvc必要的服务与中间件
    二、注册客户端与用户
        1、注册客户端
            new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    // 登录后重定向到哪里
                    RedirectUris = { "https://localhost:5099/signin-oidc" },

                    // 注销后重定向到哪里
                    PostLogoutRedirectUris = { "https://localhost:5099/signout-callback-oidc" },
                    //所允许访问的资源 IdentityServerConstants 位于IdentityServer4命名空间下 
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            2、注册用户
                使用内存下的TestUser TestUser位于Ids项目QuickStart文件夹下 里面默认注册了两个用户
                在Ids4项目下的startup文件中的注册IdentityServer()方法下添加 .AddTestUsers(TestUsers.Users);
            3、设置允许第三方可以访问的资源
                 public static IEnumerable<IdentityResource> IdentityResources =>
                    new IdentityResource[]
                    { 
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile()//包括用户的姓名，地址，电话，电子邮件...scope 注:因为使用的code授权的形式
                        允许第三方代表用户访问用户在授权服务器上的资源
                    };
            4、扩展如果需要更多的或许声明 需要在IdentityResource中添加 再去注册的Client中添加scope 
            **注意**要添加  AlwaysIncludeUserClaimsInIdToken = true, 不然在发现文档里面的claims_supported有Email,Phone..但是Client
            得不到这些声明           
###被保护的资源
    1、在Ids4服务器中注册api的名字
    2、为mvc客户端添加scope--api1
    3、在api1中使用oidc设置登录 登出跳转的地址 为特定或者全局添加Authorize保护起来。


###注册的客户端
        一、环境准备 
            1、下载oidcnuget dotnet add package Microsoft.AspNetCore.Authentication.OpenIdConnect

            这里使用OIDC协议 Oidc可以代表用户访问用户在授权服务器中的资源 而使用ClientCredential无法代表用户访问到用户在授权服务器上的资源

        二、配置服务,中间件  
            using System.IdentityModel.Tokens.Jwt;

            builder.Services.AddAuthentication((options)=>{
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme="oidc";//鉴权方式oidc
            }).AddCookie("Cookies")
            .AddOpenIdConnect("oidc",(options)=>{
                options.Authority = "https://localhost:5001";//授权机构
                options.ClientId = "mvc";//注册在服务器中的Id
                options.ClientSecret ="secret";//注册在服务器中的secret               
                options.ResponseType = "code";//使用响应的类型 code

                options.Scope.Add("profile");//第三方代表用户去获取授权服务器允许授权的资源IdentitySource
                options.GetClaimsFromUserInfoEndpoint = true;//从 UserInfo 端点中提取剩余声明 name, family_name, website 等不会出现在返回的令牌中
                
                options.SaveTokens = true;//用于将将令牌持久保存在cookies中
            });  

####warning  The cookie '.AspNetCore.OpenIdConnect.Nonce.
CfDJ8AVEV7ePVaBBjPM1-DhNIEiEQ7emASkVG0q1UuCAOWzMCrgeLhcJ3fEGBwze9pGCjPbPzYVan9t_W5uwAA1A7XrlyPor2RFaoAAlP63H7KL-BRFNnA6EmkUj_uSWP1jPNRhVl8
fkvkKgUxr2CkEx5qPd8wJV5pQGcbsYn7D5qihAH53pLReYU4J5oIWJUI662UGW4VL9beKPpVvOebSFVxifdwSXyctY9lbZl77iyXLELP39XOcjrsXjuIEbtOP0HAs7vnNoct0z4yY5
fTNFmEc' has set 'SameSite=None' and must also set 'Secure'.
    解决方案:设置Mvc客户端使用https不要使用http

### 在mvc客户端中调用api1资源
    ·当用户登录后 客户端程序会拿到一个accessToken   options.SaveTokens = true客户端程序会将accessToken存在当前回话中。
    ·当需要调用受保护的资源的时候通过当前的httpContext获取到系统中的accessToken
     var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
    ·将token放入http请求头之中 向受保护的api1发起请求。
     var apiClient = new HttpClient();
        apiClient.SetBearerToken(accessToken);

###code part
     var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        var apiClient = new HttpClient();
        apiClient.SetBearerToken(accessToken);
        var response = await apiClient.GetAsync("https://localhost:7069/WeatherForecast");
        System.Console.WriteLine(accessToken);
        if(!response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.StatusCode);
        }
        else
        {
            var json =  await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);//Newtonsoft nuget  using Newtonsoft.Json.Linq
        }
        return Content("");
###将Api资源 Client资源 IdentityResouce资源 使用EF存入数据库