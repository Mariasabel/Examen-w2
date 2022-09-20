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
    public partial class PostUnidadmedida : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/unidadmedida";
        public PostUnidadmedida()
        {
            InitializeComponent();
        }

        private async Task postUnidadmedida()
        {
            using (var httpClient = new HttpClient())
            {
                unidadmedida x = new unidadmedida()
                {
                    nombre = nombreform.Text,
                    abreviacion = abreviacionform.Text,

                };

                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    unidadmedida contenido = JsonConvert.DeserializeObject<unidadmedida>(content);
                    resultado.Text = "unidad de medida creada: " + contenido.nombre;

                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreform.Text = "";
                abreviacionform.Text = "";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            postUnidadmedida();
        }
    }
}