using System;
using System.Collections.Generic;
using System.Text;
using QAiku.SharedFunctionalities;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.Util;
using System.Linq;
using QAiku.Model;
using System.Windows.Input;

namespace QAiku.ViewModel
{
    class ListOfQuestionsPageModel: INotifyPropertyChanged
    {
        private ObservableCollection<MsgModel> _messages;
        public ObservableCollection<MsgModel> Messages
        {
            get { return _messages; }
            set
            {
                if (_messages == value)
                {
                    return;
                }
                _messages = value;
                OnPropertyChanged("Messages");
            }
        }
        public ICommand ViewThreadCommand { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyname)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        //public MsgModel MsgModel { get; set; }

        public ListOfQuestionsPageModel()
        {
            Log.Info("QADEBUG", "ListOfQuestionsPageModelin konstruktori käynnistyi");
            Messages = new ObservableCollection<MsgModel> { new MsgModel { Subject = "Fetching data...", Description = "Just a moment", SendDate = DateTime.Now, SenderId="Developer team" } };
            //ViewThreadCommand = new Command(ViewThreadButton_Command);
            Log.Info("QADEBUG", "ListOfQuestionsPageModelin konstruktori valmistui");

        }

 

        public static async Task<ListOfQuestionsPageModel> Update()
        {
            Log.Info("QADEBUG", "ListOfQuestionsPageModelin update käynnistyi");
            var listOfQuestionsPageModel = new ListOfQuestionsPageModel();
            await listOfQuestionsPageModel.Initialize();
            Log.Info("QADEBUG", "ListOfQuestionsPageModelin update valmistui");
            return listOfQuestionsPageModel;


        }

        private async Task Initialize()
        {
            await Task.Delay(1000);
            HttpCalls call = new HttpCalls();
            List<MsgModel> msgs = await call.GetAllMessagesAsync(); //Once we have user data, replace this with messages sent and received by the user
            var questions = msgs.Where(m => m.Category == 1);
            msgs = questions.OrderByDescending(m => m.SendDate).ToList();
            Log.Info("QADEBUG", $"ListOfQuestionsin Initialize-metodista {msgs.Count} viestiä");

            _messages = QaikuExtensions.ToObservableCollection<MsgModel>(msgs);


        }
    }
}
