using System.ComponentModel.DataAnnotations;

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

        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Titulo { get; set; }

        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Descricao { get; set; }
        
        [Url]
        public string Url { get; set; }

    }
}
