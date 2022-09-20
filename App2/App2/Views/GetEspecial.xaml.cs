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
    public partial class GetEspecial : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/consulta";
        public GetEspecial()
        {
            InitializeComponent();
           


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }





        private async Task getEspecialAsync()
        {
            using (var httpClient = new HttpClient())
            {
                url = url + "/" + id_ingredienteform.Text;
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List <especial> contenido = JsonConvert.DeserializeObject<List<especial>>(content);


                    string tempRes = "";
                   
                    for (int i = 0; i < contenido.Count; i++)
                    {
                        tempRes = tempRes +  " el plato con el id : " + contenido[i].idplato + " tiene: "+ contenido[i].nombre + "\n" + "\n" + "\n";
                    }

                    resultado.Text = tempRes;

                   
                }
                else
                {
                    resultado.Text = "Carga fallida de platos";
                }

                id_ingredienteform.Text = "";

            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            getEspecialAsync();
        }
    }
}