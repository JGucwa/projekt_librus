using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using Xamarin.Essentials;

namespace projekt_librus.Views
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string db)
        {
            _database = new SQLiteAsyncConnection(db);
            _database.CreateTableAsync<Uzytkownik>().Wait();
            _database.CreateTableAsync<Ocena>().Wait();
            _database.CreateTableAsync<Przedmiot>().Wait();
        }

        public Task<int> DodajUzytkownika(Uzytkownik uzytkownik)
        {
            return _database.InsertAsync(uzytkownik);
        }

        public Task<List<Uzytkownik>> WszyscyUzytkownicy()
        {
            return _database.QueryAsync<Uzytkownik>("SELECT * FROM Uzytkownik");
        }

        public Task<List<Uzytkownik>> WszyscyUzytkownicyFilter(string login, string haslo)
        {
            return _database.QueryAsync<Uzytkownik>("SELECT * FROM Uzytkownik WHERE Login=? AND Haslo=?", login, haslo);
        }

        public Task<List<Przedmiot>> WszystkiePrzedmioty()
        {
            return _database.QueryAsync<Przedmiot>("SELECT * FROM Przedmiot");
        }

        public Task<List<Ocena>> WszystkieOceny()
        {
            return _database.QueryAsync<Ocena>("SELECT * FROM Ocena");
        }

        public Task<int> DodajPrzedmiot(Przedmiot przedmiot)
        {
            return _database.InsertAsync(przedmiot);
        }

        public Task<int> DodajOcene(Ocena ocena)
        {
            return _database.InsertAsync(ocena);
        }

        public Task<List<Ocena>> WszystkieOcenyFiltrowane(int uzytkownik_id, int przedmiot_id, string okres)
        {
            return _database.QueryAsync<Ocena>("SELECT * FROM Ocena WHERE Uzytkownik_id=? AND Przedmiot_id=? AND Okres=?", uzytkownik_id, przedmiot_id, okres);
        }
    }
}
