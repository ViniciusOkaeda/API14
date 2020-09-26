using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using ProjetoEduxRemake.Repositories;

namespace ProjetoEduxRemake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfil _perfilRepository;

        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        // GET: api/<PerfilController>
        /// <summary>
        /// Lista Todos Os perfis
        /// </summary>
        /// <returns>Retorna lista de perfis</returns>
        [HttpGet]
        public List<Perfil> Get()
        {
            return _perfilRepository.Listar();
        }

        // GET api/<PerfiloController>/5
        /// <summary>
        /// Busca um Perfil por seu id
        /// </summary>
        /// <param name="id">Id do Perfil</param>
        /// <returns>Uma busca pelo id do perfil</returns>
        [HttpGet("{id}")]
        public Perfil Get(Guid id)
        {
            return _perfilRepository.BuscarPorId(id);
        }

        // POST api/<PerfilController>
        /// <summary>
        /// Adiciona um novo perfil 
        /// </summary>
        /// <param name="id">id do perfil</param>
        /// <param name="perfil">objeto perfil</param>
        [HttpPost]
        public void Post([FromForm] Guid id, Perfil perfil)
        {
            _perfilRepository.Adicionar(perfil);
        }

        // PUT api/<PerfilController>/5
        /// <summary>
        /// Edita um perfil existente
        /// </summary>
        /// <param name="id">id do Perfil</param>
        /// <param name="perfil">Objeto Perfil</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Perfil perfil)
        {
            perfil.IdPerfil = id;
            _perfilRepository.Editar(perfil);
        }

        // DELETE api/<PerfilController>/5
        /// <summary>
        /// Exclui um Perfil
        /// </summary>
        /// <param name="id">id do Perfil</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _perfilRepository.Remover(id);
        }
    }
}
