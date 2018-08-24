using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.ViewModel;
using Android.Util;
using QAiku.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QAiku
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestionThreadPage : ContentPage
	{
		public QuestionThreadPage ()
		{
            Log.Info("QADEBUG", "QuestionThreadPagen konstruktori käynnistyi");
			InitializeComponent ();
            BindingContext = new QuestionThreadPageModel();
            Log.Info("QADEBUG", $"QuestionThreadPagen konstruktori valmistui");





        }
        protected async override void OnAppearing()
        {
            Log.Info("QADEBUG", "Question Thread Pagen OnAppearing käynnistyi!");
            BindingContext = await QuestionThreadPageModel.Update();
            Log.Info("QADEBUG", "Question Thread Pagen OnAppearing valmistui!");

        }



    }
}