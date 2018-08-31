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
    //Binding Context: ListOfQuestionsPageModel
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfQuestionsPage : ContentPage
    {
        UserModel User;
    
        //Setting the user parameter that determines which messages get retrieved
        //Loading page logo visible instead of question list, because the list has no data yet
        public ListOfQuestionsPage(UserModel user)
        {
            User = user;
            InitializeComponent();
            Qaikulogo.IsVisible = true;
            Loading.IsVisible = true;

            QuestionList.IsVisible = false;
            NewMessageButton.IsVisible = false;
            BindingContext = new ListOfQuestionsPageModel(User);


        }
        //Fetching data async, and toggling the logo for the question list once data is retrieved
        /// <summary>
        /// Updates the data for the List of Questions page
        /// </summary>
        protected async override void OnAppearing()
        {
            Qaikulogo.IsVisible = true;
            Loading.IsVisible = true;

            QuestionList.IsVisible = false;
            NewMessageButton.IsVisible = false;

            BindingContext = await ListOfQuestionsPageModel.Update(User);
            Loading.IsVisible = false;

            Qaikulogo.IsVisible = false;
            QuestionList.IsVisible = true;
            NewMessageButton.IsVisible = true;
        }
   

        
        private void ViewThreadButton_Clicked(object sender, EventArgs e)
        {
            var item = (sender as Button).CommandParameter as MsgModel;
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
        //Shows the details of an individual question thread
        private async void QuestionList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MsgModel msgModel = (MsgModel)e.Item;
            var nextPage = new QuestionThreadPage(msgModel, User);
            await Navigation.PushAsync(nextPage);
        }
   
    }
}
