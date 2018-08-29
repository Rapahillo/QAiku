using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using QAiku.Model;

namespace QAiku.SharedFunctionalities
{
    class StateStringCter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            State state = (State)((int)value);
            switch (state)
            {
                case State.Response:
                    return "Response";
                case State.Unanswered:
                    return "Open";
                case State.Partial:
                    return "Partial";
                case State.Answered:
                    return "Answered";
                default:
                    break;
            }
            return null;
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
