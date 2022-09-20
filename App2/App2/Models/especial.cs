using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    internal class especial
    {
        public int id_receta { get; set; }
        public int cantidad { get; set; }
        public int idplato { get; set; }
        public int idingrediente { get; set; }
        public int id_unidad { get; set; }

        public string nombre { get; set; }

        public string toJson()
        {

            return "{\"id_receta\":\"" + id_receta + "\" , \"cantidad\": \"" + cantidad + "\" , \"idplato\":\"" + idplato + "\" , \"idingrediente\":\"" + idingrediente + "\", \"id_unidad\": \"" + id_unidad + "\", \"nombre_plato\": \"" + nombre + "\",  }";
        }
    }
}
