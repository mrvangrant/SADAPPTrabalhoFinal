using System.Data;

namespace APPInterfaceSAD.Services
{
 public interface IClienteService
 {
 void InserirClienteContacto(string nome, string nif, string tipo, string valor);
 DataTable ObterClientes();
 }
}
