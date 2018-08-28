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

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage ()
        {
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
            msg.Description = Description.Text;
            msg.SenderId = "kovakoodattuLahettaja@questionpage.fi";
            msg.RecipientsIdCsv = ChooseRecipient.Text;
            msg.SendDate = DateTime.Now;
            msg.Category = 1;
            msg.Favorite = true;
            msg.State = 1;
            try
            {
                string Url = "http://qaiku.azurewebsites.net/api/messages/post";
                var content = JsonConvert.SerializeObject(msg);
                var response = await httpClient.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
                Console.WriteLine(response.Content.ReadAsStringAsync());
                await DisplayAlert("Message sent!", $"Message: \"{msg.Subject}\"{Environment.NewLine}sent to {msg.RecipientsIdCsv}{Environment.NewLine} at {msg.SendDate}", "Ok!");
                Question.Text = "Question";
                Description.Text = "Description";
                ChooseRecipient.Text = "";
                ChooseRecipient.Placeholder = "Recipient";
            }
            catch (Exception)
            {
                await DisplayAlert("Oops!", "Something went wrong", "Ok, I guess..");
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var nextPage = new UserProfilePage();
            Navigation.PushAsync(nextPage);
        }
    }
}