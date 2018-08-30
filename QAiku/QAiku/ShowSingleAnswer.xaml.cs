using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.Model;
using QAiku.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QAiku
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowSingleAnswer : ContentPage
	{
        private MsgModel _answer;
        UserModel User;
        public ShowSingleAnswer(MsgModel message, UserModel user)
		{
            _answer = message;
            User = user;
			InitializeComponent ();
            BindingContext = new ShowSingleAnswerModel(_answer, User);

		}
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var nextPage = new UserProfilePage();
            Navigation.PushAsync(nextPage);
        }
    }
}