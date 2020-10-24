using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Wincubate.Threading.Module07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cts;
        private Task _task;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnGoClick(object sender, RoutedEventArgs e)
        {
            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            _task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine(i);
                    if (token.IsCancellationRequested)
                    {
                        return;
                        //throw new OperationCanceledException( token );
                    }

                    //token.ThrowIfCancellationRequested();

                    Thread.Sleep(10);
                }
            }
            //, 
            //token
            );
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
        }

        private void OnStatusClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_task.Status.ToString());
        }
    }
}