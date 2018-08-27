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
        public ListOfQuestionsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Log.Info("QADEBUG", "ListOfQuestionsPagen konstruktori käynnistyi");
            InitializeComponent();
            
            BindingContext = new ListOfQuestionsPageModel();
           
            Log.Info("QADEBUG", $"ListOfQuestionsPagen konstruktori valmistui");
        }
        protected async override void OnAppearing()
        {
            Log.Info("QADEBUG", "ListOfQuestionsPagen OnAppearing käynnistyi!");
            BindingContext = await ListOfQuestionsPageModel.Update();
            Log.Info("QADEBUG", "ListOfQuestionsPagen OnAppearing valmistui!");

        }
        private void ViewThreadButton_Clicked(object sender, EventArgs e)
        {
            Log.Info("QADEBUG", "MessageItemView Viewthreadbutton käynnistyi!");
            var item = sender as MsgModel;
            var question = item.BindingContext as MsgModel;
            Log.Info("QADEBUG", question.ToString());
            var nextPage = new QuestionThreadPage();
            Navigation.PushAsync(nextPage);
            Log.Info("QADEBUG", "MessageItemView Viewthreadbutton valmistui!");
        }



        private void NewMessageButton_Clicked(object sender, EventArgs e)
        {
            var nextPage = new QuestionPage();
            Navigation.PushAsync(nextPage);
        }
    }
}
