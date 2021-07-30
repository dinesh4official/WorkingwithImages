using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys.Helper.Converter
{
    [Preserve(AllMembers = true)]
    public class ByteToImageSourceConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] imageBytes = (byte[])value;

            if (imageBytes == null)
            {
                return default;
            }
            else
            {
                return ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion

    }
}
