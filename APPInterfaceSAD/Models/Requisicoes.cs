using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    public class Requisicoes
    {
        public int ReqID { get; set; }
        public System.DateTime? DataReq { get; set; }
        public int CondutorID { get; set; } // FK to Condutor
        public int Vid { get; set; } // FK to Veiculo
        public int OficialID { get; set; } // FK to Oficial
    }
}
