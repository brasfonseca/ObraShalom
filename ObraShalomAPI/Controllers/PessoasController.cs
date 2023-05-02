using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObraShalomAPI.Models;
using ObraShalomAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObraShalomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Pessoa>>> GetPessoas()
        {
            try
            {
                var pessoas = await _pessoaService.GetPessoas();
                return Ok(pessoas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Pessoas");
            }
        }

        [HttpGet("PessoasPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Pessoa>>> GetPessoasPorNome([FromQuery] string nome)
        {
            try
            {
                var pessoas = await _pessoaService.GetPessoasPorNome(nome);

                if (pessoas.Count() == 0)
                    return NotFound($"Não existem pessoas com o critério {nome}");

                return Ok(pessoas);
            }
            catch (Exception)
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name="GetPessoa")]
        public async Task<ActionResult<IAsyncEnumerable<Pessoa>>> GetPessoa(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoaPorId(id);

                if (pessoa == null)
                    return NotFound($"Não existem pessoas com o critério {id}");

                return Ok(pessoa);
            }
            catch (Exception)
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
