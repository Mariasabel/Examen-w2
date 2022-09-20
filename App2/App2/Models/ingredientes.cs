using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class ingredientes
    {
        public int idingrediente { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public int id_proveedor { get; set; }

        public string toJson()
        {
            return "{\"idingrediente\":\"" + idingrediente + " \",\"nombre\":\"" + nombre + " \",\"precio\": \"" + precio + "\" , \"id_proveedor\":\"" + id_proveedor + "\" }";

        }
    }
}
