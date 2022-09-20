using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class unidadmedida
    {
        public int id_unidad { get; set; }
        public string nombre { get; set; }
        public string abreviacion { get; set; }

        public string toJson()
        {

            return "{\"id_unidad\":\"" + id_unidad +" \",  \"nombre\":\"" + nombre + " \",\"abreviacion\": \"" + abreviacion + "\" }";
        }
    }
}
