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

        public async void PostMessage(Msg msg)
        {
            string Url = "www.junakulkee.com";
            var content = JsonConvert.SerializeObject(msg);
            var response = await httpClient.PostAsync(Url, new StringContent(content));
            //return await response.Content.ReadAsStringAsync();
        }

        private void SendMessageButton_Clicked(object sender, EventArgs e)
        {
            Msg msg = new Msg();
            msg.Message = MessageBox.Text;
            CopiedText.Text = msg.Message;

            //PostMessage(msg);
        }
    }
}
