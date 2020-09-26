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
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAluno _ObjAlunoRepository;

        public ObjetivoAlunoController()
        {
            _ObjAlunoRepository = new ObjetivoAlunoRepository();
        }

        // GET: api/<ObjetivoAlunoController>
        /// <summary>
        /// Mostra todos os objetivos dos alunos
        /// </summary>
        /// <returns>Retorna uma lista de ObjetivoAluno</returns>
        [HttpGet]
        public List<ObjetivoAluno> Get()
        {
            return _ObjAlunoRepository.Listar();
        }

        // GET api/<ObjetivoAlunoController>/5
        /// <summary>
        /// Mostra um ObjetivoAluno especifico
        /// </summary>
        /// <param name="id">Id do ObjetivoAluno</param>
        /// <returns>Retorna um ObjetivoAluno específico</returns>
        [HttpGet("{id}")]
        public ObjetivoAluno Get(Guid id)
        {
            return _ObjAlunoRepository.BuscarPorId(id);
        }

        // POST api/<ObjetivoAlunoController>
        /// <summary>
        /// Adiciona um novo ObjetivoAluno
        /// </summary>
        /// <param name="id">ID de ObjetivoAluno</param>
        /// <param name="objetivoAluno">Objeto ObjetivoAluno</param>
        [HttpPost]
        public void Post([FromForm] Guid id, ObjetivoAluno objetivoAluno)
        {
            _ObjAlunoRepository.Adicionar(objetivoAluno);
        }

        // PUT api/<ObjetivoAlunoController>/5
        /// <summary>
        /// Edita um ObjetivoAluno ja existente
        /// </summary>
        /// <param name="id">Id de ObjetivoAluno</param>
        /// <param name="objetivoAluno">Objeto ObjetivoALuno</param>
        [HttpPut("{id}")]
        public void Put(Guid id, ObjetivoAluno objetivoAluno)
        {
            objetivoAluno.IdObjetivoAluno = id;
            _ObjAlunoRepository.Editar(objetivoAluno);
        }

        // DELETE api/<ObjetivoAlunoController>/5
        /// <summary>
        /// Remove um ObjetivoAluno
        /// </summary>
        /// <param name="id">Id de um ObjetivoAluno</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _ObjAlunoRepository.Remover(id);
        }
    }
}