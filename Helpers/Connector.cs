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

        public static async void BindWelcomeEventAsync()
        {
            try
            {
                List<Datas> datas = new List<Datas>()
                {
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "",
                        IconId = 15,
                        Suffix = "",
                        Repeats = true
                    }
                };

                List<Handlers> handlers = new List<Handlers>()
                {
                    new Handlers()
                    {
                        DeviceType = "screened",
                        Zone = "one",
                        Mode = "screen",
                        Datas = datas
                    }
                };

                //Bind Handler
                BindGameEvent gameEventHandler = new BindGameEvent()
                {
                    Game = "DAYACTIVE",
                    Event = "WELCOME",
                    Handlers = handlers
                };

                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "bind_game_event", gameEventHandler);
                ErrorHandling.DebugObject(JsonConvert.SerializeObject(gameEventHandler));
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }

        //This method trys to run a welcome screen. Until it is passed run the welcome screen -> send the data the first time. 
        //If fails, wait sometime and call connect to mouse server again.
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
