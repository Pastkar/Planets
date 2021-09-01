using PlanetsApi.Models;
using PlanetsApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanetsApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageModel();
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var planetDetalis = e.Item as Result;
            await Navigation.PushModalAsync(new InformationPage(planetDetalis.name,planetDetalis.climate));

        }
    }
}