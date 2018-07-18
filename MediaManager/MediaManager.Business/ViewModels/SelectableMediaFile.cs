using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Interfaces;
using System.ComponentModel;

namespace MediaManager.Business.ViewModels
{
    class SelectableMediaFile : ISelectableMediaFile, INotifyPropertyChanged
    {
        private bool isSelected;

        public IMediaFile MediaFile { get; set; }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        public SelectableMediaFile(IMediaFile mediafile)
        {
            MediaFile = mediafile;
        }


        public DateTime DateAdded
        {
            get { return MediaFile.DateAdded; }
            set { MediaFile.DateAdded = value;
                NotifyPropertyChanged("DateAdded");
            }
        }

        public string Label
        {
            get { return MediaFile.Label; }
            set { MediaFile.Label = value;
                NotifyPropertyChanged("Label");
            }
        }

        public int MediaFileId
        {
            get { return MediaFile.MediaFileId; }
            set { MediaFile.MediaFileId = value;
                NotifyPropertyChanged("MediaFileId");
            }
        }

        public string MediaType
        {
            get { return MediaFile.MediaType; }
            set { MediaFile.MediaType = value;
                NotifyPropertyChanged("MediaType");
            }
        }

        public IMediaMetaData MetaData
        {
            get { return MediaFile.MetaData; }
            set { MediaFile.MetaData = value;
                NotifyPropertyChanged("MetaData");
            }
        }

        public IProductionData ProductionData
        {
            get { return MediaFile.ProductionData; }
            set { MediaFile.ProductionData = value;
                NotifyPropertyChanged("ProductionData");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
