using APPInterfaceSAD.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPInterfaceSAD.Services
{
    public class ClienteService : IClienteService
    {
        public void InserirClienteContacto(
            string nome, string nif, string tipo, string valor)
        {
            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlCommand cmd =
                    new SqlCommand("sp_InserirClienteContacto", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@NIF", nif);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@Valor", valor);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObterClientes()
        {
            string sql =
                "SELECT c.ClienteId, c.Nome, c.NIF, " +
                "ct.Tipo, ct.Valor " +
                "FROM Cliente c " +
                "INNER JOIN Contacto ct ON c.ClienteId = ct.ClienteId";

            using (SqlConnection con =
                new SqlConnection(Database.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

}
