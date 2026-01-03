using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    public class Contacto
    {
        public int OficialID { get; set; }
        public int TCID { get; set; } // FK to TipoContacto
        public int? NumeroC { get; set; }
    }
}
