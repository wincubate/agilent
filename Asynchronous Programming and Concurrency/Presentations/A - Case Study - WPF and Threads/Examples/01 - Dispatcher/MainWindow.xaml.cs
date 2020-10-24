using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Wincubate.Threading.CaseStudyA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnJustDoItClick(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            txtResult.Text = dt.ToLongTimeString();
        }

        private void OnNonUIClick(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(ThreadProc);
            t.Start(DateTime.Now);
        }

        private void ThreadProc(object state)
        {
            // Simulate computation
            Thread.SpinWait(1000000000);

            UpdateResult(state);

            //txtResult.Dispatcher.Invoke(
            //   DispatcherPriority.Normal,
            //   new Action<object>( UpdateResult ),
            //   state );
        }

        private void OnDispatcherClick(object sender, RoutedEventArgs e)
        {
            txtResult.Dispatcher.Invoke(
               DispatcherPriority.Normal,
               new Action<object>(UpdateResult),
               DateTime.Now);
        }

        private void UpdateResult(object time)
        {
            //// Simulate computation
            //Thread.SpinWait( 1000000000 );

            DateTime dt = (DateTime)time;
            txtResult.Text = dt.ToLongTimeString();
        }
    }
}
