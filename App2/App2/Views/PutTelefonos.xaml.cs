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
    public partial class PutTelefonos : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/telefonos";
        public PutTelefonos()
        {
            InitializeComponent();
        }


        private async Task actualizaTelefonosAsync()
        {
            using (var httpClient = new HttpClient())
            {
                telefonos x = new telefonos()
                {
                    id_telefono = int.Parse(id_telefonoform.Text),
                    telefono = telefonoform.Text,
                    id_proveedor = int.Parse(id_proveedorform.Text),
                    
                };
                url = url + "/" + x.id_telefono;
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

                telefonoform.Text = "";
                id_proveedorform.Text = "";

            }
        }


        private void id_telefonoform_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizaTelefonosAsync();
        }
    }
}