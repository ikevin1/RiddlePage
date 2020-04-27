using RiddleMe.Data;
using RiddleMe.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiddleMe
{
    public partial class App : Application
    {
        static RiddleItemDatabase database;
        public App()
        {
            InitializeComponent();


            var nav = new NavigationPage(new RiddleListPage());

            //nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];

            nav.BarBackgroundColor = Color.DarkRed;

            nav.BarTextColor = Color.White;



            MainPage = nav;
            //MainPage = new MainPage();
        }

        public static RiddleItemDatabase Database

        {

            get

            {

                if (database == null)

                {

                    database = new RiddleItemDatabase();

                }

                return database;

            }

        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
