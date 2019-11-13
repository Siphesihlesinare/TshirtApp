using System;
using System.IO;
using TshirtApp;
using TshirtsApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtsApp
{
    public partial class App : Application
    {
        private static TshirtDatabase teesDatabase;

        public static TshirtDatabase Database
        {
            get
            {
                if (teesDatabase == null)
                    teesDatabase = new TshirtDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TShirt.db3"));

                return teesDatabase;

            }
        }

        public int ResumeAtTshirtsAppId { get; internal set; }

        public App()
        {
            InitializeComponent();

            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new ShirtListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
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
