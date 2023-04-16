using ObraShalomAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObraShalomAPI.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GetPessoas();
        Task<Pessoa> GetPessoasById(int id);
        Task<IEnumerable<Pessoa>> GetPessoasByNome(string nome);
        Task CreatePessoa(Pessoa pessoa);
        Task UpdatePessoa(Pessoa pessoa);
        Task DeletePessoa(Pessoa pessoa);
    }
}
