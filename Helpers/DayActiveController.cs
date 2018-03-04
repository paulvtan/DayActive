using DayActive.Engine.App.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Timers;
using Newtonsoft.Json;


namespace DayActive.Engine.App.Helpers
{
    public static class DayActiveController
    {
        public static DataPayLoad Data;
        public static void StartMonitoringTimer()
        {
            try
            {

                // Set up a timer to trigger CalculateTimeLeft.  
                Timer calculateTimeLeftTimer = new Timer();
                calculateTimeLeftTimer.Interval = 1000;
                calculateTimeLeftTimer.Elapsed += CalculateTimeLeft;
                calculateTimeLeftTimer.Elapsed += RefreshScreen;
                calculateTimeLeftTimer.Start();

                //Set up a timer to keep the screen alive.
                //Timer keepScreenAliveTimer = new Timer();
                //keepScreenAliveTimer.Interval = 10000;
                //keepScreenAliveTimer.Elapsed += RefreshScreen;
                //keepScreenAliveTimer.Start();

            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }

        }

        public static async void BindGameEvent()
        {
            string debugText = "";
            try
            {
                List<Datas> datas = new List<Datas>()
                {
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "",
                        IconId = 1,
                        Suffix = "%",
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
                BindGameEvent bindGameEvent = new BindGameEvent()
                {
                    Game = "DAYACTIVE",
                    Event = "DISPLAY_TIME",
                    IconId = 1,
                    Handlers = handlers
                };

                //Remove later
                debugText = JsonConvert.SerializeObject(bindGameEvent);
                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "bind_game_event", bindGameEvent);
                response.EnsureSuccessStatusCode();
            }
      
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
                ErrorHandling.LogErrorToTxtFile(ex, debugText);
            }
        }

        public static async void RegisterGameMetaData()
        {
            try
            {
                GameMetaData registerGameMetaData = new GameMetaData()
                {
                    Game = "DAYACTIVE",
                    GameDisplayName = "DayActive",
                    IconColorId = 5
                };

                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "game_metadata", registerGameMetaData);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }

        private static async void CalculateTimeLeft(object sender, ElapsedEventArgs e)
        {
            try
            {
                //Calculate time left in the day
                var remainingTimeString = TimeSpan.FromHours(24) - DateTime.Now.TimeOfDay;
                Console.WriteLine(remainingTimeString.TotalHours);
                var remainingHourInPercentage = Math.Round(((remainingTimeString.TotalHours / 24) * 100), 1);
                Data = new DataPayLoad()
                {
                    Game = "DAYACTIVE",
                    Event = "DISPLAY_TIME",
                    Data = new Data()
                    {
                        Value = remainingHourInPercentage
                    }
                };

                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "game_event", Data);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }

        }

        //Resfresh the screen to keep it alive. 
        public static async void RefreshScreen(object sender, ElapsedEventArgs e)
        {
            try
            {
                //HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                //    "game_event", Data);
                //response.EnsureSuccessStatusCode();
                GameHeartBeat gameHeartBeat = new GameHeartBeat()
                {
                    Game = "DAYACTIVE"
                };
                //Send heart beat every 15 seconds.
                HttpResponseMessage keepAliveResponse = await Connector.Client.PostAsJsonAsync(
                    "game_heartbeat", gameHeartBeat);
                keepAliveResponse.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }
    }
}
