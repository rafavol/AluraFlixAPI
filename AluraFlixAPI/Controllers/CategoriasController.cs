using AluraFlixAPI.Models;
using AluraFlixAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IVideoRepository _videoReposiroty;

        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(ICategoriaRepository categoriaRepository,
            IVideoRepository videoReposiroty,
            ILogger<CategoriasController> logger)
        {
            _categoriaRepository = categoriaRepository;
            _videoReposiroty = videoReposiroty;
            _logger = logger;
        }

        // GET: Categorias/
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {

            return Ok(_categoriaRepository.GetCategorias());
        }

        // GET: Categorias/1
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Categoria>> Get(int id)
        {

            return Ok(_categoriaRepository.GetCategoria(id));
        }

        // GET: Categorias/1/Videos
        [HttpGet]
        [ProducesResponseType(200)]
        [Route("{id}/Videos")]
        public ActionResult<IEnumerable<Categoria>> GetVideosByCategoriaId(int id)
        {

            return Ok(_videoReposiroty.GetVideosByCategoriaId(id));
        }

        // POST: Categorias/
        [HttpPost]
        public ActionResult<Video> Post(Categoria categoria)
        {
            return Ok(_categoriaRepository.CreateCategoria(categoria));
        }

        // DELETE: Categorias/5
        [HttpDelete("{id}")]
        public ActionResult<Video> Delete(int id)
        {
            var result = _categoriaRepository.DeleteCategoria(id);
            return result ? Ok("Categoria removida com sucesso") : NotFound("Categoria não encontrada");
        }

        // PUT: Categorias/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Categoria categoria)
        {
            var result = _categoriaRepository.UpdateCategoria(id, categoria);
            return result ? Ok("Categoria alterada com sucesso") : BadRequest("Problemas para alterar a categoria");
        }
    }
}
