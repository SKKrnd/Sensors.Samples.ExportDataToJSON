using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Samples.ExportDataToJSON
{
    public class Tokens
    {
        public async Task<TokenResponse> RequestTokenAsync()
        {
            var client = new HttpClient();
            //
            return await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://identity.skkhive.com/connect/token",
                //
                ClientId = ClientId 
                    ?? throw new ArgumentNullException(nameof(Tokens.ClientId)),
                ClientSecret = ClientSecret
                    ?? throw new ArgumentNullException(nameof(Tokens.ClientSecret)),
                //
                Parameters =
                {
                    { "scope", "sensors" }
                }
            });
        }

        public static string ClientId = null;
        public static string ClientSecret = null;
    }
}
