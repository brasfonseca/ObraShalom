using Microsoft.EntityFrameworkCore;
using ObraShalomAPI.Context;
using ObraShalomAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObraShalomAPI.Services
{
    public class PessoasService : IPessoaService
    {
        private readonly AppDbContext _context;

        public PessoasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreatePessoa(Pessoa pessoa)
        {
            pessoa.Status = true;
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePessoa(Pessoa pessoa)
        {
            pessoa.Status = false;
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {   
            try
            {
                return await _context.Pessoas.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Pessoa> GetPessoaPorId(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            return pessoa;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasPorNome(string nome)
        {
            IEnumerable<Pessoa> pessoas;
            if(!string.IsNullOrWhiteSpace(nome))
            {
                pessoas = await _context.Pessoas.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                pessoas = await GetPessoas();
            }

            return pessoas;
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
