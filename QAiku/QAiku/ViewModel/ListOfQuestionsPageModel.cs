﻿using System;
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
 


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyname)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public ListOfQuestionsPageModel(UserModel user)
        {
            _user = user;
    
            Messages = new ObservableCollection<MsgModel> { new MsgModel { Subject = "Fetching data...", Description = "Just a moment", SendDate = DateTime.Now, SenderId="Developer team" } };
   

        }

 
        //Updates the data on the list page async
        public static async Task<ListOfQuestionsPageModel> Update(UserModel user)
        {
            var listOfQuestionsPageModel = new ListOfQuestionsPageModel(user);
            await listOfQuestionsPageModel.Initialize();
            return listOfQuestionsPageModel;


        }
        //Fetches the user's sent and received messages async
        private async Task Initialize()
        {
            await Task.Delay(1000);
            HttpCalls call = new HttpCalls();
            List<MsgModel> msgs = new List<MsgModel>() ;
            List<MsgModel> sent = await call.GetSentMessagesAsync(User.UserId); 
            List<MsgModel> received = await call.GetReceivedMessagesAsync(User.UserId);
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
         
            msgs = msgs.OrderBy(m => m.State).ToList();
            _messages = QaikuExtensions.ToObservableCollection<MsgModel>(msgs);


        }
    }

}
