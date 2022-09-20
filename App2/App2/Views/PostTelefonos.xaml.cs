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
    public partial class PostTelefonos : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/telefonos";
        public PostTelefonos()
        {
            InitializeComponent();
        }

        private async Task postTelefonos()
        {
            using (var httpClient = new HttpClient())
            {
                telefonos x = new telefonos()
                {
                    telefono = telefonoform.Text,
                    id_proveedor = int.Parse(id_proveedorform.Text),
                    

                };

                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    telefonos contenido = JsonConvert.DeserializeObject<telefonos>(content);
                    resultado.Text = "telefono creado: " + contenido.telefono;

                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                telefonoform.Text = "";
                id_proveedorform.Text = "";
            }
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            postTelefonos();
        }
    }
}