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
    public partial class PutReceta : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/receta";
        public PutReceta()
        {
            InitializeComponent();
        }


        private async Task actualizarRecetaAsync()
        {
            using (var httpClient = new HttpClient())
            {
                receta x = new receta()
                {
                    id_receta = int.Parse(id_recetaform.Text),
                    cantidad = int.Parse(cantidadform.Text),
                    idplato = int.Parse(idplatoform.Text),
                    idingrediente = int.Parse(idingredienteform.Text),
                    id_unidad = int.Parse(id_unidadform.Text),
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

                cantidadform.Text = "";
                idplatoform.Text = "";
                idingredienteform.Text = "";
                id_unidadform.Text = "";

            }
        }


        private void id_recetaform_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarRecetaAsync();
        }
    }
}