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
    public partial class PutPlatocomida : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/platocomida";
        public PutPlatocomida()
        {
            InitializeComponent();
        }

        private async Task actualizarPlatocomidaAsync()
        {
            using (var httpClient = new HttpClient())
            {
                platocomida x = new platocomida()
                {
                    idplato = int.Parse(idplatoform.Text),
                    nombre_plato = nombre_platoform.Text,
                    precio = int.Parse(precioform.Text),
                    descuento = int.Parse(descuentoform.Text)
                };
                url = url + "/" + x.idplato;
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

                nombre_platoform.Text = "";
                precioform.Text = "";
                descuentoform.Text = "";

            }
        }



        private void idplatoform_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarPlatocomidaAsync();
        }
    }
}