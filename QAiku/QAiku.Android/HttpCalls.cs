using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace QAiku.Droid
{
    public class HttpCalls
    {
        HttpClient httpClient = new HttpClient();
        string RestUrl = "http://qaiku.azurewebsites.net/api/messages/";
        public async Task<List<MsgModel>> GetAllMessagesAsync()
        {
            var uri = new Uri(string.Format(RestUrl, "GetAllMessages"));
            var response = await httpClient.GetAsync(uri);
            List<MsgModel> Messages = null; ;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Messages = JsonConvert.DeserializeObject<List<MsgModel>>(content);
            }
            return Messages;
        }
    }
}