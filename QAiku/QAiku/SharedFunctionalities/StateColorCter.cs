using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QAiku.SharedFunctionalities
{
    class StateColorCter:IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "Response":
                    return Color.Beige;
                case "Unanswered":
                    return Color.PaleGoldenrod;
                case "Partial":
                    return Color.Yellow;
                case "Answered":
                    return Color.PaleGreen;
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
//enum State { Response, Unanswered, Partial, Answered }
}

