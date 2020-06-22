using System.Threading;
using System.Windows;

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

            this.DataContext = new
            {
                ThreadId = Thread.CurrentThread.ManagedThreadId
            };
        }

        private void OnCreateNewWindow(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ThreadProc);
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;

            thread.Start();
        }

        private void ThreadProc()
        {
            MainWindow window = new MainWindow();
            window.Show();

            System.Windows.Threading.Dispatcher.Run();
        }

        private void OnBusyLoopClick(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(10000);
        }

        private void OnGetDispatcherClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Application.Current.Dispatcher.Thread.ManagedThreadId.ToString());
        }

        private void OnGetWindowsClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Application.Current.Windows.Count.ToString());
        }
    }
}
