

        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using QAiku.Model;
using System.Windows.Input;
using Xamarin.Forms;
using Android.Util;
namespace QAiku.ViewModel
{
    class MsgItemViewModel : INotifyPropertyChanged
    {
        private MsgModel _message;
        public MsgModel Message

        {
            get
            { return _message; }
            set
            {
                if (_message == value)
                {
                    return;
                }
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        public MsgItemViewModel(MsgModel msg)
        {

            Log.Info("QADEBUG", "MessageItemViewModelin konstruktori käynnistyi!");
            _message = msg;
            Log.Info("QADEBUG", "MessageItemViewModelin konstruktori valmistui!");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyname)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
    
