using AluraFlixAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlixAPI.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationContext context;

        public CategoriaRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Categoria GetCategoria(int id)
        {
            return context.Categoria.Find(id);
        }

        public IList<Categoria> GetCategorias()
        {
            return context.Categoria.ToList();
        }

        public Categoria CreateCategoria(Categoria categoria)
        {
            if (!CategoriaExists(categoria.Id)) {
                context.Categoria.Add(categoria);
                context.SaveChanges();
                
            }
            return context.Categoria.Find(categoria.Id);
        }

        private Categoria GetCategoriaById(int id)
        {
            return context.Categoria.Find(id);
        }

        public bool DeleteCategoria(int id)
        {
            var categoriaToRemove = GetCategoriaById(id);
            if (categoriaToRemove == null)
            {
                return false;
            }
            context.Categoria.Remove(categoriaToRemove);
            context.SaveChanges();
            return true;
        }

        public bool UpdateCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return false;
            }

            context.Entry(categoria).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        private bool CategoriaExists(int id)
        {
            return context.Categoria.Any(e => e.Id == id);
        }
    }
}
