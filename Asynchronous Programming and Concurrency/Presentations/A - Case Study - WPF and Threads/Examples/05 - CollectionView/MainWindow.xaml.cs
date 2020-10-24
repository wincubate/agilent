using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Wincubate.Threading.CaseStudyA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICollectionView _collectionView;

        public MainWindow()
        {
            InitializeComponent();

            _collectionView = CollectionViewSource.GetDefaultView(DataContext);
        }

        private void buttonMoveFirst_Click(object sender, RoutedEventArgs e)
        {
            _collectionView.MoveCurrentToFirst();
        }

        private void buttonMovePrevious_Click(object sender, RoutedEventArgs e)
        {
            _collectionView.MoveCurrentToPrevious();
        }

        private void buttonMoveNext_Click(object sender, RoutedEventArgs e)
        {
            _collectionView.MoveCurrentToNext();
        }

        private void buttonMoveLast_Click(object sender, RoutedEventArgs e)
        {
            _collectionView.MoveCurrentToLast();
        }
    }
}
