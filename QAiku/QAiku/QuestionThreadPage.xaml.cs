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

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionThreadPage : ContentPage
    {
        private MsgModel _message;
        public QuestionThreadPage (MsgModel message)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            Log.Info("QADEBUG", "QuestionThreadPagen konstruktori käynnistyi");
            InitializeComponent ();
            _message = message;
            BindingContext = new QuestionThreadPageModel(message);
            Log.Info("QADEBUG", $"QuestionThreadPagen konstruktori valmistui");





        }
        protected async override void OnAppearing()
        {
            Log.Info("QADEBUG", "Question Thread Pagen OnAppearing käynnistyi!");
            BindingContext = await QuestionThreadPageModel.Update(_message);
            Log.Info("QADEBUG", "Question Thread Pagen OnAppearing valmistui!");

        }

        private void SendYourAnswer_Clicked(object sender, EventArgs e)
        {
            Log.Info("QADEBUG", "SendYourAnswer clicked!");

            Log.Info("QADEBUG", $"{_message.ToString()}");
            var nextPage = new AnswerPage(_message);
            Navigation.PushAsync(nextPage);

        }

        private void StateButton_Clicked(object sender, EventArgs e)
        {
            Log.Info("qadebug", "Statebutton clicked");

        }
    }
}