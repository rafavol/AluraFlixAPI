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
        public IEnumerable<Video> Get()
        {

            return _videoReposiroty.GetVideos();
        }

        // GET: Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> Get(int id)
        {
            var video = _videoReposiroty.GetVideo(id);
            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // POST: Videos/
        [HttpPost]
        public Video Post(Video video)
        {
            return _videoReposiroty.CreateVideo(video);
        }
    }
}
