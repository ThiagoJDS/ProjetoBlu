using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Data.Repository.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> ObterTodos(bool incluirEmpresa, bool incluirCnpj, bool incluirTelefone);
        Task<Fornecedor> ObterPeloId(int fornecedorId, bool incluirEmpresa, bool incluirCnpj, bool incluirTelefone);
    }
}