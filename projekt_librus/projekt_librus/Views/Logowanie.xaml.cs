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
            //dodaj();
        }
        public async void dodaj()
        {
            Uzytkownik x = new Uzytkownik()
            {
                Imie = "Jakub",
                Nazwisko = "Gucwa",
                Login = "000002n",
                Haslo = "123",
                isTeacher = true
            };
            await App.Database.DodajUzytkownika(x);
            Przedmiot sbj = new Przedmiot()
            {
                Nazwa = "Programowanie"
            };
            await App.Database.DodajPrzedmiot(sbj);
            Ocena s = new Ocena()
            {
                Uzytkownik_id = 1,
                Przedmiot_Id = 1,
                Przedmiot_Nazwa = "Programowanie",
                Stopien = "4+",
                Data = DateTime.Now,
                Opis = "Sprawdzian",
                Okres = "Okres 1"
            };
            await App.Database.DodajOcene(s);
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