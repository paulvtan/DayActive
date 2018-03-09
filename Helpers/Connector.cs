using DayActive.Engine.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
                    new System.IO.StreamReader(FileProcessing.UserSetting.CorePropPath);
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

        public static async Task BindWelcomeEventAsync(BindGameEvent welcomeEventHandler)
        {
            try
            {
                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "bind_game_event", welcomeEventHandler);
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }


        public static bool EstablishConnection()
        {
            try
            {
                while (true)
                {
                    Process[] pname = Process.GetProcessesByName("SteelSeriesEngine3");
                    if (pname.Length > 0)
                    {
                        break;
                    }
                    //Wait 30 seconds before trying again.
                    System.Threading.Thread.Sleep(10000);
                }
                ConnectToMouseServer();

                return true;
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }

            return false;
        }
    }
}
