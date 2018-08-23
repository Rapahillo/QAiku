using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using QAiku.Droid;
using Xamarin.Forms;
using Android.Util;


namespace QAiku.ViewModel
{
    class QuestionThreadPageModel: INotifyPropertyChanged
    {
        private ObservableCollection<MsgModel> _messages;
        public ObservableCollection<MsgModel> Messages {
            get { return _messages; }
            set {
                if (_messages == value)
                {
                    return;
                }
                _messages = value;
                OnPropertyChanged("Messages");
            } }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyname)
        {
            var changed = PropertyChanged;
            if (changed !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        //public MsgModel MsgModel { get; set; }

        public QuestionThreadPageModel()
        {
            Log.Info("QTPM", "QuestionThreadPageModelin konstruktori käynnistyi");
            Messages = new ObservableCollection<MsgModel>();
            Log.Info("QTPM", "QuestionThreadPageModelin konstruktori valmistui");

        }


        public static async Task<QuestionThreadPageModel> Update()
        {
            Log.Info("QTPM", "QuestionThreadPageModelin update käynnistyi");
            var questionThreadPageModel = new QuestionThreadPageModel();
            await questionThreadPageModel.Initialize();
            Log.Info("QTPM", "QuestionThreadPageModelin update valmistui");
            return questionThreadPageModel;


        }

        private async Task Initialize()
        {
            Log.Info("QTPM", "QTPM Initialize-metodi käynnistyi");
            await Task.Delay(1000);
            HttpCalls call = new HttpCalls();
            List<MsgModel> msgs = await call.GetAllMessagesAsync();

            _messages = QaikuExtensions.ToObservableCollection<MsgModel>(msgs);
            Log.Info("QTPM", $"Initialize valmistui, tuloksena {msgs[0].Subject} viesti");


        }
    }
}
