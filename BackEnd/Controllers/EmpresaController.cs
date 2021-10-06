using System;
using System.Threading.Tasks;
using BackEnd.Data.Repository.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaController(IRepository repository, IEmpresaRepository empresaRepository)
        {
            _repository = repository;
            _empresaRepository = empresaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var listaDaEmpresa = await _empresaRepository.ObterTodos();
                return Ok(listaDaEmpresa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todas as empresas ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPeloId(int id)
        {
            try
            {
                var listaEmpresa = await _empresaRepository.ObterPeloId(id);
                return Ok(listaEmpresa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter a empresa ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Empresa empresaModelo)
        {
            try
            {
                _repository.Add(empresaModelo);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível cadastrar a empresa!");
                }
                return Ok(empresaModelo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar a empresa ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, Empresa empresaModelo)
        {
            try
            {
                var empresa = await _empresaRepository.ObterPeloId(id);
                if(empresa == null)
                {
                    return NotFound("Não foi possível localizar a empresa!");
                }

                _repository.Update(empresaModelo);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível editar a empresa!");
                }
                return Ok(empresaModelo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao editar a empresa ocorreu o erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                var empresaCadastrada = await _empresaRepository.ObterPeloId(id);
                if(empresaCadastrada == null)
                {
                    return NotFound("Empresa não lozalizado.");
                }

                _repository.Delete(empresaCadastrada);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível deletar a empresa!");
                }
                return Ok( new { message = "Empresa removido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao remover a empresa ocorreu o erro: {ex.Message}");
            }
        }
    }
}