using SQLite;

namespace Paises.Models
{
    public class Country
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Status { get; set; }
        public string Willy_Corrales { get; set; }
    }
}
