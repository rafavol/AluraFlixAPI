using AluraFlixAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraFlixAPI.Repositories
{
    public interface IVideoRepository
    {
        Task<Video> CreateVideo(Video video);
        Task<bool> DeleteVideo(int id);
        Task<Video> GetVideo(int id);
        Task<IList<Video>> GetVideos();
        Task<bool> UpdateVideo(int id, Video video);
        IList<Video> GetVideosByCategoriaId(int categoriaId);
        IList<Video> GetVideosWithTitle(string search);
    }
}