using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    public class Modelo
    {
        public int ModID { get; set; }
        public string DescModelo { get; set; } = string.Empty;
        public int MaID { get; set; } // FK to Marca
    }
}
