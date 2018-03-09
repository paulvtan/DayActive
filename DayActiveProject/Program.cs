using System.ServiceProcess;

namespace DayActive.Engine.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new DayActiveService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
