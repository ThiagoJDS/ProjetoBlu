using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data.Repository.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Services
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly DataContext _context;
        public TelefoneRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Telefone>> ObterTodos()
        {
            IQueryable<Telefone> consulta = _context.Telefones;
            consulta = consulta.AsNoTracking().OrderBy(t => t.Id);
            return await consulta.ToArrayAsync();
        }
        public async Task<Telefone> ObterPeloId(int telefoneId)
        {
            IQueryable<Telefone> consulta = _context.Telefones;
            consulta = consulta.AsNoTracking().Where(t => t.Id == telefoneId);
            return await consulta.FirstOrDefaultAsync();
        }
    }
}