using DayActive.Engine.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;


namespace DayActive.Engine.App.Helpers
{
    public static class DayActiveController
    {
        public static void StartMonitoringTimer()
        {
            try
            {
                // Set up a timer to trigger every minute.  
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 85000; // 80 seconds  
                timer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateScreen);
                timer.Start();
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }

        }

        static async void UpdateScreen(object sender, ElapsedEventArgs e)
        {
            try
            {
                //Calculate time left in the day
                var remainingTimeString = TimeSpan.FromHours(24) - DateTime.Now.TimeOfDay;
                Console.WriteLine(remainingTimeString.TotalHours);
                var remainingHourInPercentage = Math.Round(((remainingTimeString.TotalHours / 24) * 100), 1);
                DataPayLoad data = new DataPayLoad()
                {
                    game = "DAYACTIVE",
                    @event = "DISPLAY_TIME",
                    data = new Data()
                    {
                        value = remainingHourInPercentage
                    }
                };

                HttpResponseMessage response = await Connector.Client.PostAsJsonAsync(
                    "game_event", data);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }

        }
    }
}
