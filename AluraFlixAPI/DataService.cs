using AluraFlixAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlixAPI
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;
        private readonly IVideoRepository videoRepository;

        public DataService(ApplicationContext context, IVideoRepository videoRepository)
        {
            this.context = context;
            this.videoRepository = videoRepository;
        }

        public void InicializaDB()
        {
            context.Database.Migrate();
        }
    }
}
