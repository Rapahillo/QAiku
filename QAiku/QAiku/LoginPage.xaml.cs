using QAiku.Droid;
using QAiku.Model;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool authentication = false;
            UserModel user = new UserModel();
            user.UserId = UsernameLoginEntry.Text;
            authentication = true; //This is a development stage solution, don't keep!!
            // Here goes AAD authentication


            if (authentication == true)
            {
                var nextPage = new NavigationPage(new ListOfQuestionsPage());
                //var nextPage = new NavigationPage(new ListOfAnswersPage());

                await this.Navigation.PushModalAsync(nextPage);
            }
            
        }

        private async void RegisterNewUserButton_Clicked(object sender, EventArgs e)
        {
            var nextPage = new NavigationPage(new SignupPage());
            await this.Navigation.PushAsync(nextPage);
        }
    }
}