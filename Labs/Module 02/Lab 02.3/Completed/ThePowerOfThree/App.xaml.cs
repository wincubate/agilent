using System;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace ThePowerOfThree
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Semaphore _semaphore;
        private bool wasStartUpSuccessful = false; // <-- Have to save this for Exit

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string applicationName = Assembly.GetExecutingAssembly().GetName().Name;
            string semaphoreName = $"Global\\{applicationName}";

            _semaphore = new Semaphore(3, 3, semaphoreName, out bool wasSemaphoreCreatedNow);
            wasStartUpSuccessful = _semaphore.WaitOne(TimeSpan.FromMilliseconds(0));
            if(wasStartUpSuccessful)
            {
                // We're in the top 3 of instances. Yay!
            }
            else
            {
                // We outside the medal ranks! :-(
                Shutdown(-1);
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if(wasStartUpSuccessful)
            {
                _semaphore.Release();
            }
        }
    }
}
