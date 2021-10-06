using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Data.Repository.Interfaces
{
    public interface ITelefoneRepository
    {
        Task<IEnumerable<Telefone>> ObterTodos();
        Task<Telefone> ObterPeloId(int telefoneId);
    }
}