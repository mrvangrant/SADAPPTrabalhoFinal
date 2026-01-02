using System.Data;

namespace APPInterfaceSAD.Services
{
 public class InMemoryClienteService : IClienteService
 {
 private readonly DataTable _table;
 private int _nextId =1;

 public InMemoryClienteService()
 {
 _table = new DataTable();
 _table.Columns.Add("ClienteId", typeof(int));
 _table.Columns.Add("Nome", typeof(string));
 _table.Columns.Add("NIF", typeof(string));
 _table.Columns.Add("Tipo", typeof(string));
 _table.Columns.Add("Valor", typeof(string));

 AddRow("Alice", "123456789", "Email", "alice@example.com");
 AddRow("Bob", "987654321", "Telefone", "212345678");
 }

 public void InserirClienteContacto(string nome, string nif, string tipo, string valor)
 {
 AddRow(nome, nif, tipo, valor);
 }

 public DataTable ObterClientes()
 {
 return _table.Copy();
 }

 private void AddRow(string nome, string nif, string tipo, string valor)
 {
 var row = _table.NewRow();
 row["ClienteId"] = _nextId++;
 row["Nome"] = nome;
 row["NIF"] = nif;
 row["Tipo"] = tipo;
 row["Valor"] = valor;
 _table.Rows.Add(row);
 }
 }
}
