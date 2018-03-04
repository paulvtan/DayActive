using System.ServiceProcess;

namespace DayActive.Engine.App
{
    partial class DayActiveService : ServiceBase
    {
        public DayActiveService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            Helpers.Connector.ConnectToMouseServer();
            Helpers.DayActiveController.RegisterGameMetaData();
            Helpers.DayActiveController.BindGameEvent();
            Helpers.DayActiveController.StartMonitoringTimer();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
