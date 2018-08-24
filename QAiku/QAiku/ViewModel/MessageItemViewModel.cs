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
    class MessageItemViewModel : INotifyPropertyChanged
    {
        private MsgModel _message;
        //bool canDownload = true;
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

        public MessageItemViewModel(MsgModel message)
        {
            Log.Info("QADEBUG", "MessageItemViewModelin konstruktori käynnistyi!");
            _message = message;
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
