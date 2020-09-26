using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEdux2._0.Utils.Crypt;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using ProjetoEduxRemake.Repositories;

namespace ProjetoEduxRemake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        // GET: api/<UsuarioController>
        /// <summary>
        /// Mostra todos os usuários existentes
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        [HttpGet]
        public List<Usuario> Get()
        {

            return _usuarioRepository.Listar();
        }

        // GET api/<UsuarioController>/5
        /// <summary>
        /// Retorna um usuário especificado pelo id
        /// </summary>
        /// <param name="id">Id de um usuário</param>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>Umusuário específico</returns>
        [HttpGet("{id}")]
        public Usuario Get(Guid id, Usuario usuario)
        {
            return _usuarioRepository.BuscarPorId(id);
        }

        // POST api/<UsuarioController>
        /// <summary>
        /// Adiciona um novo usuário
        /// </summary>
        /// <param name="id">Id de um usuário</param>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>Retorna um usário cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Guid id, Usuario usuario)
        {
            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));
            try
            {
                usuario.DataUltimoAcesso = DateTime.Now;
                usuario.DataCadastro = DateTime.Now;

                _usuarioRepository.Adicionar(usuario);

                return Ok(usuario);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        /// <summary>
        /// Edita um usuário existente
        /// </summary>
        /// <param name="id">Id de um usuário</param>
        /// <param name="usuario">Objeto usuário</param>
        [HttpPut("{id}")]
        public void Put( Guid id, Usuario usuario)
        {
            usuario.IdUsuario = id;
            _usuarioRepository.Editar(usuario);
        }

        // DELETE api/<UsuarioController>/5
        /// <summary>
        /// Remove um usuário existente
        /// </summary>
        /// <param name="id">Id de um usuário</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _usuarioRepository.Remover(id);
        }
    }
}
