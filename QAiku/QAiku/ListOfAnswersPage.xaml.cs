using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfAnswersPage : ContentPage
    {
        public ListOfAnswersPage ()
        {
            InitializeComponent ();
        }
        List<Msg> Messages = null;
        HttpClient httpClient = new HttpClient();
        string RestUrl = "http://qaiku.azurewebsites.net/api/messages/";


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Messages = await GetAllMessagesAsync();
        }
        private async Task<List<Msg>> GetAllMessagesAsync()
        {
            var uri = new Uri(string.Format(RestUrl, "GetAllMessages"));
            var response = await httpClient.GetAsync(uri);
            List<Msg> Messages = null; ;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Messages = JsonConvert.DeserializeObject<List<Msg>>(content);
            }
            return Messages;
        } 

    }
}