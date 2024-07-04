using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Paises.Models;

namespace Paises.Repositories
{
    public class CountryRepository
    {
        private readonly SQLiteConnection _database;

        public CountryRepository(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Country>();
        }

        public List<Country> GetCountries()
        {
            return _database.Table<Country>().ToList();
        }

        public void AddCountry(Country country)
        {
            _database.Insert(country);
        }

        public void UpdateCountry(Country country)
        {
            _database.Update(country);
        }

        public void DeleteCountry(Country country)
        {
            _database.Delete(country);
        }
    }
}
