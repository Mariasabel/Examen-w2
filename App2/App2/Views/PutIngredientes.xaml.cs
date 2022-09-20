using App2.Models;
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
    public partial class PutIngredientes : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/ingredientes";

        public PutIngredientes()
        {
            InitializeComponent();
        }

        private async Task actualizarIngredientesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                ingredientes x = new ingredientes()
                {
                    idingrediente = int.Parse(idingredienteform.Text),
                    nombre = nombreform.Text,
                    precio = int.Parse(precioform.Text),
                    id_proveedor = int.Parse(id_proveedorform.Text)
                };
                url = url + "/" + x.idingrediente;
                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actualizacion Excitosa";

                }
                else
                {
                    resultado.Text = "Actualizacion Fallida";
                }

                nombreform.Text = "";
                precioform.Text = "";
                id_proveedorform.Text = "";

            }
        }

        private void idingredienteform_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarIngredientesAsync();
        }
    }
}