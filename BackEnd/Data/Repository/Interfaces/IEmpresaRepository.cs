using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Data.Repository.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> ObterTodos();
        Task<Empresa> ObterPeloId(int empresaId);
    }
}