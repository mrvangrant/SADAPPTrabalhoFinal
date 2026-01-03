namespace APPInterfaceSAD.Models
{
    public class Veiculo
    {
        public int Vid { get; set; }
        public string NomeVeiculo { get; set; } = "";
        public int? Lotacao { get; set; }
        public int? Tara { get; set; }
        public int? CP { get; set; }
        public string Rua { get; set; } = "";
        public string Estado { get; set; } = "";
        public int Cid { get; set; }      // FK to Classe
        public int ModID { get; set; }    // FK to Modelo
        public int CPCP { get; set; }     // FK to CodigoPostal (CP)
    }
}