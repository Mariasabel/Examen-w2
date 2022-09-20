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
    public partial class PostProveedor : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/proveedor";
        public PostProveedor()
        {
            InitializeComponent();
        }

        private async Task postProveedor()
        {
            using (var httpClient = new HttpClient())
            {
                proveedor x = new proveedor()
                {
                    nombre = nombreform.Text,
                    correo = correoform.Text,
                   
                };

                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    proveedor contenido = JsonConvert.DeserializeObject<proveedor>(content);
                    resultado.Text = "Proveedor creado: " + contenido.nombre;

                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreform.Text = "";
                correoform.Text = "";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            postProveedor();
        }
    }
}