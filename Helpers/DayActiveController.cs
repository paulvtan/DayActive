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
        public static DataPayLoad DataPayLoad;
        public static async void RegisterGameMetaData(GameDataObject gameDataObject)
        {
            try
            { 
                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "game_metadata", gameDataObject.GameMetaData);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }

        public static async void BindGameEvent(GameDataObject gameDataObject)
        {
            try
            {
                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "bind_game_event", gameDataObject.GameEventHandler);
                response.EnsureSuccessStatusCode();
            }

            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }

        public static void StartMonitoringTimer(GameDataObject gameDataObject)
        {
            try
            {

                // Set up a timer to trigger CalculateTimeLeft.  
                Timer calculateTimeLeftTimer = new Timer();
                calculateTimeLeftTimer.Interval = 60000;
                calculateTimeLeftTimer.Elapsed += CalculateTimeLeft;
                calculateTimeLeftTimer.Start();
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
                DataPayLoad = new DataPayLoad()
                {
                    Game = "DAYACTIVE",
                    Event = "DISPLAY_TIME",
                    Data = new Data()
                    {
                        Value = remainingHourInPercentage.ToString()
                    }
                };

                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "game_event", DataPayLoad);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }

        }

        //public static async void InitializedApp(GameDataObject gameDataObject)
        //{

        //}

        public static void StartGameHeartBeatTimer()
        {
            try
            {
                Timer gameHeartBeatTimer = new Timer();
                gameHeartBeatTimer.Interval = 10000;
                gameHeartBeatTimer.Elapsed += RefreshScreen;
                gameHeartBeatTimer.Start();
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
                GameHeartBeat gameHeartBeat = new GameHeartBeat()
                {
                    Game = "DAYACTIVE"
                };
            
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
