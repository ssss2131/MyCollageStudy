using IdentityModel.Client;
using Newtonsoft.Json.Linq;
var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
if(disco.IsError)
{
    System.Console.WriteLine(disco.Error);
    return;
}
// 请求令牌
var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,
    ClientId = "client",
    ClientSecret = "secret",
    Scope = "api1"
});
if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}
//调用api

Console.WriteLine(tokenResponse.Json);

//调用Api
var　apiClient = new HttpClient();
apiClient.SetBearerToken(tokenResponse.AccessToken);

var response = await apiClient.GetAsync("https://localhost:6001/identity");
if(!response.IsSuccessStatusCode)
{
    System.Console.WriteLine(response.StatusCode);
}
else
{
    var content = await response.Content.ReadAsStringAsync();
    var header =  response.Headers;
    System.Console.WriteLine(header.ToString());
    System.Console.WriteLine(JArray.Parse(content));
}