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
    public partial class DeletePlatocomida : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/platocomida";
        public DeletePlatocomida()
        {
            InitializeComponent();
        }
        private async Task borrarPlatocomidaAsync()
        {
            using (var httpClient = new HttpClient())
            {
                url = url + "/" + idform.Text;

                var reponse = await httpClient.DeleteAsync(url);
                if (reponse.IsSuccessStatusCode)
                {
                    var content = await reponse.Content.ReadAsStringAsync();
                    platocomida contenido = JsonConvert.DeserializeObject<platocomida>(content);

                    resultado.Text = "plato Borrado ";

                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                idform.Text = "";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _ = borrarPlatocomidaAsync();
        }
    }
}