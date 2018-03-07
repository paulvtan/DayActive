using System.ServiceProcess;
using DayActive.Engine.App.Helpers;

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
            Connector.EstablishConnection();
            GameDataObject gameDataObject = new GameDataObject();
            DayActiveController.DisplayWelcomeScreenAsync(gameDataObject);
            DayActiveController.RegisterGameMetaData(gameDataObject);
            DayActiveController.BindGameEvent(gameDataObject);
            DayActiveController.StartGameHeartBeatTimer();
            DayActiveController.StartMonitoringTimer(gameDataObject);
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
