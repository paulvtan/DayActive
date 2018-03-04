using DayActive.Engine.App.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DayActive.Engine.App.Helpers
{
    public static class Connector
    {
        public static HttpClient Client { get; set; }
        //Try to read the address of the mouse's local port.
        public static void ConnectToMouseServer()
        {
            Client = new HttpClient();
            try
            {
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"C:\ProgramData\SteelSeries\SteelSeries Engine 3\coreProps.json");
                string jsonStringMousePort = file.ReadLine();
                var jsonObjectMousePort = JsonConvert.DeserializeObject<JsonObjectMousePort>(jsonStringMousePort);
                Client.BaseAddress = new Uri("http://" + jsonObjectMousePort.Address + "/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }
    }
}
