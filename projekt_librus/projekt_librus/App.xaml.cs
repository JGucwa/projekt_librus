using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using projekt_librus.Views;

namespace projekt_librus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Logowanie();
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
