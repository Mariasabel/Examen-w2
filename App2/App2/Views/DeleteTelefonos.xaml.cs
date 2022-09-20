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
    public partial class DeleteTelefonos : ContentPage
    {
        private string url = "https://desfrlopez.me/maguilera/api/telefonos";
        public DeleteTelefonos()
        {
            InitializeComponent();
        }


        private async Task borrarTelefonosAsync()
        {
            using (var httpClient = new HttpClient())
            {
                url = url + "/" + id_telefonoform.Text;

                var reponse = await httpClient.DeleteAsync(url);
                if (reponse.IsSuccessStatusCode)
                {
                    var content = await reponse.Content.ReadAsStringAsync();
                    telefonos contenido = JsonConvert.DeserializeObject<telefonos>(content);

                    resultado.Text = "telefono Borrado ";

                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }

                id_telefonoform.Text = "";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            borrarTelefonosAsync();
        }
    }
}