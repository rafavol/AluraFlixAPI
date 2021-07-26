using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AluraFlixAPI.Models
{
    [DataContract]
    public class Video
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
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Descricao { get; set; }
        
        [Required]
        [Url]
        public string Url { get; set; }

    }
}
