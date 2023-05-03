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

        [HttpPost]
        public async Task<ActionResult> Create (Pessoa pessoa)
        {
            try
            {
                await _pessoaService.CreatePessoa(pessoa);
                return CreatedAtRoute(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
            }
            catch (Exception)
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa.Id == id)
                {
                    await _pessoaService.UpdatePessoa(pessoa);
                    return Ok($"Pessoa com id = {id} foi atualizada com sucesso");
                }
                else
                    return NotFound($"Pessoa com id = {id} não encontrada");
            }
            catch (Exception)
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var p = await _pessoaService.GetPessoaPorId(id);

                if (p != null && p.Id >0)
                {   
                    await _pessoaService.DeletePessoa(p);
                    return Ok($"Pessoa com id = {id} foi desativada com sucesso");
                }
                else
                    return NotFound($"Pessoa com id = {id} não encontrada");
            }
            catch (Exception)
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
