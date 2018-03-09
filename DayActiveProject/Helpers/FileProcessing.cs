using System;
using System.IO;
using DayActive.Engine.App.Models;
using Newtonsoft.Json;

namespace DayActive.Engine.App.Helpers
{
    public static class FileProcessing
    {
        public static UserSetting UserSetting = null;
        public static UserSetting ImportSettting()
        {
            try
            {
                string settingPath = @"C:\ProgramData\SteelSeries\SteelSeries Engine 3\DayActiveSetting.txt";
                if (!File.Exists(settingPath))
                {
                    UserSetting = new UserSetting()
                    {
                        CorePropPath = @"C:\ProgramData\SteelSeries\SteelSeries Engine 3\coreProps.json",
                        DebugModeOn = true
                    };
                    string jsonString = JsonConvert.SerializeObject(UserSetting);
                    System.IO.File.WriteAllText(settingPath, jsonString);
                } else if (File.Exists(settingPath))
                {
                    string jsonString = System.IO.File.ReadAllText(@"C:\ProgramData\SteelSeries\SteelSeries Engine 3\DayActiveSetting.txt");
                    UserSetting = JsonConvert.DeserializeObject<UserSetting>(jsonString);
                }
                return UserSetting;
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }

            return null;
        }

        public static string ReadFromFile(string path)
        {
            string jsonStringMousePort;
            try
            {
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"C:\ProgramData\SteelSeries\SteelSeries Engine 3\coreProps.json");
                jsonStringMousePort = file.ReadLine();
            }
            catch (Exception ex)
            {
                jsonStringMousePort = null;
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
            return jsonStringMousePort;
        }
    }
}
