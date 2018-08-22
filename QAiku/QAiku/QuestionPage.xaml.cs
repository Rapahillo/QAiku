using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage ()
        {
            InitializeComponent ();
        }
        HttpClient httpClient = new HttpClient();

        private async void SendQuestionButton_Clicked(object sender, EventArgs e)
        {
            var msg = "jepujee";

            

            try
            {
                string Url = "http://qaiku.azurewebsites.net/api/messages/post";
                //var content = JsonConvert.SerializeObject(msg);
                var response = await httpClient.PostAsync(Url, new StringContent(msg, Encoding.UTF8, "application/json"));
                Console.WriteLine(response.Content.ReadAsStringAsync());

            }
            catch (Exception)
            {

            }
        }
    }
}