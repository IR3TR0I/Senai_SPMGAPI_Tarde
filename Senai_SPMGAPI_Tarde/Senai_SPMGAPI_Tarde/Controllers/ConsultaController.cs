using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMGAPI_Tarde.Domains;
using Senai_SPMGAPI_Tarde.Interfaces;
using Senai_SPMGAPI_Tarde.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMGAPI_Tarde.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultaController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ConsultaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_ConsultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Consulta novoConsultum)
        {
            try
            {
                _ConsultaRepository.Cadastrar(novoConsultum);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta ConsultumAtualizado)
        {
            try
            {
                _ConsultaRepository.Atualizar(id, ConsultumAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ConsultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_ConsultaRepository.Minhas(idUsuario));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Situação ConsultumPermissao)
        {
            try
            {
                // Faz a chamada para o método  
                _ConsultaRepository.AlterStatus(id, ConsultumPermissao.Situacao1);

                // Retora a resposta da requisição 204 - No Content
                return StatusCode(204);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Somente o administrador pode alterar a Situação da consulta!",
                    error
                });
            }
        }
        [Authorize(Roles = "2")]
        [HttpPatch("descricao/{id}")]
        public IActionResult UpdateDescricao(int id, Consulta Descricao)
        {
            try
            {
                // Faz a chamada para o método  
                _ConsultaRepository.Prontuario(id, Descricao);

                // Retora a resposta da requisição 204 - No Content
                return StatusCode(204);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Somente o médico pode alterar a Descrição!",
                    error
                });
            }
        }
    }

    public class Situação
    {
        public string Situacao1 { get; internal set; }
    }
}
