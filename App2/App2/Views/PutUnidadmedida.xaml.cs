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
    public partial class PutUnidadmedida : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/unidadmedida";
        public PutUnidadmedida()
        {
            InitializeComponent();
        }

        private async Task actualizarUnidadmedidaAsync()
        {
            using (var httpClient = new HttpClient())
            {
                unidadmedida x = new unidadmedida()
                {
                    id_unidad = int.Parse(id_unidadform.Text),
                    nombre = nombreform.Text,
                    abreviacion = abreviacionform.Text,
                };
                url = url + "/" + x.id_unidad;
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
                abreviacionform.Text = "";

            }
        }


        private void id_unidadform_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarUnidadmedidaAsync();
        }
    }
}