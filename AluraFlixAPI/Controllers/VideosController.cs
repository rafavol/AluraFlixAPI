using AluraFlixAPI.Models;
using AluraFlixAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AluraFlixAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OLDVideosController : ControllerBase
    {
        private readonly IVideoRepository _videoReposiroty;

        private readonly ILogger<OLDVideosController> _logger;

        public OLDVideosController(ILogger<OLDVideosController> logger,
            IVideoRepository videoReposiroty)
        {
            _logger = logger;
            _videoReposiroty = videoReposiroty;
        }

        // GET: api/Videos
        public IEnumerable<Video> Get()
        {

            return _videoReposiroty.GetVideos();
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var video = _videoReposiroty.GetVideo(id);
            if (video == null)
            {
                return "{message: \"Não encontrado\"}";
            }
            var jsonString = JsonSerializer.Serialize(video);
            return jsonString;
        }

        // POST: api/Videos
        [HttpPost]
        public Video Post(Video video)
        {
            return _videoReposiroty.CreateVideo(video);
        }
    }
}
