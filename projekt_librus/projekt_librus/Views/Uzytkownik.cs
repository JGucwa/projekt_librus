using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_librus.Views
{
    public class Uzytkownik
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public bool isTeacher { get; set; }
    }
}
