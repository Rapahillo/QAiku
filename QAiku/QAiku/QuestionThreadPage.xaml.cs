using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.ViewModel;
using Android.Util;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QAiku
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestionThreadPage : ContentPage
	{
		public QuestionThreadPage ()
		{
            Log.Info("QTP", "QuestionThreadPagen konstruktori käynnistyi");
			InitializeComponent ();
            BindingContext = new QuestionThreadPageModel();
            Log.Info("QTP", $"QuestionThreadPagen konstruktori valmistui");





        }
        protected async override void OnAppearing()
        {
            Log.Info("QTP", "Question Thread Pagen OnAppearing käynnistyi!");
            BindingContext = await QuestionThreadPageModel.Update();
            Log.Info("QTP", "Question Thread Pagen OnAppearing valmistui!");
            Log.Info("QTP", BindingContext.ToString());

        }



    }
}