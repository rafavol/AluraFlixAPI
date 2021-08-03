using AluraFlixAPI.Models;
using System.Collections.Generic;

namespace AluraFlixAPI.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria CreateCategoria(Categoria categoria);
        bool DeleteCategoria(int id);
        Categoria GetCategoria(int id);
        IList<Categoria> GetCategorias();
        bool UpdateCategoria(int id, Categoria categoria);
    }
}