using System;
using System.Threading.Tasks;
using BackEnd.Data.Repository.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorController(IRepository repository, IFornecedorRepository fornecedorRepository)
        {
            _repository = repository;
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var listaDeFornecedores = await _fornecedorRepository.ObterTodos(incluirEmpresa:true, incluirCnpj: true, incluirTelefone: true);
                return Ok(listaDeFornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao buscar todos os fornecedores ocorreu o erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPeloId(int id)
        {
            try
            {
                var listaFornecedor = await _fornecedorRepository.ObterPeloId(id, incluirEmpresa:true, incluirCnpj: true, incluirTelefone: true);
                return Ok(listaFornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao buscar o fornecedor ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Fornecedor fornecedorModelo)
        {
            try
            {
                _repository.Add(fornecedorModelo);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível cadastrar fornecedor!");
                }
                return Ok(fornecedorModelo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao salvar fornecedor ocorreu o erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, Fornecedor fornecedorModelo)
        {
            try
            {
                var fornecedor = await _fornecedorRepository.ObterPeloId(id, incluirEmpresa:false, incluirCnpj:false, incluirTelefone:false);
                if(fornecedor == null)
                {
                    return NotFound("Fornecedor não localizado!");
                }

                _repository.Update(fornecedorModelo);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível editar fornecedor!");
                }
                return Ok(fornecedorModelo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao editar fornecedor ocorreu o erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                var cadastroFornecedor = await _fornecedorRepository.ObterPeloId(id, incluirEmpresa:false, incluirCnpj: false, incluirTelefone: false);
                if(cadastroFornecedor == null)
                {
                    return BadRequest("Fornecedor não localizado!");
                }

                _repository.Delete(cadastroFornecedor);
                if(!await _repository.SaveChanges())
                {
                    return BadRequest("Não foi possível deletar fornecedor!");
                }
                return Ok( new { message = "Fornecedor removido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ao deletar fornecedor ocorreu o erro: {ex.Message}");
            }
        }
    }
}