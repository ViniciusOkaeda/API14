using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class CurtidaRepository : ICurtida
    {
        private readonly EduxContext _context;

        public CurtidaRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra uma nova curtida
        /// </summary>
        /// <param name="curtida">Objeto a ser cadastrado</param>
        public void Adicionar(Curtida curtida)
        {
            try
            {
                

                _context.Curtidas.Add(curtida);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma curtida pelo id
        /// </summary>
        /// <param name="id">Id de curtida</param>
        /// <returns>A curtida procurado</returns>
        public Curtida BuscarPorId(Guid id)
        {
            try
            {
                return _context.Curtidas.FirstOrDefault(a => a.IdCurtida == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera umA curtida
        /// </summary>
        /// <param name="curtida">Objeto a ser alterado</param>
        public void Editar(Curtida curtida)
        {
            try
            {
                Curtida curtidaEdit = BuscarPorId(curtida.IdCurtida);

                if (curtidaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Curtidas.Update(curtidaEdit);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todas as curtidas cadastrados
        /// </summary>
        /// <returns>Uma lista de curtidas</returns>
        public List<Curtida> Listar()
        {
            try
            {
                

                return _context.Curtidas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma curtida
        /// </summary>
        /// <param name="id">Objeto de curtida</param>
        public void Remover(Guid id)
        {
            try
            {
                Curtida curtidaEdit = BuscarPorId(id);

                if (curtidaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Curtidas.Remove(curtidaEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
