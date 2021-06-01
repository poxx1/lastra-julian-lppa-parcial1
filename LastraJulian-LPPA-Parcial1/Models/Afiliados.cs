using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastraJulian_LPPA_Parcial1.Models
{
    public class Afiliados: IndentityBase
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string CUIT { get; set; }
        public int Telefono { get; set; }

        //Nombre de la bd Parcial
    }
}
