using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.Model;
using QAiku.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Util;
using Newtonsoft.Json;
using System.Net.Http;

namespace QAiku
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnswerPage : ContentPage
	{
        private MsgModel _message;
        HttpClient httpClient = new HttpClient();

        public AnswerPage (MsgModel message)
		{

            NavigationPage.SetHasNavigationBar(this, false);

            Log.Info("QADEBUG", "AnswerPagen konstruktori käynnistyi");
            InitializeComponent();
            _message = message;
            BindingContext = new QuestionThreadPageModel(message);
            Log.Info("QADEBUG", $"QuestionThreadPagen konstruktori valmistui");
        }

        private async void SubmitAnswerButton_Clicked(object sender, EventArgs e)
        {
            MsgModel msg = new MsgModel();
            msg.Subject = Subject.Text;
            msg.Description = Answer.Text;
            msg.SenderId = "kovakoodattuLahettaja@answerpage.fi";

            msg.RecipientsIdCsv = $"{_message.RecipientsIdCsv};{msg.SenderId}";
            msg.SendDate = DateTime.Now.ToLocalTime() ;
            msg.Category = 2;
            msg.Favorite = true;
            msg.State = 0;
            msg.ThreadId = _message.ThreadId;
            try
            {
                string Url = "http://qaiku.azurewebsites.net/api/messages/post";
                var content = JsonConvert.SerializeObject(msg);
                var response = await httpClient.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
                Console.WriteLine(response.Content.ReadAsStringAsync());
                await DisplayAlert("Message sent!", $"Message: \"{msg.Subject}\"{Environment.NewLine}sent to {msg.RecipientsIdCsv}{Environment.NewLine} at {msg.SendDate}", "Ok!");
                Subject.Text = "Subject";
                Answer.Text = "Your answer";
              
                var nextPage = new NavigationPage(new QuestionThreadPage(_message));

                await this.Navigation.PushAsync(nextPage);
            }
            catch (Exception)
            {
                await DisplayAlert("Oops!", "Something went wrong", "Ok, I guess..");
            }
        }
    }
}