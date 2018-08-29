using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using QAiku.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Widget;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        UserModel User;
        public QuestionPage (UserModel user)
        {
            User = user;
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

        }
        HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Sends user question to database
        /// </summary>
        private async void SendQuestionButton_Clicked(object sender, EventArgs e)
        {
            MsgModel msg = new MsgModel();
            msg.Subject = Question.Text;
            msg.Description = Description.Text.Trim();
            msg.SenderId = User.UserId;
            msg.RecipientsIdCsv = ChooseRecipient.Text;
            msg.SendDate = DateTime.Now;
            msg.Category = 1;
            msg.Favorite = true;
            msg.State = 1;
            msg.ThreadId = Guid.NewGuid().ToString();
            try
            {
                string Url = "http://qaiku.azurewebsites.net/api/messages/post";
                var content = JsonConvert.SerializeObject(msg);
                var response = await httpClient.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
                //await DisplayAlert("Message sent!", $"Message: \"{msg.Subject}\"{Environment.NewLine}sent to {msg.RecipientsIdCsv}{Environment.NewLine} at {msg.SendDate}", "Ok!");
                Toast.MakeText(Android.App.Application.Context, "Question was sent", ToastLength.Long).Show();

                Question.Text = "Question";
                Description.Text = "Description";
                ChooseRecipient.Text = "";
                ChooseRecipient.Placeholder = "Recipient";
                
                var nextPage = new NavigationPage(new ListOfQuestionsPage(User));
                //var nextPage = new ListOfQuestionsPage();
                await this.Navigation.PushModalAsync(nextPage);
            }
            catch (Exception)
            {
                Toast.MakeText(Android.App.Application.Context, "An error occured. Please, try sending your question again.", ToastLength.Long).Show();
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var nextPage = new UserProfilePage();
            Navigation.PushAsync(nextPage);
        }
        
    }

}