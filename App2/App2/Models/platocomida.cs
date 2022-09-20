using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class platocomida
    {
        public int idplato { get; set; }
        public string nombre_plato { get; set; }
        public int precio { get; set; }
        public int descuento { get; set; }

        public string toJson()
        {
            return "{\"idplato\":\"" + idplato + " \",\"nombre_plato\":\"" + nombre_plato + " \",\"precio\": \"" + precio + "\" , \"descuento\":\"" + descuento + "\" }";

        }
    }
}
