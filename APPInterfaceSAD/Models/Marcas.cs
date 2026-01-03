using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    // This file was incorrectly duplicating Contacto. Rename to Marca and fix properties.
    public class Marca
    {
        public int MaID { get; set; }
        public string DescMarca { get; set; } = string.Empty;
    }
}
