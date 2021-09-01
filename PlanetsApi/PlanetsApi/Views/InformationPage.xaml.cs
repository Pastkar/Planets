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
    public partial class InformationPage : ContentPage
    {
        public InformationPage(string Name, string Climate)
        {
            InitializeComponent();
            NamePlanet.Text = Name;
            this.Climate.Text = Climate;
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}