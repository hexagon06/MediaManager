using MediaManager.Business;
using System.Windows;

namespace MediaManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ILibraryViewModel Model { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = Model = IoCKernel.Get<ILibraryViewModel>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var explorer = new ExplorerWindow();
            var result = explorer.ShowDialog() ?? false;
        }
    }
}
