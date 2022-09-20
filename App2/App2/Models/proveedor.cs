using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class proveedor
    {
        public int id_proveedor { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }

        public string toJson()
        {

            return "{\"id_proveedor\":\"" + id_proveedor + " \",\"nombre\":\"" + nombre + " \",\"correo\": \"" + correo + "\" }";

        }
    }
}
