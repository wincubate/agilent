using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ThereCanBeOnlyOne
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Mutex _mutex;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string applicationName = Assembly.GetExecutingAssembly().GetName().Name;
            string mutexName = $"Global\\{applicationName}";

            _mutex = new Mutex(true, mutexName, out bool wasMutexCreatedNow);
            if( wasMutexCreatedNow )
            {
                // We're the only instance alive. Yay!
            }
            else
            {
                // Somebody beat us to it! :-(
                Shutdown(-1);
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _mutex.Dispose(); // <-- Also releases the Mutex
        }
    }
}
