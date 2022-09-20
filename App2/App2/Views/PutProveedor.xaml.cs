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
    public partial class PutProveedor : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/proveedor";

        public PutProveedor()
        {
            InitializeComponent();
        }

        private async Task actualizarProveedorAsync()
        {
            using (var httpClient = new HttpClient())
            {
                proveedor x = new proveedor()
                {
                    id_proveedor = int.Parse(id_proveedorform.Text),
                    nombre = nombreform.Text,
                    correo = correoform.Text,
                };
                url = url + "/" + x.id_proveedor;
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
                correoform.Text = "";

            }
        }

        private void id_proveedorform_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarProveedorAsync();
        }
    }
}