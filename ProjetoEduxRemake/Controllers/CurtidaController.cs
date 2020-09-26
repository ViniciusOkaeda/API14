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
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtida _curtidaRepository;

        public CurtidaController()
        {
            _curtidaRepository = new CurtidaRepository();
        }

        // GET: api/<DicaController>
        /// <summary>
        /// Mostra todas as curtidas existentes
        /// </summary>
        /// <returns>Retorna uma lista de curtidas</returns>
        [HttpGet]
        public List<Curtida> Get()
        {
            return _curtidaRepository.Listar();
        }

        // GET api/<DicaController>/5
        /// <summary>
        /// Mostra uma curtida especifica
        /// </summary>
        /// <param name="id">Id de uma curtida</param>
        /// <returns>Retorna uma curtida específica</returns>
        [HttpGet("{id}")]
        public Curtida Get(Guid id)
        {
            return _curtidaRepository.BuscarPorId(id);
        }

        // POST api/<DicaController>
        /// <summary>
        /// Adiciona uma nova curtida
        /// </summary>
        /// <param name="id">Id de uma curtida</param>
        /// <param name="curtida">Uma curtida</param>
        [HttpPost]
        public void Post([FromForm] Guid id, Curtida curtida)
        {
            _curtidaRepository.Adicionar(curtida);
        }

        // PUT api/<DicaController>/5
        /// <summary>
        /// Edita uma curtida existente
        /// </summary>
        /// <param name="id">Id de uma curtida</param>
        /// <param name="curtida">Uma curtida</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Curtida curtida)
        {
            curtida.IdCurtida = id;
            _curtidaRepository.Editar(curtida);
        }

        // DELETE api/<DicaController>/5
        /// <summary>
        /// Remove uma curtida existente
        /// </summary>
        /// <param name="id">Id de uma curtida</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _curtidaRepository.Remover(id);
        }
    }
}