using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using QAiku.SharedFunctionalities;
using Xamarin.Forms;
using Android.Util;
using QAiku.Model;


namespace QAiku.ViewModel
{
    class QuestionThreadPageModel: INotifyPropertyChanged
    {
        private MsgModel _question;

        public MsgModel Question
        {
            get { return _question; }
            set
            {
                if (_question == value)
                {
                    return;
                }
                _question = value;
                OnPropertyChanged("Question");
            }
        }
        private ObservableCollection<MsgModel> _answerlist;
        public ObservableCollection<MsgModel> AnswerList {
            get { return _answerlist; }
            set {
                if (_answerlist == value)
                {
                    return;
                }
                _answerlist = value;
                OnPropertyChanged("AnswerList");
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

        public QuestionThreadPageModel(MsgModel message)
        {
            Log.Info("QADEBUG", "QuestionThreadPageModelin konstruktori käynnistyi");
            _question = message;
            AnswerList = new ObservableCollection<MsgModel>();
            Log.Info("QADEBUG", "QuestionThreadPageModelin konstruktori valmistui");

        }


        public static async Task<QuestionThreadPageModel> Update(MsgModel message)
        {
            Log.Info("QADEBUG", "QuestionThreadPageModelin update käynnistyi");
            var questionThreadPageModel = new QuestionThreadPageModel(message);
            string threadid = message.ThreadId;
            await questionThreadPageModel.Initialize(threadid);
            Log.Info("QADEBUG", "QuestionThreadPageModelin update valmistui");
            return questionThreadPageModel;


        }

        private async Task Initialize(string threadid)
        {
            Log.Info("QADEBUG", "QuestionThreadPageModelin Initialize-metodi käynnistyi");
            await Task.Delay(1000);
            HttpCalls call = new HttpCalls();
            List<MsgModel> msgs = await call.GetThreadAsync(threadid);
            _question = msgs[0];
            Log.Info("qadebug", $"{_question.ToString()}");
            msgs.RemoveAt(0);
            _answerlist = QaikuExtensions.ToObservableCollection<MsgModel>(msgs);
            Log.Info("QADEBUG", $"GetThreadInitialize valmistui!");


        }
    }
}
