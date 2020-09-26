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
    public class CursoController : ControllerBase
    {
        private readonly ICurso _CursoRepository;

        public CursoController()
        {
            _CursoRepository = new CursoRepository();
        }

        // GET: api/<CursoController>
        /// <summary>
        /// Mostra todos os cursos existentes
        /// </summary>
        /// <returns>Retorna uma lista de cursos</returns>
        [HttpGet]
        public List<Curso> Get()
        {
            return _CursoRepository.Listar();
        }

        // GET api/<CursoController>/5
        /// <summary>
        /// Mostra um curso especificado pelo seu id
        /// </summary>
        /// <param name="id">Recebe o id do curso</param>
        /// <returns>Retorna um curso especifico</returns>
        [HttpGet("{id}")]
        public Curso Get(Guid id)
        {
            return _CursoRepository.BuscarPorId(id);
        }

        // POST api/<CursoAlunoController>
        /// <summary>
        /// Adiciona um novo curso
        /// </summary>
        /// <param name="id">Recebe o id do curso</param>
        /// <param name="curso">Entidade curso</param>
        [HttpPost]
        public void Post([FromForm] Guid id, Curso curso)
        {
            _CursoRepository.Adicionar(curso);
        }

        // PUT api/<CursoController>/5
        /// <summary>
        /// Edita um curso já existente
        /// </summary>
        /// <param name="id">Recebe o id do curso</param>
        /// <param name="curso">Entidade curso</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Curso curso)
        {
            curso.IdCurso = id;
            _CursoRepository.Editar(curso);
        }

        // DELETE api/<CursoController>/5
        /// <summary>
        /// Apaga um curso existente
        /// </summary>
        /// <param name="id">Recebe o id do curso</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _CursoRepository.Remover(id);
        }
    }
}
