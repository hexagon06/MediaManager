using System.Windows;

namespace MediaManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var explorer = new ExplorerWindow();
            var result = explorer.ShowDialog() ?? false;
        }
    }
}
