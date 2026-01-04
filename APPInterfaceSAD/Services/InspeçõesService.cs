using System;
using System.Data;
using System.Data.SqlClient;
using APPInterfaceSAD.Data;

namespace APPInterfaceSAD.Services
{
    internal class InspeçõesService
    {
        // List inspections with readable names
        public DataTable ObterInspecoes()
        {
            const string sql =
                "SELECT i.InspID, i.InspID AS InsID, i.DataInsp, i.Vid, i.MatID, i.MatID AS MaterialID, " +
                "v.NomeVeiculo AS Veiculo, m.DescMat AS Material " +
                "FROM Inspecoes i " +
                "INNER JOIN Veiculo v ON i.Vid = v.Vid " +
                "INNER JOIN Material m ON i.MatID = m.MaterialID";

            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Combos
        public DataTable ObterVeiculosLite()
        {
            const string sql = "SELECT Vid, NomeVeiculo FROM Veiculo";
            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObterMateriais()
        {
            const string sql = "SELECT MaterialID, DescMat FROM Material";
            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Create
        public int InserirInspecao(DateTime? dataInsp, int vid, int materialId)
        {
            const string sql =
                "INSERT INTO Inspecoes (DataInsp, Vid, MatID) " +
                "OUTPUT INSERTED.InspID VALUES (@DataInsp, @Vid, @MatID)";

            using (var con = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                ValidateFks(con, vid, materialId);

                cmd.Parameters.AddWithValue("@DataInsp", (object)dataInsp ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Vid", vid);
                cmd.Parameters.AddWithValue("@MatID", materialId);

                return (int)cmd.ExecuteScalar();
            }
        }

        private static void ValidateFks(SqlConnection con, int vid, int materialId)
        {
            if (vid <= 0 || !Exists(con, "SELECT COUNT(1) FROM Veiculo WHERE Vid=@id", vid))
                throw new InvalidOperationException("Veículo inválido.");
            if (materialId <= 0 || !Exists(con, "SELECT COUNT(1) FROM Material WHERE MaterialID=@id", materialId))
                throw new InvalidOperationException("Material inválido.");
        }

        private static bool Exists(SqlConnection con, string sql, int id)
        {
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
