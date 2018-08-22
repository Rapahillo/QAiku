using Android.Content;
using Android.Preferences;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QAiku
{
    public partial class App : Application
    {
        public App()
        {
            //ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Context context);
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new LoginPage());

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
