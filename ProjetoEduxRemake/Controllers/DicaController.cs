using System;
using System.Collections.Generic;
using System.IO;
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
    public class DicaController : ControllerBase
    {
        private readonly IDica _dicaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }

        // GET: api/<DicaController>
        /// <summary>
        /// Mostra todas as Dicas existentes
        /// </summary>
        /// <returns>Retorna uma lista de dicas</returns>
        [HttpGet]
        public List<Dica> Get()
        {
            return _dicaRepository.Listar();
        }

        // GET api/<DicaController>/5
        /// <summary>
        /// Mostra um dicas especificada pelo Id
        /// </summary>
        /// <param name="id">Id de uma dica</param>
        /// <returns>Retorna uma dica especifica</returns>
        [HttpGet("{id}")]
        public Dica Get(Guid id)
        {
            return _dicaRepository.BuscarPorId(id);
        }

        // POST api/<DicaController>
        /// <summary>
        /// Adiciona uma nova dica
        /// </summary>
        /// <param name="id">Id de uma dica</param>
        /// <param name="dica">Uma dica</param>
        /// <returns>O a dic0 cadastradaa</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Guid id, Dica dica)
        {
            try
            {
                if (dica.ImagemNova != null)
                {
                    var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(dica.ImagemNova.FileName);
                    var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot/Upload/Imagens", nomeArquivo);

                    using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

                    dica.ImagemNova.CopyTo(streamImagem);

                    dica.UrlImagem = "seulocalhost/Upload/Imagens" + nomeArquivo;

                    

                }

                _dicaRepository.Adicionar(dica);

                return Ok(dica);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DicaController>/5
        /// <summary>
        /// Edita uma dica existente
        /// </summary>
        /// <param name="id">Id de uma dica</param>
        /// <param name="dica">Uma dica</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Dica dica)
        {
            dica.IdDica = id;
            _dicaRepository.Editar(dica);
        }

        // DELETE api/<DicaController>/5
        /// <summary>
        /// Remove uma deica existente
        /// </summary>
        /// <param name="id">Id de uma dica</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _dicaRepository.Remover(id);
        }
    }
}