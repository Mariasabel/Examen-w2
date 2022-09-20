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
    public partial class PostPlatocomida : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/platocomida";
        public PostPlatocomida()
        {
            InitializeComponent();
        }

        private async Task postPlatocomida()
        {
            using (var httpClient = new HttpClient())
            {
                platocomida x = new platocomida()
                {
                    nombre_plato = nombre_platoform.Text,
                    precio = int.Parse(precioform.Text),
                    descuento = int.Parse(descuentoform.Text)
                };

                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    platocomida contenido = JsonConvert.DeserializeObject<platocomida>(content);
                    resultado.Text = "Plato creado: " + contenido.nombre_plato;

                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombre_platoform.Text = "";
                precioform.Text = "";
                descuentoform.Text = "";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            postPlatocomida();
        }
    }
}