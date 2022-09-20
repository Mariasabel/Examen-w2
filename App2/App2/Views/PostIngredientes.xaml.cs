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
    public partial class PostIngredientes : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/ingredientes";
        public PostIngredientes()
        {
            InitializeComponent();
        }

        private async Task postIngrediente()
        {
            using (var httpClient = new HttpClient())
            {
                ingredientes x = new ingredientes()
                {
                    nombre = nombreform.Text,
                    precio = int.Parse(precioform.Text),
                    id_proveedor = int.Parse(id_proveedorform.Text)
                };

                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ingredientes contenido = JsonConvert.DeserializeObject<ingredientes>(content);
                    resultado.Text = "Ingrediente creado: " + contenido.nombre;
                
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreform.Text = "";
                precioform.Text = "";
                id_proveedorform.Text = "";
            }
        }



        private void Button_Clicked(object sender, EventArgs e)
        {
            postIngrediente();
        }
    }
}