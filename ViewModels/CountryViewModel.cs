using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Input;
using Paises.Models;
using Paises.Repositories;
using System;

namespace Paises.ViewModels
{
    public class CountryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Country> Countries { get; set; }
        private CountryRepository _repository;
        private string _dbPath = "C:\\Users\\wilyc\\OneDrive\\Documentos\\- Yo\\UDLA\\Progra IV\\Proyectos\\Paises\\DB\\country.db3";

        public CountryViewModel()
        {
            _repository = new CountryRepository(_dbPath);
            Countries = new ObservableCollection<Country>(_repository.GetCountries());
        }

        public ICommand LoadCountriesCommand => new Command(LoadCountries);
        public ICommand UpdateStatusCommand => new Command<Country>(UpdateStatus);
        public ICommand DeleteCountryCommand => new Command<Country>(DeleteCountry);

        private async void LoadCountries()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://restcountries.com/v3.1/all");
            var countries = JsonSerializer.Deserialize<List<Country>>(response);

            Random random = new Random();

            foreach (var country in countries)
            {
                country.Willy_Corrales = "WC" + random.Next(1000, 2000);
                _repository.AddCountry(country);
                Countries.Add(country);
            }
        }

        private void UpdateStatus(Country country)
        {
            _repository.UpdateCountry(country);
        }

        private void DeleteCountry(Country country)
        {
            _repository.DeleteCountry(country);
            Countries.Remove(country);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
