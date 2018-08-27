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
        private MsgModel _message;
		public QuestionThreadPage (MsgModel message)
		{
            Log.Info("QADEBUG", "QuestionThreadPagen konstruktori käynnistyi");
			InitializeComponent ();
            _message = message;
            BindingContext = new QuestionThreadPageModel(message);
            Log.Info("QADEBUG", $"QuestionThreadPagen konstruktori valmistui");





        }
        protected async override void OnAppearing()
        {
            Log.Info("QADEBUG", "Question Thread Pagen OnAppearing käynnistyi!");
            BindingContext = await QuestionThreadPageModel.Update(_message);
            Log.Info("QADEBUG", "Question Thread Pagen OnAppearing valmistui!");

        }



    }
}