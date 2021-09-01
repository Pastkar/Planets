using MonkeyCacheExample.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlanetsApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlanetsApi.ViewModels
{
    public class MainPageModel : BaseViewModel
    {
        public Root allInformation { get; set; }
        private ObservableCollection<Result> films;

        public ObservableCollection<Result> Films
        {
            get { return films; }
            private set
            {
                films = value;
                NotyfyPropertyChanged("Films");
            }
        }
        public MainPageModel() { 
            DowmloadAndParse();
        }
        public async void DowmloadAndParse()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://swapi.dev/api/planets/?format=json");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                allInformation = JsonConvert.DeserializeObject<Root>(json);
                Films = allInformation.results;
            }
        }
    }
}
