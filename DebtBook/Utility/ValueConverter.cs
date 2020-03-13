using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DebtBook.Utility
{
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Int32 num = (Int32) value;
                if (num < 0)
                {
                    return Brushes.Red;
                }
                else
                {
                    return Brushes.Black;
                }
            }

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}