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
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurma _alunoTurmaRepository;

        public AlunoTurmaController()
        {
            _alunoTurmaRepository = new AlunoTurmaRepository();
        }

        // GET: api/<AlunoTurmaController>
        /// <summary>
        /// Mostra todas as turmas que o aluno está cadastrado
        /// </summary>
        /// <returns>Lista de Matricula</returns>
        [HttpGet]
        public List<AlunoTurma> Get()
        {
            return _alunoTurmaRepository.Listar();
        }

        // GET api/<AlunoTurmaController>/5
        /// <summary>
        /// Mostra a turma em que o aluno especificado pelo Id está cadastrado
        /// </summary>
        /// <param name="id">id da Matrícula</param>
        /// <returns>Lista de Matricula de um aluno específico</returns>
        [HttpGet("{id}")]
        public AlunoTurma Get(Guid id)
        {
            return _alunoTurmaRepository.BuscarPorId(id);
        }

        // POST api/<AlunoTurmaController>
        /// <summary>
        /// Adiciona uma nova Matricula
        /// </summary>
        /// <param name="id">Id da Matrículaparam>
        /// <param name="alunoTurma">Entidade AlunoTurma</param>
        [HttpPost]
        public void Post([FromForm] Guid id, AlunoTurma alunoTurma)
        {
            _alunoTurmaRepository.Adicionar(alunoTurma);
        }

        // PUT api/<AlunoTurmaController>/5
        /// <summary>
        /// Edita elementos da matricula
        /// </summary>
        /// <param name="id">Id de AlunoTurma</param>
        /// <param name="alunoTurma">Entidade AlunoTurma</param>
        [HttpPut("{id}")]
        public void Put(Guid id, AlunoTurma alunoTurma)
        {
            alunoTurma.IdAlunoTurma = id;
            _alunoTurmaRepository.Editar(alunoTurma);
        }

        // DELETE api/<AlunoTurmaController>/5
        /// <summary>
        /// Apaga uma Matrícula
        /// </summary>
        /// <param name="id">Id AlunoTurma</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _alunoTurmaRepository.Remover(id);
        }
    }
}
