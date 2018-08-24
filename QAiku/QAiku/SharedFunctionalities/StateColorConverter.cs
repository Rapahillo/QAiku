using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QAiku.SharedFunctionalities
{
    class StateColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "Response":
                    return Color.Ivory;
                case "Unanswered":
                    return Color.DarkOrange;
                case "Partial":
                    return Color.Yellow;
                case "Answered":
                    return Color.PaleGoldenrod;
                default:
                    break;
            }
            return Color.Gray;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
