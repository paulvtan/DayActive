using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace DayActive.Engine.App.Helpers
{
    public static class ErrorHandling
    {
        private static string ErrorFilePath = @"C:\ProgramData\SteelSeries\SteelSeries Engine 3\Error.txt";
        public static void LogErrorToTxtFile(Exception ex, string errorMessage)
        {
            if (FileProcessing.UserSetting.DebugModeOn)
            {
                using (StreamWriter writer = new StreamWriter(ErrorFilePath, true))
                {
                    writer.WriteLine("Error in function: " + errorMessage);
                    writer.WriteLine();
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                                     "" + Environment.NewLine + "Date :" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }


        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        public static void DebugObject(string jsonString)
        {
            if (FileProcessing.UserSetting.DebugModeOn)
            {
                using (StreamWriter writer = new StreamWriter(ErrorFilePath, true))
                {
                    writer.WriteLine("Json Payload: " + jsonString);
                    writer.WriteLine();
                    writer.WriteLine(Environment.NewLine + "Date :" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
            }
        }
    }
}
