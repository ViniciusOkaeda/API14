using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class ObjetivoRepository : IObjetivo
    {
        private readonly EduxContext _context;

        public ObjetivoRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra um novo objetivo
        /// </summary>
        /// <param name="objetivo">Objeto a ser cadastrado</param>
        public void Adicionar(Objetivo objetivo)
        {
            try
            {
               

                _context.Objetivos.Add(objetivo);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um objetivo pelo id
        /// </summary>
        /// <param name="id">Id de objetivo</param>
        /// <returns>O objetivo procurado</returns>
        public Objetivo BuscarPorId(Guid id)
        {
            try
            {
                return _context.Objetivos.FirstOrDefault(a => a.IdObjetivo == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um objetivo
        /// </summary>
        /// <param name="objetivo">Objeto a ser alterado</param>
        public void Editar(Objetivo objetivo)
        {
            try
            {
                Objetivo objetivoEdit = BuscarPorId(objetivo.IdObjetivo);

                if (objetivoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                objetivoEdit.Descricao = objetivo.Descricao;

                _context.Objetivos.Update(objetivoEdit);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todos os objetivos cadastrados
        /// </summary>
        /// <returns>Uma lista de objetivos</returns>
        public List<Objetivo> Listar()
        {
            try
            {
                

                return _context.Objetivos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um objetivo
        /// </summary>
        /// <param name="id">Objeto de objetivo</param>
        public void Remover(Guid id)
        {
            try
            {
                Objetivo objetivoEdit = BuscarPorId(id);

                if (objetivoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Objetivos.Remove(objetivoEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
