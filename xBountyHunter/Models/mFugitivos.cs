using System;
using SQLite;

namespace xBountyHunter.Models
{
    public class mFugitivos
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name{ get; set; }
        public bool Capturado { get; set; }
        public string Photo { get; set; }
    }
}
