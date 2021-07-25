using AluraFlixAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlixAPI.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationContext context;

        public VideoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Video GetVideo(int id)
        {
            return context.Video.Where(v => v.Id == id).FirstOrDefault();
        }

        public IList<Video> GetVideos()
        {
            return context.Video.ToList();
        }

        public Video CreateVideo(Video video)
        {
            context.Video.Add(video);
            context.SaveChanges();
            return video;
        }
    }
}
