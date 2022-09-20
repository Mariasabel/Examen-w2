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
    public partial class GetIngredientes : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/ingredientes";
        
        public GetIngredientes()
        {
            InitializeComponent();
            getIngrediente();
        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
            getIngrediente();
        }

       

        private async Task getIngrediente()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<ingredientes> contenido = JsonConvert.DeserializeObject<List<ingredientes>>(content);

                    string tempRes = "";

                    for (int i = 0; i <contenido.Count; i++ )
                    {
                        tempRes = tempRes + "id: " + contenido[i].idingrediente + " nombre: " + contenido[i].nombre + "\n"+ "\n";
                    }

                    resultado.Text = tempRes;
                }else
                {
                    resultado.Text = "Carga fallida de ingredientes";
                }

            }

        }

    }
}