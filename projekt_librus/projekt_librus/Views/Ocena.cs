using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_librus.Views
{
    public class Ocena
    {
        [PrimaryKey, AutoIncrement]
        public int Ocena_Id { get; set; }    
        public int Uzytkownik_id { get; set; }    
        public int Przedmiot_Id { get; set; }    
        public float Stopien { get; set; }    
        public DateTime Data {  get; set; }
        public string Opis {  get; set; }
        public int Okres {  get; set; }
    }
}
