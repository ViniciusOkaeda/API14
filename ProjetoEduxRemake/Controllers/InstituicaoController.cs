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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        // GET: api/<InstituicaoController>
        /// <summary>
        /// Mostra todas as Instituições
        /// </summary>
        /// <returns>Retorna uma ista de Instituições</returns>
        [HttpGet]
        public List<Instituicao> Get()
        {
            return _instituicaoRepository.Listar();
        }

        // GET api/<InstituicaoController>/5
        /// <summary>
        /// Mostra uma instituição específica
        /// </summary>
        /// <param name="id">Id de uma instituição</param>
        /// <returns>Retorna uma instituição específica</returns>
        [HttpGet("{id}")]
        public Instituicao Get(Guid id)
        {
            return _instituicaoRepository.BuscarPorId(id);
        }

        // POST api/<InstituicaoController>
        /// <summary>
        /// Adiciona uma nova instituição
        /// </summary>
        /// <param name="id">Id de uma instituição</param>
        /// <param name="instituicao">Objeto Instituição</param>
        [HttpPost]
        public void Post([FromForm] Guid id, Instituicao instituicao)
        {
            _instituicaoRepository.Adicionar(instituicao);
        }

        // PUT api/<InstituicaoController>/5
        /// <summary>
        /// edita uma instituição ja existente
        /// </summary>
        /// <param name="id">Id de uma instituição</param>
        /// <param name="instituicao">Objeto Instituição</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Instituicao instituicao)
        {
            instituicao.IdInstituicao = id;
            _instituicaoRepository.Editar(instituicao);
        }

        // DELETE api/<InstituicaoController>/5
        /// <summary>
        /// Remove uma instituição existente
        /// </summary>
        /// <param name="id">Id de uma Instituição</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _instituicaoRepository.Remover(id);
        }
    }
}
