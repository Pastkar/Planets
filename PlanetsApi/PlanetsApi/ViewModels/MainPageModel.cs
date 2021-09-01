using MonkeyCacheExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace PlanetsApi.ViewModels
{
    public class MainPageModel : BaseViewModel
    {
        public List<Person> numbers { get; set; }
        public MainPageModel() {
            numbers = new List<Person>() {
                new Person() { name = "1" },
                new Person() { name = "2" },
                new Person() { name = "3" },
                new Person() { name = "4" }};
            test();
            
        }
        public async void test()
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
                var test = true;
            }
        }
    }
    public class Person
    {
        public string name { get; set; }
    }
}
