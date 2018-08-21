using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace QAiku
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        HttpClient httpClient = new HttpClient();

        public async void PostMessage(string msg)
        {
            try
            {
                string Url = "http://qaiku.azurewebsites.net/api/messages/post";
                //var content = JsonConvert.SerializeObject(msg);
                var response = await httpClient.PostAsync(Url, new StringContent( msg, Encoding.UTF8 ,"application/json"));
                Console.WriteLine(response.Content.ReadAsStringAsync());
                 
            }
            catch (Exception)
            {

            }
        }

        private void SendMessageButton_Clicked(object sender, EventArgs e)
        {
            Msg msg = new Msg();
            msg.Subject = MessageBox.Text;
            msg.Description = "";
            msg.SenderId = "123FakeMail@FakeSpam.com";
            msg.RecipientsIdCsv = "Eka@SpamFake.com;Toka@SpamFake.com;23498321MailFakeKolmas@SpamFake.com";
            msg.SendDate = DateTime.Now;
            msg.Category = 1;
            msg.Favorite = false;

            CopiedText.Text = msg.Subject;



            PostMessage(JsonConvert.SerializeObject( msg));
        }
    }
}
