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
    public partial class PostReceta : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/receta";
        public PostReceta()
        {
            InitializeComponent();
        }

        private async Task postReceta()
        {
            using (var httpClient = new HttpClient())
            {
                receta x = new receta()
                {
                    cantidad = int.Parse(cantidadform.Text),
                    idplato = int.Parse(idplatoform.Text),
                    idingrediente = int.Parse(idingredienteform.Text),
                    id_unidad = int.Parse(id_unidadform.Text),
                };

                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    receta contenido = JsonConvert.DeserializeObject<receta>(content);
                    resultado.Text = "Receta creada: " ;

                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                cantidadform.Text = "";
                idplatoform.Text = "";
                idingredienteform.Text = "";
                id_unidadform.Text = "";
            }
        }



        private void Button_Clicked(object sender, EventArgs e)
        {
            postReceta();
        }
    }
}