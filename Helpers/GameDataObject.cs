using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayActive.Engine.App.Models;

namespace DayActive.Engine.App.Helpers
{
    public class GameDataObject
    {
        public BindGameEvent GameEventHandler { get; set; }
        public BindGameEvent WelcomeEventHandler { get; set; }
        public GameMetaData GameMetaData { get; set; }
        public DataPayLoad WelcomeDataPayLoad { get; set; }
        public GameDataObject()
        {
            CreateGameMetaData();
            CreateWelcomeEventHandler();
            CreateWelcomeEventDataPayLoad();
            CreateGameEventHandler();
        }

        public void CreateGameMetaData()
        {
            try
            {
                GameMetaData = new GameMetaData()
                {
                    Game = "DAYACTIVE",
                    GameDisplayName = "DayActive",
                    IconColorId = 5
                };
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }

        public void CreateWelcomeEventHandler()
        {
            try
            {
                List<Datas> datas = new List<Datas>()
                {
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "D",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "Da",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "Day",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "DayA",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "DayAc",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "DayAct",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "DayActi",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "DayActiv",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "DayActive",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "DayActive",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 500
                    },
                    new Datas()
                    {
                        HasText = true,
                        PreFix = "DayActive",
                        IconId = 15,
                        Suffix = "",
                        LengthMillis = 1000
                    },

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
                WelcomeEventHandler = new BindGameEvent()
                {
                    Game = "DAYACTIVE",
                    Event = "WELCOME",
                    Handlers = handlers
                };
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }

        public void CreateWelcomeEventDataPayLoad()
        {
            try
            {
                WelcomeDataPayLoad = new DataPayLoad()
                {
                    Game = "DAYACTIVE",
                    Event = "WELCOME",
                    Data = new Data()
                    {
                        Value = ""
                    }
                };
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }

        public void CreateGameEventHandler()
        {
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
                        LengthMillis = 15000,
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
                GameEventHandler = new BindGameEvent()
                {
                    Game = "DAYACTIVE",
                    Event = "DISPLAY_TIME",
                    Handlers = handlers
                };
            }
            catch (Exception ex)
            {
                string currentMethodName = ErrorHandling.GetCurrentMethodName();
                ErrorHandling.LogErrorToTxtFile(ex, currentMethodName);
            }
        }
    }

    
}
