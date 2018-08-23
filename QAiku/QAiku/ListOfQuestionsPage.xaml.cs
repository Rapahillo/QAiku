using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfQuestionsPage : ContentPage
    {
        public ListOfQuestionsPage ()
        {
            InitializeComponent ();
            //BindingContext = new ListOfQuestionsPageModel();
        }
        //List<Msg> Messages = null;

        protected /*async*/ override void OnAppearing()
        {
            
        //KUTSU TÄSSÄ KOHTAA VIEWMODELISTA UPDATE!!!!
        }
        //{
        //    Messages = await GetAllMessagesAsync();
        //}
        //private async Task<List<Msg>> GetAllMessagesAsync()
        //{
        //    var uri = new Uri(string.Format(RestUrl, "GetAllMessages"));
        //    var response = await httpClient.GetAsync(uri);
        //    List<Msg> Messages = null; ;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        Messages = JsonConvert.DeserializeObject<List<Msg>>(content);
        //    }
        //    return Messages;
        //}
    }
}
