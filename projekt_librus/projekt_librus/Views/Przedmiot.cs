using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_librus.Views
{
    public class Przedmiot
    {
        [PrimaryKey,AutoIncrement]
        public int Przedmiot_id { get; set; }
        public string Nazwa { get; set; }
    }
}
