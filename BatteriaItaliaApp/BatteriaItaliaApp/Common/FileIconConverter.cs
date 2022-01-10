using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using static BatteriaItaliaApp.Models.Enums;

namespace BatteriaItaliaApp.Common
{
    class FileIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((Difficolta)value)
                {
                    case Difficolta.Facile:
                        return Brush.Green;

                    case Difficolta.Medio:
                        return Brush.Yellow;

                    case Difficolta.Difficile:
                        return Brush.Red;
                }
            }

            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
