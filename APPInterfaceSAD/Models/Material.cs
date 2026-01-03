using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    public class Material
    {
        public int MatID { get; set; }
        public string DescMat { get; set; } = string.Empty;
        public int TMID { get; set; } // FK to TipoMaterial
    }
}
