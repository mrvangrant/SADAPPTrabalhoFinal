using System;
using APPInterfaceSAD.Data;
using System.Data;
using System.Data.SqlClient;
using APPInterfaceSAD.Models;

namespace APPInterfaceSAD.Services
{
    internal class VeiculoService
    {
        public DataTable ObterVeiculos()
        {
            string sql =
                "SELECT v.Vid, v.NomeVeiculo, v.lotacao, v.tara, v.Rua, v.Estado, " +
                "       v.CP AS CP, " + // show CP in grid
                "       c.DesClasse AS Classe, m.DescModelo AS Modelo, cp.Localidade AS Localidade " +
                "FROM Veiculo v " +
                "INNER JOIN Classe c ON v.Cid = c.Cid " +
                "INNER JOIN Modelo m ON v.ModID = m.ModID " +
                "INNER JOIN CodigoPostal cp ON v.CPCP = cp.CP";

            using (SqlConnection con = new SqlConnection(Database.ConnectionString))
            {
                var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void InserirVeiculo(string nomeVeiculo, int? lotacao, int? tara, int? cp, string rua,
            string estado, int cid, int modId, int cpcp)
        {
            const string sql =
                "INSERT INTO Veiculo (NomeVeiculo, lotacao, tara, CP, Rua, Estado, Cid, ModID, CPCP) " +
                "VALUES (@NomeVeiculo, @lotacao, @tara, @CP, @Rua, @Estado, @Cid, @ModID, @CPCP)";

            using (SqlConnection con = new SqlConnection(Database.ConnectionString))
            {
                con.Open();
                // validate foreign keys
                ValidateForeignKeys(con, cid, modId, cpcp);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@NomeVeiculo", (object)nomeVeiculo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@lotacao", (object)lotacao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tara", (object)tara ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CP", (object)cp ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Rua", (object)rua ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", (object)estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cid", cid);
                    cmd.Parameters.AddWithValue("@ModID", modId);
                    cmd.Parameters.AddWithValue("@CPCP", cpcp);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // New: strongly-typed insert that returns the new Vid
        public int InserirVeiculo(Veiculo v)
        {
            if (v == null) throw new ArgumentNullException(nameof(v));

            const string sql =
                "INSERT INTO Veiculo (NomeVeiculo, lotacao, tara, CP, Rua, Estado, Cid, ModID, CPCP) " +
                "OUTPUT INSERTED.Vid " +
                "VALUES (@NomeVeiculo, @lotacao, @tara, @CP, @Rua, @Estado, @Cid, @ModID, @CPCP)";

            using (SqlConnection con = new SqlConnection(Database.ConnectionString))
            {
                con.Open();
                // validate foreign keys
                ValidateForeignKeys(con, v.Cid, v.ModID, v.CPCP);

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@NomeVeiculo", (object)v.NomeVeiculo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@lotacao", (object)v.Lotacao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tara", (object)v.Tara ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CP", (object)v.CP ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Rua", (object)v.Rua ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", (object)v.Estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cid", v.Cid);
                    cmd.Parameters.AddWithValue("@ModID", v.ModID);
                    cmd.Parameters.AddWithValue("@CPCP", v.CPCP);

                    var newId = (int)cmd.ExecuteScalar();
                    return newId;
                }
            }
        }

        public DataTable ObterModelos()
        {
            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter("SELECT ModID, DescModelo FROM Modelo", con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObterClasses()
        {
            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter("SELECT Cid, DesClasse FROM Classe", con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObterCodigosPostais()
        {
            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter("SELECT CP, Localidade FROM CodigoPostal", con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AtualizarVeiculo(Veiculo v)
        {
            if (v == null) throw new ArgumentNullException(nameof(v));
            if (v.Vid <= 0) throw new ArgumentException("Invalid vehicle ID.", nameof(v));

            const string sql =
                "UPDATE Veiculo SET NomeVeiculo=@NomeVeiculo, lotacao=@lotacao, tara=@tara, CP=@CP, Rua=@Rua, Estado=@Estado, " +
                "Cid=@Cid, ModID=@ModID, CPCP=@CPCP WHERE Vid=@Vid";

            using (var con = new SqlConnection(Database.ConnectionString))
            {
                con.Open();
                // validate foreign keys
                ValidateForeignKeys(con, v.Cid, v.ModID, v.CPCP);

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Vid", v.Vid);
                    cmd.Parameters.AddWithValue("@NomeVeiculo", (object)v.NomeVeiculo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@lotacao", (object)v.Lotacao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tara", (object)v.Tara ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CP", (object)v.CP ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Rua", (object)v.Rua ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", (object)v.Estado ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cid", v.Cid);
                    cmd.Parameters.AddWithValue("@ModID", v.ModID);
                    cmd.Parameters.AddWithValue("@CPCP", v.CPCP);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void ValidateForeignKeys(SqlConnection con, int cid, int modId, int cpcp)
        {
            if (cid <= 0) throw new InvalidOperationException("Classe inválida.");
            if (modId <= 0) throw new InvalidOperationException("Modelo inválido.");
            if (cpcp <= 0) throw new InvalidOperationException("Código Postal inválido.");

            using (var cmd = new SqlCommand("SELECT COUNT(1) FROM Classe WHERE Cid=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", cid);
                if ((int)cmd.ExecuteScalar() == 0)
                    throw new InvalidOperationException("Classe não existe.");
            }
            using (var cmd = new SqlCommand("SELECT COUNT(1) FROM Modelo WHERE ModID=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", modId);
                if ((int)cmd.ExecuteScalar() == 0)
                    throw new InvalidOperationException("Modelo não existe.");
            }
            using (var cmd = new SqlCommand("SELECT COUNT(1) FROM CodigoPostal WHERE CP=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", cpcp);
                if ((int)cmd.ExecuteScalar() == 0)
                    throw new InvalidOperationException("Código Postal não existe.");
            }
        }
    }
}
