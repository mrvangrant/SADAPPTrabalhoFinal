using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Models
{
    public class Habilitacao
    {
        public int Cid { get; set; } // PK part, FK to Classe
        public int CondutorID { get; set; } // PK part, FK to Condutor
        public System.DateTime? DataHab { get; set; }
    }
}
