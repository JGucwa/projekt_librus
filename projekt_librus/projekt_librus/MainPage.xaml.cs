using projekt_librus.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace projekt_librus
{
    public partial class MainPage : TabbedPage
    {
        Uzytkownik uzytkownik;
        public MainPage(Uzytkownik uzytkownik)
        {
            InitializeComponent();
            this.uzytkownik = uzytkownik;
            //dodaj();
            UploadData();
        }

        public async void Dodaj_Ocene(object s,EventArgs e)
        {
            Ocena o = new Ocena()
            {
                Uzytkownik_id = 0,
                Przedmiot_Nazwa = P_Stopien.SelectedItem.ToString(),
                Stopien = P_Stopien.SelectedItem.ToString(),
                Data = DateTime.Now,
                Opis = E_Opis.Text,
                Okres = "Okres 1"
            };
            await App.Database.DodajOcene(o);

            P_Stopien.SelectedItem = 0;
            P_Stopien.SelectedItem = 0;
            E_Opis.Text = String.Empty;

            UploadData();
        }

        public async void UploadData()
        {
            LV_WynikiUzytkownika.ItemsSource = await App.Database.WszystkieOceny();

            List<List<string>> okres1_wynik = new List<List<string>>();
            List<List<string>> okres2_wynik = new List<List<string>>();

            var przedmioty = await App.Database.WszystkiePrzedmioty();
            foreach (var przedmiot in przedmioty)
            {
                List<string> row = new List<string>();

                var wynikiOkres1 = await App.Database.WszystkieOcenyFiltrowane(this.uzytkownik.Id, przedmiot.Nazwa, "Okres 1");
                string wynikiOkres1Text = "";
                foreach (var wynik in wynikiOkres1)
                {
                    wynikiOkres1Text += wynik.Stopien + " ";
                }
                row.Add(wynikiOkres1Text);
                row.Add(przedmiot.Nazwa);

                okres1_wynik.Add(row);
            }

            foreach (var przedmiot in przedmioty)
            {
                List<string> row = new List<string>();

                var wynikiOkres2 = await App.Database.WszystkieOcenyFiltrowane(this.uzytkownik.Id, przedmiot.Nazwa, "Okres 2");
                string wynikiOkres2Text = "";
                foreach (var wynik in wynikiOkres2)
                {
                    wynikiOkres2Text += wynik.Stopien + " ";
                }
                row.Add(wynikiOkres2Text);
                row.Add(przedmiot.Nazwa);

                okres2_wynik.Add(row);
            }

            LV_Uzytkownik_Okres1.ItemsSource = okres1_wynik;
            LV_Uzytkownik_Okres2.ItemsSource = okres2_wynik;
        }
    }
}
