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
        public static void LogErrorToTxtFile(Exception ex, string errorMessage)
        {
            string filePath = @"C:\ProgramData\SteelSeries\SteelSeries Engine 3\Error.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Error in function: " + errorMessage);
                writer.WriteLine();
                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                                 "" + Environment.NewLine + "Date :" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }

        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        public static void DebugObject(HttpResponseMessage keepAliveResponse)
        {
            string filePath = @"C:\ProgramData\SteelSeries\SteelSeries Engine 3\Error.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Response Header: " + keepAliveResponse.Content.Headers);
                writer.WriteLine();
                writer.WriteLine(Environment.NewLine + "Date :" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}
