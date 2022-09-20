using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class telefonos
    {
        public int id_telefono { get; set; }
        public string telefono { get; set; }
        public int id_proveedor { get; set; }

        public string toJson()
        {

            return "{\"id_telefono\":\"" + id_telefono + " \",\"telefono\":\"" + telefono + " \",\"id_proveedor\": \"" + id_proveedor + "\" }";
        }
    }
}
