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
    public partial class DeleteUnidadmedida : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/unidadmedida";

        public DeleteUnidadmedida()
        {
            InitializeComponent();
        }


        private async Task borrarUnidadmedidaAsync()
        {
            using (var httpClient = new HttpClient())
            {
                url = url + "/" + id_unidadform.Text;

                var reponse = await httpClient.DeleteAsync(url);
                if (reponse.IsSuccessStatusCode)
                {
                    var content = await reponse.Content.ReadAsStringAsync();
                    unidadmedida contenido = JsonConvert.DeserializeObject<unidadmedida>(content);

                    resultado.Text = "unidad Borrada ";

                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                id_unidadform.Text = "";
            }
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            borrarUnidadmedidaAsync();
        }
    }
}