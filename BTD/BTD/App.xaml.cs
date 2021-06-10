using BTD.Windows;
using BTDCore.Models;
using BTDService.Services.db.EventsLogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BTD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly static IEventsLogService _eventsLogService = new EventsLogService();
        
        internal async static void CloseApp() 
        {
            await _eventsLogService.AddAsync(new EventLog
            {
                
                UserId = LoginWindow.CurrentUser.Id,
                TableId = default,
                SystemEventId = (int)BTDSystemEvents.ExitFromSystem,
                DateOfEvent = DateTime.Now
            });
            Current.Shutdown();
        }
    }
}
