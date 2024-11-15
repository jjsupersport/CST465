using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    public class ImageModel
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string Description { get; set; }
    }

}
