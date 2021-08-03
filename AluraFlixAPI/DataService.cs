using AluraFlixAPI.Models;
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
        private readonly ICategoriaRepository categoriaRepository;

        public DataService(ApplicationContext context, 
            IVideoRepository videoRepository,
            ICategoriaRepository categoriaRepository)
        {
            this.context = context;
            this.videoRepository = videoRepository;
            this.categoriaRepository = categoriaRepository;
        }

        public void InicializaDB()
        {
            context.Database.EnsureCreated();
            categoriaRepository.CreateCategoria(new Categoria{
                Id = 1,
                Titulo = "LIVRE",
                Cor = "#FFFFFF"
            });
        }
    }
}
