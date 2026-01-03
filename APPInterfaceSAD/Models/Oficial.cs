using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    public class Oficial
    {
        public int OficialID { get; set; }
        public string NomeOficial { get; set; } = string.Empty;
        public int CargoID { get; set; } // FK to Cargo
    }
}
