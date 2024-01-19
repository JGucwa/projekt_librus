using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projekt_librus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logowanie : ContentPage
    {
        public Logowanie()
        {
            InitializeComponent();
        }
        private async void LogowaniePrzycisk(object sender, EventArgs e)
        {
            var uzytkownicy = await App.Database.WszyscyUzytkownicyFilter(login.Text, haslo.Text);
            if (login.Text.Length != 7 || uzytkownicy.Count == 0)
            {
                DisplayAlert("Blad", "Podano nieprawidlowe dane", "OK");
                return;
            }

            var uzytkownik = uzytkownicy.ElementAt(0);
            Navigation.PushAsync(new MainPage(uzytkownik));
        }
    }
}