using System;
using System.Data;
using System.Data.SqlClient;
using APPInterfaceSAD.Data;

namespace APPInterfaceSAD.Services
{
    internal class InspeçõesService
    {
        // LISTAR INSPEÇÕES POR VEÍCULO (Stored Procedure)
        public DataTable ObterInspecoesPorVeiculo(int vid)
        {
            using (var con = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand("dbo.sp_InspecoesPorVeiculo", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Vid", vid);

                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // COMBO VEÍCULOS
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

        // COMBO MATERIAIS
        public DataTable ObterMateriais()
        {
            const string sql = "SELECT MatID, DescMat FROM Material";

            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // INSERIR INSPEÇÃO (sem ID de retorno; PK composta Vid+MatID)
        public void InserirInspecao(DateTime? dataInsp, int vid, int matId)
        {
            const string sql =
                "INSERT INTO Inspecoes (Vid, MatID, DataInsp) " +
                "VALUES (@Vid, @MatID, @DataInsp)";

            using (var con = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                ValidateFks(con, vid, matId);

                cmd.Parameters.AddWithValue("@Vid", vid);
                cmd.Parameters.AddWithValue("@MatID", matId);
                cmd.Parameters.AddWithValue("@DataInsp", (object)dataInsp ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        // VALIDAR FKs
        private static void ValidateFks(SqlConnection con, int vid, int matId)
        {
            if (!Exists(con, "SELECT COUNT(1) FROM Veiculo WHERE Vid=@id", vid))
                throw new InvalidOperationException("Veículo inválido.");

            if (!Exists(con, "SELECT COUNT(1) FROM Material WHERE MatID=@id", matId))
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