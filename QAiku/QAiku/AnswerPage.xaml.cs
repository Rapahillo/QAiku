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
using Android.Widget;

namespace QAiku
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnswerPage : ContentPage
	{
        private MsgModel _message;
        HttpClient httpClient = new HttpClient();
        UserModel User;

        public AnswerPage (MsgModel message, UserModel user)
		{

            //NavigationPage.SetHasNavigationBar(this, false);

            _message = message;
            User = user;
            InitializeComponent();

            BindingContext = new QuestionThreadPageModel(message, user);
        }

        private async void SubmitAnswerButton_Clicked(object sender, EventArgs e)
        {
            MsgModel msg = new MsgModel();
            msg.Subject = $"Re: {_message.Subject}";
            msg.Description = Answer.Text.Trim();
            //msg.Description = Answer.Text;
            msg.SenderId = User.UserId;
            if (_message.RecipientsIdCsv.Contains(_message.SenderId))
            {
                msg.RecipientsIdCsv = _message.RecipientsIdCsv;
            }
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
                Toast.MakeText(Android.App.Application.Context, "Your answer was sent!", ToastLength.Long).Show();
                Answer.Text = "Your answer";

                await this.Navigation.PopAsync();
            }
            catch (Exception)
            {
                Toast.MakeText(Android.App.Application.Context, "Something went wrond. Please, try sending your answer again.", ToastLength.Long).Show();
            }
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

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            var nextPage = new NavigationPage(new ListOfQuestionsPage(User));
            Navigation.PushModalAsync(nextPage);
        }
    }
}