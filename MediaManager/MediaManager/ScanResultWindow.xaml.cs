using MediaManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MediaManager
{
    /// <summary>
    /// Interaction logic for ScanResultWindow.xaml
    /// </summary>
    public partial class ScanResultWindow
    {
        public ScanResultWindow(IScanResultViewModel viewmodel)
        {
            InitializeComponent();

            DataContext = viewmodel;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
