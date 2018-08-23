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
	public partial class SignupPage : ContentPage
	{
		public SignupPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
		}

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {

        }

        private void facebookLoginButton_Clicked(object sender, EventArgs e)
        {

        }

        private void googleLoginButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void ReturnToLoginButton_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }

    }
}