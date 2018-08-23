using QAiku.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_GoogleAuth.Authentication;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage, IGoogleAuthenticationDelegate
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            //---------------------------------------------
            MainActivity.Auth = new GoogleAuthenticator(Configuration.ClientId, Configuration.Scope, Configuration.RedirectUrl, this);

            //---------------------------------------------
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool authentication = true;
            User user = new User();
            user.UserId = UsernameLoginEntry.Text;

            // Here goes AAD authentication


            if (authentication == true)
            {
                var nextPage = new NavigationPage(new MainPage());
                //var nextPage = new NavigationPage(new ListOfAnswersPage());

                await this.Navigation.PushModalAsync(nextPage);
            }
            
        }

        private async void RegisterNewUserButton_Clicked(object sender, EventArgs e)
        {
            var nextPage = new NavigationPage(new SignupPage());
            await this.Navigation.PushModalAsync(nextPage);
        }
    }
}