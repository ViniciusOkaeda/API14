using ProjetoEduxRemake.Context;
using ProjetoEduxRemake.Domains;
using ProjetoEduxRemake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private readonly EduxContext _context;

        public InstituicaoRepository()
        {
            _context = new EduxContext();
        }

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="instituicao">Objeto a ser cadastrado</param>
        public void Adicionar(Instituicao instituicao)
        {
            try
            {
                

                _context.Instituicoes.Add(instituicao);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma instituicao pelo id
        /// </summary>
        /// <param name="id">Id de instituicao</param>
        /// <returns>O usuario procurado</returns>
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _context.Instituicoes.FirstOrDefault(a => a.IdInstituicao == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera uma instituicao
        /// </summary>
        /// <param name="instituicao">Objeto a ser alterado</param>
        public void Editar(Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoEdit = BuscarPorId(instituicao.IdInstituicao);

                if (instituicaoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                instituicaoEdit.Nome = instituicao.Nome;
                instituicaoEdit.Logradouro = instituicao.Logradouro;
                instituicaoEdit.Numero = instituicao.Numero;
                instituicaoEdit.Complemento = instituicao.Complemento;
                instituicaoEdit.Bairro = instituicao.Bairro;
                instituicaoEdit.Cidade = instituicao.Cidade;
                instituicaoEdit.UF = instituicao.UF;
                instituicaoEdit.CEP = instituicao.CEP;

                _context.Instituicoes.Update(instituicaoEdit);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Mostra todos as instituicoes cadastradas
        /// </summary>
        /// <returns>Uma lista de instituicoes</returns>
        public List<Instituicao> Listar()
        {
            try
            {

                return _context.Instituicoes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma instituicao
        /// </summary>
        /// <param name="id">Objeto de instituicao</param>
        public void Remover(Guid id)
        {
            try
            {
                Instituicao instituicaoEdit = BuscarPorId(id);

                if (instituicaoEdit == null)
                {
                    throw new Exception("Usuario nao encontrad");
                }

                _context.Instituicoes.Remove(instituicaoEdit);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
