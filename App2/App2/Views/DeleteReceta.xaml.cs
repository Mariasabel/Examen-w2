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
    public partial class DeleteReceta : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/receta";
        public DeleteReceta()
        {
            InitializeComponent();
        }


        private async Task borrarRecetaAsync()
        {
            using (var httpClient = new HttpClient())
            {
                url = url + "/" + id_recetaform.Text;

                var reponse = await httpClient.DeleteAsync(url);
                if (reponse.IsSuccessStatusCode)
                {
                    var content = await reponse.Content.ReadAsStringAsync();
                    receta contenido = JsonConvert.DeserializeObject<receta>(content);

                    resultado.Text = "receta Borrada";

                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                id_recetaform.Text = "";
            }
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            borrarRecetaAsync();
        }
    }
}