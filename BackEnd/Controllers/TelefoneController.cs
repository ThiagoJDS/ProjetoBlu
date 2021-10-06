using System;
using System.Threading.Tasks;
using BackEnd.Data.Repository.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelefoneController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ITelefoneRepository _telefoneRepository;
        public TelefoneController(IRepository repository,
                                  ITelefoneRepository telefoneRepository)
        {
            _repository = repository;
            _telefoneRepository = telefoneRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                 var listaDeTelefone = await _telefoneRepository.ObterTodos();
                 return Ok(listaDeTelefone);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter todos os telefones, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPeloId(int id)
        {
            try
            {
                var listaTelefone = await _telefoneRepository.ObterPeloId(id);
                return Ok(listaTelefone);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao obter o telefone, ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Telefone telefoneModelo)
        {
            try
            {
                _repository.Add(telefoneModelo);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível salvar o telefone");
                }
                return Ok(telefoneModelo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar o telefone ocorreu o erro: {ex.Message} ...  Verifique se não ultrapassou 20 caracteres.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, Telefone telefoneModelo)
        {
            try
            {
                var telefone = await _telefoneRepository.ObterPeloId(id);
                if(telefone == null)
                {
                    return NotFound("Telefone não localizado");
                }

                _repository.Update(telefoneModelo);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível editar o telefone!");
                }

                return Ok(telefoneModelo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao editar o telefone ocorreu o erro: {ex.Message} ...  Verifique se não ultrapassou 20 caracteres.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                var telefoneCadastrado = await _telefoneRepository.ObterPeloId(id);
                if(telefoneCadastrado == null)
                {
                    return NotFound("Telefone não localizado.");
                }

                _repository.Delete(telefoneCadastrado);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível remover o telefone!");
                }

                return Ok( new { message="Telefone removido com sucesso!" } );
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao remover o telefone ocorreu o erro: {ex.Message}");
            }
        }
    }
}