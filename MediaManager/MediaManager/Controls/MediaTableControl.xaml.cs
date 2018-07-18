using MediaManager.Business.ViewModels;
using MediaManager.Interfaces;
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
    /// Interaction logic for LibraryControl.xaml
    /// </summary>
    public partial class MediaTableControl
    {
        public MediaTableControl()
        {
            InitializeComponent();
        }
        
        private IEnumerable<ISelectableMediaFile> GetSelected()
        {
            return this.DisplayGrid.SelectedItems.OfType<ISelectableMediaFile>();
        }
        

        private void EditItems(object sender, RoutedEventArgs e)
        {
            var selected = GetSelected();
            
            //- bulk edit
        }

        private void SelectItems(object sender, RoutedEventArgs e)
        {
            var selected = GetSelected();

            foreach (var media in selected)
            {
                media.IsSelected = true;
            }
        }

        private void CreatePlaylist(object sender, RoutedEventArgs e)
        {
            var selected = GetSelected();

            //- create playlist
            //- add selected
        }

        private void AddToPlaylist(object sender, RoutedEventArgs e)
        {
            var selected = GetSelected();

            //- get existing playlist
            //- add selected
        }
    }
}
