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
    public partial class MsgItemView : ContentView
    {
        public MsgItemView()
        {
            Log.Info("QADEBUG", "MsgItemView konstruktori käynnistyi!");
            InitializeComponent();
            var msg = BindingContext as MsgModel;
            this.BindingContext = new MsgItemViewModel(msg);
            Log.Info("QADEBUG", "MsgItemView konstruktori valmistui");
        }

        private void ViewThreadButton_Clicked(object sender, EventArgs e)
        {
            Log.Info("QADEBUG", "MessageItemView Viewthreadbutton käynnistyi!");
            var item = sender as MsgModel;
            var question = item.BindingContext as MsgModel;
            Log.Info("QADEBUG", question.ToString());
            var nextPage = new QuestionThreadPage();
            Navigation.PushAsync(nextPage);
            Log.Info("QADEBUG", "MessageItemView Viewthreadbutton valmistui!");
        }
    }
    public class MessageItemCell : ViewCell
    {
        //Label SubjectLabel, SenderIdLabel, SendDateLabel;

        //public static readonly BindableProperty SubjectProperty = BindableProperty.Create("Subject", typeof(string), typeof(MessageItemCell), "Subject");
        //public static readonly BindableProperty SenderIdProperty = BindableProperty.Create("SenderId", typeof(string), typeof(MessageItemCell), "SenderId");
        //public static readonly BindableProperty SendDateProperty = BindableProperty.Create("SendDate", typeof(DateTime), typeof(MessageItemCell), "SendDate");
        //public static readonly BindableProperty MessageProperty = BindableProperty.Create("Message", typeof(MsgModel), typeof(MessageItemCell), "Message");

        //public string Subject { get { return (string)GetValue(SubjectProperty); } set { SetValue(SubjectProperty, value); } }
        //public string SenderId { get { return (string)GetValue(SenderIdProperty); } set { SetValue(SenderIdProperty, value); } }
        //public string SendDate { get { return (string)GetValue(SendDateProperty); } set { SetValue(SendDateProperty, value); } }
        //public string Message { get { return (string)GetValue(MessageProperty); } set { SetValue(MessageProperty, value); } }




        public MessageItemCell()
        {
            View = new MsgItemView();
        }
   
    }
}