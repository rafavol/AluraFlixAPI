using AluraFlixAPI.Models;
using System.Collections.Generic;

namespace AluraFlixAPI.Repositories
{
    public interface IVideoRepository
    {
        Video CreateVideo(Video video);
        Video GetVideo(int id);
        IList<Video> GetVideos();
    }
}