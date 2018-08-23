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
      


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Messages = await GetAllMessagesAsync();
        }
   

    }
}