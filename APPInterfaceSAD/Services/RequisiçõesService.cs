using System;
using System.Data;
using System.Data.SqlClient;
using APPInterfaceSAD.Data;

namespace APPInterfaceSAD.Services
{
    internal class RequisicoesService
    {
        // List joined requisitions with readable names
        public DataTable ObterRequisicoes()
        {
            const string sql =
                "SELECT r.ReqID, r.DataReq, r.CondutorID, r.Vid, r.OficialID, " +
                "       c.NomeCondutor AS Condutor, v.NomeVeiculo AS Veiculo, o.NomeOficial AS Oficial " +
                "FROM Requisicoes r " +
                "INNER JOIN Condutor c ON r.CondutorID = c.CondutorID " +
                "INNER JOIN Veiculo v ON r.Vid = v.Vid " +
                "INNER JOIN Oficial o ON r.OficialID = o.OficialID";

            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lightweight sources for UI combos
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

        public DataTable ObterCondutores()
        {
            const string sql = "SELECT CondutorID, NomeCondutor FROM Condutor";
            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObterOficiais()
        {
            const string sql = "SELECT OficialID, NomeOficial FROM Oficial";
            using (var con = new SqlConnection(Database.ConnectionString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Create
        public int InserirRequisicao(DateTime? dataReq, int condutorId, int vid, int oficialId)
        {
            const string sql =
                "INSERT INTO Requisicoes (DataReq, CondutorID, Vid, OficialID) " +
                "OUTPUT INSERTED.ReqID VALUES (@DataReq, @CondutorID, @Vid, @OficialID)";

            using (var con = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                ValidateFks(con, condutorId, vid, oficialId);

                cmd.Parameters.AddWithValue("@DataReq", (object)dataReq ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CondutorID", condutorId);
                cmd.Parameters.AddWithValue("@Vid", vid);
                cmd.Parameters.AddWithValue("@OficialID", oficialId);

                return (int)cmd.ExecuteScalar();
            }
        }

        // Update
        public void AtualizarRequisicao(int reqId, DateTime? dataReq, int condutorId, int vid, int oficialId)
        {
            if (reqId <= 0) throw new ArgumentException("ReqID inválido.", nameof(reqId));

            const string sql =
                "UPDATE Requisicoes SET DataReq=@DataReq, CondutorID=@CondutorID, Vid=@Vid, OficialID=@OficialID " +
                "WHERE ReqID=@ReqID";

            using (var con = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                if (!Exists(con, "SELECT COUNT(1) FROM Requisicoes WHERE ReqID=@id", reqId))
                    throw new InvalidOperationException("Requisição não existe.");
                ValidateFks(con, condutorId, vid, oficialId);

                cmd.Parameters.AddWithValue("@ReqID", reqId);
                cmd.Parameters.AddWithValue("@DataReq", (object)dataReq ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CondutorID", condutorId);
                cmd.Parameters.AddWithValue("@Vid", vid);
                cmd.Parameters.AddWithValue("@OficialID", oficialId);

                cmd.ExecuteNonQuery();
            }
        }

        // Optional: Delete
        public void ApagarRequisicao(int reqId)
        {
            if (reqId <= 0) throw new ArgumentException("ReqID inválido.", nameof(reqId));

            const string sql = "DELETE FROM Requisicoes WHERE ReqID=@ReqID";

            using (var con = new SqlConnection(Database.ConnectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@ReqID", reqId);
                cmd.ExecuteNonQuery();
            }
        }

        // FK validation helpers
        private static void ValidateFks(SqlConnection con, int condutorId, int vid, int oficialId)
        {
            if (condutorId <= 0 || !Exists(con, "SELECT COUNT(1) FROM Condutor WHERE CondutorID=@id", condutorId))
                throw new InvalidOperationException("Condutor inválido.");
            if (vid <= 0 || !Exists(con, "SELECT COUNT(1) FROM Veiculo WHERE Vid=@id", vid))
                throw new InvalidOperationException("Veículo inválido.");
            if (oficialId <= 0 || !Exists(con, "SELECT COUNT(1) FROM Oficial WHERE OficialID=@id", oficialId))
                throw new InvalidOperationException("Oficial inválido.");
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