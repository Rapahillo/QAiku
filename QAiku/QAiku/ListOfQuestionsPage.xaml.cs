using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QAiku.ViewModel;
using Android.Util;
using System.Collections.ObjectModel;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfQuestionsPage : ContentPage
    {
        UserModel User;
        public ListOfQuestionsPage(UserModel user)
        {
            User = user;
            Log.Info("QADEBUG", "ListOfQuestionsPagen konstruktori käynnistyi");
            InitializeComponent();
            BindingContext = new ListOfQuestionsPageModel(User);
            //ViewThreadButton.Clicked += ViewThreadButton_Clicked


            Log.Info("QADEBUG", $"ListOfQuestionsPagen konstruktori valmistui");
        }
        protected async override void OnAppearing()
        {
            Log.Info("QADEBUG", "ListOfQuestionsPagen OnAppearing käynnistyi!");
            BindingContext = await ListOfQuestionsPageModel.Update(User);
            Log.Info("QADEBUG", "ListOfQuestionsPagen OnAppearing valmistui!");

        }
   


        private void ViewThreadButton_Clicked(object sender, EventArgs e)
        {
            Log.Info("QADEBUG", "Viewthreadbutton clicked!");
            var item = (sender as Button).CommandParameter as MsgModel;

            Log.Info("QADEBUG", $"{item.ToString()}");
            var nextPage = new QuestionThreadPage(item, User);
            Navigation.PushAsync(nextPage);



        }



        private void NewMessageButton_Clicked(object sender, EventArgs e)
        {
            var nextPage = new QuestionPage(User);
            Navigation.PushAsync(nextPage);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var nextPage = new UserProfilePage();
            Navigation.PushAsync(nextPage);
        }

        private async void QuestionList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MsgModel msgModel = (MsgModel)e.Item;
            var nextPage = new QuestionThreadPage(msgModel, User);
            await Navigation.PushAsync(nextPage);
        }
   
    }
}
