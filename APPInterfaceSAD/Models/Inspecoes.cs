using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    public class Inspecoes
    {
        public int Vid { get; set; } // PK part, FK to Veiculo
        public int MatID { get; set; } // PK part, FK to Material
        public System.DateTime? DataInsp { get; set; }
    }
}
