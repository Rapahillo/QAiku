using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QAiku.ViewModel;
using Android.Util;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfQuestionsPage : ContentPage
    {
        public ListOfQuestionsPage ()
        {
                Log.Info("LOQP", "ListOfQuestionsPagen konstruktori käynnistyi");
                InitializeComponent ();
                BindingContext = new ListOfQuestionsPageModel();
                Log.Info("LOQP", $"ListOfQuestionsPagen konstruktori valmistui");





            }
        protected async override void OnAppearing()
        {
            Log.Info("LOQP", "ListOfQuestionsPagen OnAppearing käynnistyi!");
            BindingContext = await ListOfQuestionsPageModel.Update();
            Log.Info("LOQP", "ListOfQuestionsPagen OnAppearing valmistui!");
            Log.Info("LOQP", BindingContext.ToString());

        }

        private void NewMessageButton_Clicked(object sender, EventArgs e)
        {
            var nextPage = new QuestionPage();
            Navigation.PushAsync(nextPage);
        }
    }
}
