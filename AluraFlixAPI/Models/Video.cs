using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AluraFlixAPI.Models
{
    public class Video : BaseModel
    {
        public Video()
        {

        }

        public Video(string titulo, string descricao, string url)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Url = url;
        }

        [Required]
        [StringLength(40, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Titulo { get; private set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Descricao { get; private set; }
        [Required]
        [Url]
        public string Url { get; private set; }

    }
}
