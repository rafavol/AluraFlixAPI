using AluraFlixAPI.Models;
using System.Collections.Generic;
using System.Linq;

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
            return context.Set<Video>().Where(v => v.Id == id).FirstOrDefault();
        }

        public IList<Video> GetVideos()
        {
            return context.Set<Video>().ToList();
        }

        public Video CreateVideo(Video video)
        {
            context.Set<Video>().Add(video);
            context.SaveChanges();
            return video;
        }
    }
}
