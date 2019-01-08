using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Sensors.Samples.ExportDataToJSON
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Tokens.ClientId = "<clientId>";
            Tokens.ClientSecret = "<clientSecret>";
            //
            Console.WriteLine("Please pass orderId :");
            var orderId = Console.ReadLine();
            //
            Console.WriteLine("Please pass orderUnitId :");
            var orderUnitId = Console.ReadLine();
            //
            var outputFilePath = Directory.GetCurrentDirectory() + "\\OrderUnitReadings.json";
            if (File.Exists(outputFilePath))
                File.Delete(outputFilePath);
            //

            // Requesting AccessToken. It is needed for a parameter given to the uri that gives back json
            var token = new Tokens();
            var tokenResponse = await token.RequestTokenAsync();
            
            // Uri contains of orderID and orderUnitID given given as a parameter to program and user's accesstoken
            var uri = new Uri($"https://skk-sensors-functions-pro.azurewebsites.net/api/ExportOrderUnitDataToJSON" +
                $"?orderId={orderId}" +
                $"&orderUnitId={orderUnitId}" +
                $"&accessToken={tokenResponse.AccessToken}");
            
            //Acquiring and saving json
            using (var w = new WebClient())
            {
                try
                {
                    var downloadedObject = w.DownloadString(uri);
                    //                    
                    using (var writer = new StreamWriter(outputFilePath, false))
                        writer.Write(downloadedObject);
                    //
                    Console.WriteLine($"Json data saved : {outputFilePath}.");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
            }
        }
    }
}
