using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class DicaRepository : IDica
    {
        private readonly EduxContext _context;

        public DicaRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra uma nova dica
        /// </summary>
        /// <param name="dica">Objeto a ser cadastrado</param>
        public void Adicionar(Dica dica)
        {
            try
            {
                

                _context.Dicas.Add(dica);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma dica pelo id
        /// </summary>
        /// <param name="id">Id de dica</param>
        /// <returns>A dica procurado</returns>
        public Dica BuscarPorId(Guid id)
        {
            try
            {
                return _context.Dicas.FirstOrDefault(a => a.IdDica == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera uma dica
        /// </summary>
        /// <param name="dica">Objeto a ser alterado</param>
        public void Editar(Dica dica)
        {
            try
            {
                Dica dicaEdit = BuscarPorId(dica.IdDica);

                if (dicaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                dicaEdit.Texto = dica.Texto;

                _context.Dicas.Update(dicaEdit);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todos as dica cadastradas
        /// </summary>
        /// <returns>Uma lista de dicas</returns>
        public List<Dica> Listar()
        {
            try
            {
                

                return _context.Dicas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma dica
        /// </summary>
        /// <param name="id">Objeto de dica</param>
        public void Remover(Guid id)
        {
            try
            {
                Dica dicaEdit = BuscarPorId(id);

                if (dicaEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Dicas.Remove(dicaEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
