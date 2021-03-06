﻿using QAiku.Model;
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
	public partial class SettingsPage : ContentPage
	{
        UserModel User;
		public SettingsPage (UserModel user)
		{
            User = user;
			InitializeComponent ();
		}

        private void EditProfileButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ChangePasswordButton_Clicked(object sender, EventArgs e)
        {

        }

        private void MessageHistoryButton_Clicked(object sender, EventArgs e)
        {

        }

        private void GiveFeedbackButton_Clicked(object sender, EventArgs e)
        {

        }

        private void SignOutButton_Clicked(object sender, EventArgs e)
        {

        }

        private void TermsOfServiceButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var nextPage = new NavigationPage(new ListOfQuestionsPage(User));
            Navigation.PushModalAsync(nextPage);
        }
    }
}