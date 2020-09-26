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
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivo _objetivoRepository;

        public ObjetivoController()
        {
            _objetivoRepository = new ObjetivoRepository();
        }

        // GET: api/<ObjetivoController>
        /// <summary>
        /// Mostra todos os objetivos existentes
        /// </summary>
        /// <returns>Retorna uma lista de Objetivo</returns>
        [HttpGet]
        public List<Objetivo> Get()
        {
            return _objetivoRepository.Listar();
        }

        // GET api/<ObjetivoController>/5
        /// <summary>
        /// Mostra um objetivo específicado
        /// </summary>
        /// <param name="id">Id de Objetivo</param>
        /// <returns>Retorna um objetivo específicado pelo Id</returns>
        [HttpGet("{id}")]
        public Objetivo Get(Guid id)
        {
            return _objetivoRepository.BuscarPorId(id);
        }

        // POST api/<ObjetivoController>
        /// <summary>
        /// Adiciona um novo objetivo
        /// </summary>
        /// <param name="id">Id de objetivo</param>
        /// <param name="objetivo">Objeto Objetivo</param>
        [HttpPost]
        public void Post([FromForm] Guid id, Objetivo objetivo)
        {
            _objetivoRepository.Adicionar(objetivo);
        }

        // PUT api/<ObjetivoController>/5
        /// <summary>
        /// Edita um objetivo ja existente
        /// </summary>
        /// <param name="id">Id de objetivo</param>
        /// <param name="objetivo">Objeto Objetivo</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Objetivo objetivo)
        {
            objetivo.IdObjetivo = id;
            _objetivoRepository.Editar(objetivo);
        }

        // DELETE api/<ObjetivoController>/5
        /// <summary>
        /// Remove um objeto ja existente
        /// </summary>
        /// <param name="id">Id de Objetivo</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _objetivoRepository.Remover(id);
        }
    }
}
