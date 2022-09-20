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
    public partial class GetTelefonos : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/telefonos";
        public GetTelefonos()
        {
            InitializeComponent();
            getTelefonos();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            getTelefonos();
        }

        private async Task getTelefonos()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<telefonos> contenido = JsonConvert.DeserializeObject<List<telefonos>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {
                        tempRes = tempRes + "id: " + contenido[i].id_telefono + " Telefono: " + contenido[i].telefono + "\n" + "\n";
                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga fallida de telefonos";
                }

            }

        }
    }
}