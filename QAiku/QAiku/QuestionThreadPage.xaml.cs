using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QAiku
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestionThreadPage : ContentPage
	{
		public QuestionThreadPage ()
		{
			InitializeComponent ();
            BindingContext = new QuestionThreadPageModel();
		}
        protected async override void OnAppearing()
        {
            BindingContext = await QuestionThreadPageModel.Update();
        }

        

	}
}