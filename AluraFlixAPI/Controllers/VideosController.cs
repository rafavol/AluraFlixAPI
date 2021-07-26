using AluraFlixAPI.Models;
using AluraFlixAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AluraFlixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IVideoRepository _videoReposiroty;

        private readonly ILogger<VideosController> _logger;

        public VideosController(ILogger<VideosController> logger,
            IVideoRepository videoReposiroty)
        {
            _logger = logger;
            _videoReposiroty = videoReposiroty;
        }

        // GET: Videos/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> Get()
        {

            return Ok(await _videoReposiroty.GetVideos());
        }

        // GET: Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> Get(int id)
        {
            var video = await _videoReposiroty.GetVideo(id);
            if (video == null)
            {
                return NotFound("Vídeo não encontrado");
            }

            return Ok(video);
        }

        // POST: Videos/
        [HttpPost]
        public async Task<ActionResult<Video>> Post(Video video)
        {
            return Ok(await _videoReposiroty.CreateVideo(video));
        }

        // DELETE: Videos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Video>> Delete(int id)
        {
            var result = await _videoReposiroty.DeleteVideo(id);
            return result ? Ok("Vídeo Removido com sucesso") : NotFound("Vídeo não encontrado");
        }

        // PUT: Videos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Video video)
        {
            var result = await _videoReposiroty.UpdateVideo(id, video);
            return result ? Ok("Vídeo alterado com sucesso") : BadRequest("Problemas para alterar o vídeo");
        }
    }
}
