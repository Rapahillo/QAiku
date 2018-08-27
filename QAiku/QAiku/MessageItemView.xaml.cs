using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAiku.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QAiku.SharedFunctionalities;
using QAiku.ViewModel;
using Android.Util;

namespace QAiku
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageItemView : ContentView
    {
        public MessageItemView ()
        {
            Log.Info("QADEBUG", "MessageItemView konstruktori käynnistyi!");
            InitializeComponent ();
            var msg = BindingContext as MsgModel;
            this.BindingContext = new MessageItemViewModel(msg);
            Log.Info("QADEBUG", "MessageItemView konstruktori valmistui");
         
        }


        private void ViewThreadButton_Clicked(object sender, EventArgs e)
        {
            Log.Info("QADEBUG", "MessageItemView Viewthreadbutton käynnistyi!");
            var item = sender as MsgModel;
            var question = item.BindingContext as MsgModel;
            var nextPage = new QuestionThreadPage(question);
            Navigation.PushAsync(nextPage);
            Log.Info("QADEBUG", "MessageItemView Viewthreadbutton valmistui!");

        }

    }
    public class MessageItemCell : ViewCell
    {
        public MessageItemCell()
        {
            View = new MessageItemView();
        }
    }
}