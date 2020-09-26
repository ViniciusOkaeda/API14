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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _CategoriaRepository;

        public CategoriaController()
        {
            _CategoriaRepository = new CategoriaRepository();
        }

        // GET: api/<CategoriaController>
        /// <summary>
        /// Mostra todas as categorias existentes
        /// </summary>
        /// <returns>Uma lista de categoria</returns>
        [HttpGet]
        public List<Categoria> Get()
        {
            return _CategoriaRepository.Listar();
        }

        // GET api/<CategoriaController>/5
        /// <summary>
        /// Retorna um categoria específica pelo seu Id
        /// </summary>
        /// <param name="id">Id de categoria</param>
        /// <returns>Uma categoria específica</returns>
        [HttpGet("{id}")]
        public Categoria Get(Guid id)
        {
            return _CategoriaRepository.BuscarPorId(id);
        }

        // POST api/<CategoriaAlunoController>
        /// <summary>
        /// Adiciona uma nova categoria
        /// </summary>
        /// <param name="id">id de uma categoria</param>
        /// <param name="categoria">Uma categoria</param>
        /// <returns>Uma categoria criada</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Guid id, Categoria categoria)
        {
            _CategoriaRepository.Adicionar(categoria);

            return CreatedAtAction("GetCategoria", new { id = categoria.IdCategoria }, categoria);
        }

        // PUT api/<CategoriaController>/5
        /// <summary>
        /// Edita uma categoria ja existente
        /// </summary>
        /// <param name="id">id da categoria</param>
        /// <param name="categoria">Uma entidade categoria</param>
        /// <returns>Uma categoria editada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Categoria categoria)
        {
            categoria.IdCategoria = id;
            _CategoriaRepository.Editar(categoria);

            return CreatedAtAction("GetCategoria", new { id = categoria.IdCategoria }, categoria);

        }

        // DELETE api/<CategoriaController>/5
        /// <summary>
        /// Apaga uma categoria
        /// </summary>
        /// <param name="id">id da categoria</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _CategoriaRepository.Remover(id);
        }
    }
}