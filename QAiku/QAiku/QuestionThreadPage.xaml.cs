using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.ViewModel;
using Android.Util;
using QAiku.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QAiku.SharedFunctionalities;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionThreadPage : ContentPage
    {
        UserModel User;
        private MsgModel _message;

        public QuestionThreadPage()
        {
            User = new UserModel();
            User.UserId = "kovakoodattuLahettaja@questionpage.fi";
            InitializeComponent();
            BindingContext = new QuestionThreadPageModel(User);
        }

        public QuestionThreadPage (MsgModel message, UserModel user)
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            User = user;
            _message = message;
            Log.Info("QADEBUG", "QuestionThreadPagen konstruktori käynnistyi");
            InitializeComponent ();
            BindingContext = new QuestionThreadPageModel(message, user);
            Log.Info("QADEBUG", $"QuestionThreadPagen konstruktori valmistui");





        }
        protected async override void OnAppearing()
        {
            Log.Info("QADEBUG", "Question Thread Pagen OnAppearing käynnistyi!");
            BindingContext = await QuestionThreadPageModel.Update(_message, User);
            Log.Info("QADEBUG", "Question Thread Pagen OnAppearing valmistui!");

        }

        private void SendYourAnswer_Clicked(object sender, EventArgs e)
        {
            Log.Info("QADEBUG", "SendYourAnswer clicked!");

            Log.Info("QADEBUG", $"{_message.ToString()}");
            var nextPage = new AnswerPage(_message, User);
            Navigation.PushAsync(nextPage);

        }

        private async void StateButton_Clicked(object sender, EventArgs e)
        {
            Log.Info("qadebug", $"Statebutton clicked, {_message.State.ToString()}");
            if (_message.State == 1)
            {
                _message.State = 3;
            }
            else
            {
            _message.State--;

            }
            Log.Info("qadebug", $"Statebutton clicked, {_message.State.ToString()} after click");
            HttpCalls call = new HttpCalls();
            MsgModel updated = await call.PutStateAsync(_message.id, _message);
            Log.Info("qadebug", $"Statebutton clicked, {updated.State.ToString()} after click");
            _message = updated;
            BindingContext = await QuestionThreadPageModel.Update(_message, User);



        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var nextPage = new UserProfilePage();
            Navigation.PushAsync(nextPage);
        }

        private async void AnswerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
                MsgModel msgModel = (MsgModel)e.Item;
                var nextPage = new ShowSingleAnswer(msgModel, User);
                await Navigation.PushAsync(nextPage);
            
        }
    }
}