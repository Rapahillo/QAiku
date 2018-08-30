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
            }
        }
        private bool _toggleVisibility = true;
        public bool IsListVisible { get => _toggleVisibility; set
            {
                if (_toggleVisibility == value)
                {
                    return;
                }
                _toggleVisibility = value;
                OnPropertyChanged(nameof(IsListVisible));


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
        //public MsgModel MsgModel { get; set; }

        public ListOfQuestionsPageModel(UserModel user)
        {
            Log.Info("QADEBUG", "ListOfQuestionsPageModelin konstruktori käynnistyi");
            _user = user;
    
            Messages = new ObservableCollection<MsgModel> { new MsgModel { Subject = "Fetching data...", Description = "Just a moment", SendDate = DateTime.Now, SenderId="Developer team" } };
            //ViewThreadCommand = new Command(ViewThreadButton_Command);
            Log.Info("QADEBUG", "ListOfQuestionsPageModelin konstruktori valmistui");
   

        }

 

        public static async Task<ListOfQuestionsPageModel> Update(UserModel user)
        {
            Log.Info("QADEBUG", "ListOfQuestionsPageModelin update käynnistyi");
            var listOfQuestionsPageModel = new ListOfQuestionsPageModel(user);
            await listOfQuestionsPageModel.Initialize();
            Log.Info("QADEBUG", "ListOfQuestionsPageModelin update valmistui");
            return listOfQuestionsPageModel;


        }

        private async Task Initialize()
        {
            await Task.Delay(1000);
            HttpCalls call = new HttpCalls();
            List<MsgModel> msgs = new List<MsgModel>() ;
            List<MsgModel> sent = await call.GetSentMessagesAsync(User.UserId); 
            List<MsgModel> received = await call.GetReceivedMessagesAsync(User.UserId);
            //var questions = msgs.Where(m => m.Category == 1);
            List<string> Threadids = new List<string>() ;
            foreach (var item in sent)
            {
                if (!Threadids.Contains(item.ThreadId))
                {
                    Threadids.Add(item.ThreadId);
                    if (item.Category==1)
                         {
                             msgs.Add(item);

                         }
                }

                continue;
                
               
            }
            foreach (var item in received)
            {
                if (!Threadids.Contains(item.ThreadId))
                {
                    Threadids.Add(item.ThreadId);
                    List<MsgModel> thread = await call.GetThreadAsync(item.ThreadId);
                MsgModel originalquestion = thread[0];
                msgs.Add(originalquestion);
                }


            }
            
            msgs = msgs.OrderByDescending(m => m.State).ToList();

            
            Log.Info("QADEBUG", $"ListOfQuestionsin Initialize-metodista {msgs.Count} viestiä");

            _messages = QaikuExtensions.ToObservableCollection<MsgModel>(msgs);


        }
    }
    class MessageEqualityComparer : IEqualityComparer<MsgModel>
    {
        public bool Equals(MsgModel x, MsgModel y)
        {
            if ((object)x == null && (object)y == null)
            {
                return true;
            }
            if ((object)x == null || (object)y == null)
            {
                return false;
            }
            return x.id == y.id && x.Subject == y.Subject;
        }

        public int GetHashCode(MsgModel obj)
        {
            return obj.GetHashCode();
        }

    }
}
