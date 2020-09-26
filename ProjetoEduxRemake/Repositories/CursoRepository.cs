using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class CursoRepository : ICurso
    {
        private readonly EduxContext _context;

        public CursoRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo curso
        /// </summary>
        /// <param name="curso">Objeto a ser cadastrado</param>
        public void Adicionar(Curso curso)
        {
            try
            {
                

                _context.Cursos.Add(curso);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um curso pelo id
        /// </summary>
        /// <param name="id">Id de curso</param>
        /// <returns>O curso procurado</returns>
        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _context.Cursos.FirstOrDefault(a => a.IdCurso == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um curso
        /// </summary>
        /// <param name="curso">Objeto a ser alterado</param>
        public void Editar(Curso curso)
        {
            try
            {
                Curso cursoEdit = BuscarPorId(curso.IdCurso);

                if (cursoEdit == null)
                {
                    throw new Exception("Usuario nao encontrado");
                }

                cursoEdit.Titulo = curso.Titulo;

                _context.Cursos.Update(cursoEdit);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todos os cursos cadastrados
        /// </summary>
        /// <returns>Uma lista de cursos</returns>
        public List<Curso> Listar()
        {
            try
            {
                

                return _context.Cursos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um curso
        /// </summary>
        /// <param name="id">Objeto de curso</param>
        public void Remover(Guid id)
        {
            try
            {
                Curso cursoEdit = BuscarPorId(id);

                if (cursoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Cursos.Remove(cursoEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
