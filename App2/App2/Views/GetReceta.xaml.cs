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
    public partial class GetReceta : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/receta";
        public GetReceta()
        {
            InitializeComponent();
            getReceta();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            getReceta();
        }



        private async Task getReceta()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<receta> contenido = JsonConvert.DeserializeObject<List<receta>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {
                        tempRes = tempRes + "id: " + contenido[i].id_receta + " cantidad: " + contenido[i].cantidad + "\n" + "\n";
                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga fallida de Recetas";
                }

            }

        }

    }
}