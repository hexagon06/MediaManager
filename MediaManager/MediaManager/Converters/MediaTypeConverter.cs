using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MediaManager.Converters
{
    [ValueConversion(typeof(string), typeof(PackIconFontAwesomeKind))]
    class MediaTypeConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string type = value as string;
            PackIconFontAwesomeKind result;

            switch (type)
            {
                case "Video":

                    result = PackIconFontAwesomeKind.VideoCamera;
                    break;
                case "Audio":
                    result = PackIconFontAwesomeKind.Microphone;
                    break;
                default:
                    result = PackIconFontAwesomeKind.QuestionCircle;
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
