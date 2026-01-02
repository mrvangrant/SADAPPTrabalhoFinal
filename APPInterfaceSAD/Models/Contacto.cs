using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    public class Contacto
    {
        public int ContactoId { get; set; }
        public int ClienteId { get; set; }
        public string Tipo { get; set; } = "";
        public string Valor { get; set; } = "";
    }
}
