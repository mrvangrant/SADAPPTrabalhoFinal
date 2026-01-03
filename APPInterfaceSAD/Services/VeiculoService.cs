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
                "       c.DesClasse AS Classe, m.DescModelo AS Modelo, ma.DescMarca AS Marca, cp.Localidade AS Localidade " +
                "FROM Veiculo v " +
                "INNER JOIN Classe c ON v.Cid = c.Cid " +
                "INNER JOIN Modelo m ON v.ModID = m.ModID " +
                "INNER JOIN Marca ma ON m.MaID = ma.MaID " +
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

        // Ensures a modelo exists for the given base name; if exact exists, returns it.
        // Otherwise creates with next numeric suffix (e.g., "Hilux2", "Hilux3"). Requires a valid MaID.
        public int EnsureMarcaAuto(string descMarca)
        {
            if (string.IsNullOrWhiteSpace(descMarca))
                throw new ArgumentException("Brand name is required.", nameof(descMarca));

            using (var con = new SqlConnection(Database.ConnectionString))
            {
                con.Open();
                using (var chk = new SqlCommand("SELECT MaID FROM Marca WHERE DescMarca = @name", con))
                {
                    chk.Parameters.AddWithValue("@name", descMarca);
                    var id = chk.ExecuteScalar();
                    if (id != null && id != DBNull.Value)
                        return (int)id;
                }

                using (var ins = new SqlCommand(
                    "INSERT INTO Marca (DescMarca) OUTPUT INSERTED.MaID VALUES (@name)", con))
                {
                    ins.Parameters.AddWithValue("@name", descMarca);
                    return (int)ins.ExecuteScalar();
                }
            }
        }

        // Existing EnsureModeloAuto: adapted to use MaID resolved from brand
        public int EnsureModeloAuto(string baseDescModelo, int maId)
        {
            if (string.IsNullOrWhiteSpace(baseDescModelo))
                throw new ArgumentException("Model name is required.", nameof(baseDescModelo));
            if (maId <= 0) throw new ArgumentException("Invalid Marca ID.", nameof(maId));

            using (var con = new SqlConnection(Database.ConnectionString))
            {
                con.Open();

                // Check exact match within same brand
                using (var chkExact = new SqlCommand(
                    "SELECT ModID FROM Modelo WHERE DescModelo = @name AND MaID = @ma", con))
                {
                    chkExact.Parameters.AddWithValue("@name", baseDescModelo);
                    chkExact.Parameters.AddWithValue("@ma", maId);
                    var id = chkExact.ExecuteScalar();
                    if (id != null && id != DBNull.Value)
                        return (int)id;
                }

                // Find max numeric suffix for this brand + base name
                int maxSuffix = 1;
                using (var cmd = new SqlCommand(
                    "SELECT DescModelo FROM Modelo WHERE MaID = @ma AND DescModelo LIKE @prefix + '%'", con))
                {
                    cmd.Parameters.AddWithValue("@ma", maId);
                    cmd.Parameters.AddWithValue("@prefix", baseDescModelo);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var name = rdr.GetString(0).Trim();
                            if (string.Equals(name, baseDescModelo, StringComparison.OrdinalIgnoreCase))
                            {
                                maxSuffix = Math.Max(maxSuffix, 1);
                                continue;
                            }
                            if (name.StartsWith(baseDescModelo + " ", StringComparison.OrdinalIgnoreCase))
                            {
                                var tail = name.Substring(baseDescModelo.Length).Trim();
                                if (int.TryParse(tail, out var n)) maxSuffix = Math.Max(maxSuffix, n);
                            }
                        }
                    }
                }

                var nextName = $"{baseDescModelo} {maxSuffix + 1}";
                using (var ins = new SqlCommand(
                    "INSERT INTO Modelo (DescModelo, MaID) OUTPUT INSERTED.ModID VALUES (@name, @ma)", con))
                {
                    ins.Parameters.AddWithValue("@name", nextName);
                    ins.Parameters.AddWithValue("@ma", maId);
                    return (int)ins.ExecuteScalar();
                }
            }
        }

        // Existing insert/update methods unchanged (they’ll receive ModID from the form)
        // ...

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
