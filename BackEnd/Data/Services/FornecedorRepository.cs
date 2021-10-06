using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data.Repository.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Services
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly DataContext _context;
        public FornecedorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Fornecedor>> ObterTodos(bool incluirEmpresa, bool incluirCnpj, bool incluirTelefone)
        {
            IQueryable<Fornecedor> consulta = _context.Fornecedors;
            if(incluirEmpresa)
            {
                consulta = consulta.Include(f => f.Empresa);
            }
            if(incluirCnpj)
            {
                consulta = consulta.Include(f => f.Cnpj);
            }
            if(incluirTelefone)
            {
               consulta = consulta.Include(f => f.Telefone);
            }

            consulta = consulta.AsNoTracking().OrderBy(f => f.Id);
            return await consulta.ToArrayAsync();
        }
        public async Task<Fornecedor> ObterPeloId(int fornecedorId, bool incluirEmpresa, bool incluirCnpj, bool incluirTelefone)
        {
            IQueryable<Fornecedor> consulta = _context.Fornecedors;
            if(incluirEmpresa)
            {
                consulta = consulta.Include(f => f.Empresa);
            }
            if(incluirCnpj)
            {
                consulta = consulta.Include(f => f.Cnpj);
            }
            if(incluirTelefone)
            {
                consulta = consulta.Include(f => f.Telefone);
            }

            consulta = consulta.AsNoTracking().Where(f => f.Id == fornecedorId);
            return await consulta.FirstOrDefaultAsync();
        }
    }
}