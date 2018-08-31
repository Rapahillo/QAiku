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
using Android.Widget;

namespace QAiku
{
    //BindingContext: QuestionThreadPageModel
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionThreadPage : ContentPage
    {
        UserModel User;
        private MsgModel _message;

     

        public QuestionThreadPage (MsgModel message, UserModel user)
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            User = user;
            _message = message;
            InitializeComponent ();
            BindingContext = new QuestionThreadPageModel(message, user);
        }
        protected async override void OnAppearing()
        {
            BindingContext = await QuestionThreadPageModel.Update(_message, User);
        }

        private void SendYourAnswer_Clicked(object sender, EventArgs e)
        {
            var nextPage = new AnswerPage(_message, User);
            Navigation.PushAsync(nextPage);
        }

        //Toggles the state of the message
        private async void StateButton_Clicked(object sender, EventArgs e)
        {
            if (_message.State == 1)
            {
                _message.State = 3;
            }
            else
            {
            _message.State--;

            }
            HttpCalls call = new HttpCalls();
            MsgModel updated = await call.PutStateAsync(_message.id, _message);
            _message = updated;
            BindingContext = await QuestionThreadPageModel.Update(_message, User);
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var nextPage = new UserProfilePage();
            Navigation.PushAsync(nextPage);
        }

        //Shows the details of an individual answer
        private async void AnswerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                MsgModel msgModel = (MsgModel)e.Item;
                var nextPage = new ShowSingleAnswer(msgModel, User);
                await Navigation.PushAsync(nextPage);
            }
            catch (Exception)
            {
                Toast.MakeText(Android.App.Application.Context, "Uh oh... An error occured", ToastLength.Long).Show();
            }
            
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            var nextPage = new NavigationPage(new ListOfQuestionsPage(User));
            Navigation.PushAsync(nextPage);
        }
    }
}