using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using QAiku.Model;
using System.ComponentModel;

namespace QAiku.ViewModel
{
    class ShowSingleAnswerModel : INotifyPropertyChanged
    {
        private MsgModel _answer;
        public MsgModel Answer
        {
            get { return _answer; }
            set
            {
                if (_answer == value)
                {
                    return;
                }
                _answer = value;
                OnPropertyChanged("Answer");
            }
        }
        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set
            {
                if (_user == value)
                {
                    return;
                }
                _user = value;
                OnPropertyChanged("User");
            }
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
        public ShowSingleAnswerModel(MsgModel message, UserModel user)
        {
            _user = user;
            _answer = message;
        }
    }
}
