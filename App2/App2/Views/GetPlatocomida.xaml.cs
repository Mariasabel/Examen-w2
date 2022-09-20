using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetPlatocomida : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/platocomida";
        public GetPlatocomida()
        {
            InitializeComponent();
            getPlatocomida();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            getPlatocomida();
        }

        private async Task getPlatocomida()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<platocomida> contenido = JsonConvert.DeserializeObject<List<platocomida>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {
                        tempRes = tempRes + "id: " + contenido[i].idplato + " nombre: " + contenido[i].nombre_plato + "\n" + "\n";
                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga fallida de platillos";
                }

            }

        }
    }
}