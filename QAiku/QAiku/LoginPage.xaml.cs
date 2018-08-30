using Android.Widget;
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
        Dictionary<string, string> userList = new Dictionary<string, string>();

        public LoginPage()
        {
            userList.Add("sari@qaiku.com", "Salainen1!");
            userList.Add("mikko@qaiku.com", "Salainen1!");
            userList.Add("juupero@gmail.com", "Salainen1!");
            userList.Add("ville.immonen2@gmail.com", "Salainen1!");

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool authentication = false;
            UserModel user = new UserModel();
            user.UserId = UsernameLoginEntry.Text;
            foreach (var item in userList)
            {
                if (item.Key == user.UserId && item.Value == UserPasswordEntry.Text)
                {
                    authentication = true;
                }
            }

            authentication = true; //This is a development stage solution, don't keep!!
            // Here goes AAD authentication


            if (authentication == true)
            {
                var nextPage = new NavigationPage(new ListOfQuestionsPage(user));
                //var nextPage = new NavigationPage(new ListOfAnswersPage());
                Toast.MakeText(Android.App.Application.Context, "Login succesful!", ToastLength.Long).Show();
                await this.Navigation.PushModalAsync(nextPage);
            }
            else if (authentication == false)
            {
                Toast.MakeText(Android.App.Application.Context, "Invalid login credentials!", ToastLength.Long).Show();
            }
        }

        private async void RegisterNewUserButton_Clicked(object sender, EventArgs e)
        {
            var nextPage = new NavigationPage(new SignupPage());
            await this.Navigation.PushModalAsync(nextPage);
        }
    }
}