using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_SPMGAPI_Tarde.Domains;
using Senai_SPMGAPI_Tarde.Interfaces;
using Senai_SPMGAPI_Tarde.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMGAPI_Tarde.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            tiposUsuarioRepository = new tiposUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(tiposUsuarioRepository.Listar());
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
                return Ok(tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipousuario)
        {
            try
            {
                tiposUsuarioRepository.Cadastrar(novoTipousuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                tiposUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

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
                tiposUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

    internal class tiposUsuarioRepository : ITiposUsuarioRepository
    {
        void ITiposUsuarioRepository.Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        TipoUsuario ITiposUsuarioRepository.BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        void ITiposUsuarioRepository.Cadastrar(TipoUsuario novoTipoUsuario)
        {
            throw new NotImplementedException();
        }

        void ITiposUsuarioRepository.Deletar(int id)
        {
            throw new NotImplementedException();
        }

        List<TipoUsuario> ITiposUsuarioRepository.Listar()
        {
            throw new NotImplementedException();
        }
    }
}
