using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AluraFlixAPI.Models
{
    [DataContract]
    public class Categoria : BaseModel
    {
        public Categoria()
        {

        }

        public Categoria(string titulo, string cor)
        {
            Titulo = titulo;
            Cor = cor;
        }


        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Titulo { get; set; }
        [Required]
        [RegularExpression(@"((0x){0,1}|#{0,1})([0-9a-fA-F]{8}|[0-9a-fA-F]{6})", ErrorMessage = "A cor deve ser seguir o formato RGB (#FFFFFF)")]
        public string Cor { get; set; }
    }
}
