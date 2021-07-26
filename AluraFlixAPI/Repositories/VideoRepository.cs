using AluraFlixAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Video> GetVideo(int id)
        {
            return await context.Video.FindAsync(id);
        }

        public async Task<IList<Video>> GetVideos()
        {
            return await context.Video.ToListAsync();
        }

        public async Task<Video> CreateVideo(Video video)
        {
            context.Video.Add(video);
            await context.SaveChangesAsync();
            return video;
        }

        private Video GetVideoById(int id)
        {
            return context.Video.Find(id);
        }

        public async Task<bool> DeleteVideo(int id)
        {
            var videoToRemove = GetVideoById(id);
            if (videoToRemove == null)
            {
                return false;
            }
            context.Video.Remove(videoToRemove);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateVideo(int id, Video video)
        {
            if (id != video.Id)
            {
                return false;
            }

            context.Entry(video).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool VideoExists(int id)
        {
            return context.Video.Any(e => e.Id == id);
        }
    }
}
