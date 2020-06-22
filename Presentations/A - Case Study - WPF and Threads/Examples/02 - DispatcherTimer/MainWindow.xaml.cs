using System;
using System.Windows;
using System.Windows.Threading;

namespace Wincubate.Threading.CaseStudyA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _dispatcherTimer = null;

        public MainWindow()
        {
            InitializeComponent();

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(OnDispatcherTimerTick);
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000);
        }

        private static string GenerateTickString()
        {
            return DateTime.Now.ToLongTimeString();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Start();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            _dispatcherTimer.Stop();
        }

        void OnDispatcherTimerTick(object sender, EventArgs e)
        {
            lst.Items.Add(GenerateTickString());
        }
    }
}
