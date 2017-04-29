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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaManager.Controls
{
    /// <summary>
    /// Interaction logic for SettingsFlyout.xaml
    /// </summary>
    public partial class SettingsFlyout
    {
        public SettingsFlyout()
        {
            InitializeComponent();
        }

        private void Flyout_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Flyout_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            LoadDataContext();
        }

        private void LoadDataContext()
        {
            DataContext = IoCKernel.Get<ISettingsViewModel>();
        }
    }
}
