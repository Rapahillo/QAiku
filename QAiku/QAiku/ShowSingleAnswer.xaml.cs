using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QAiku
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowSingleAnswer : ContentPage
	{
        public ShowSingleAnswer(MsgModel message, UserModel user)
		{
			InitializeComponent ();
		}
	}
}