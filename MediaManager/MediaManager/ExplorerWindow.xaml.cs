using MediaManager.Business;
using Ninject.Parameters;
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
    using Configuration;
    using Entity;
    /// <summary>
    /// Interaction logic for ExplorerWindow.xaml
    /// </summary>
    public partial class ExplorerWindow
    {
        public ExplorerWindow()
        {
            InitializeComponent();

            var types = ApplicationConfig.MediaTypes;
            var mediatypes = new MediaTypes(types);

            DataContext = IoCKernel.Get<IExplorerViewModel>(new ConstructorArgument("mediaTypes", mediatypes,true));
        }
    }
}
