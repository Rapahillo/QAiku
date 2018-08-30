using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using QAiku.Model;

namespace QAiku.SharedFunctionalities
{
    class StateColorCter:IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            State state = (State)((int)value);
            switch (state)
            {
                case State.Response:
                    return "#ebd9c8";
                case State.Unanswered:
                    return "#de6600";
                case State.Partial:
                    return "#fea02f";
                case State.Answered:
                    return "rgba(0, 122, 122, 0.5)";
                default:
                    break;
            }
         
            return Color.White;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
//enum State { Response, Unanswered, Partial, Answered }
}

