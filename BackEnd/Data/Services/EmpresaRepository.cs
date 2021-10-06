using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data.Repository.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Services
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DataContext _context;
        public EmpresaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Empresa>> ObterTodos()
        {
            IQueryable<Empresa> consulta = _context.Empresas;
            consulta = consulta.AsNoTracking().OrderBy(e => e.Id);
            return await consulta.ToArrayAsync();
        }

        public async Task<Empresa> ObterPeloId(int empresaId)
        {
            IQueryable<Empresa> consulta = _context.Empresas;
            consulta = consulta.AsNoTracking().Where(e => e.Id == empresaId);
            return await consulta.FirstOrDefaultAsync();
        }
    }
}