using System.ComponentModel.DataAnnotations;

namespace Api___intro.DTOs.Country
{
    public class UpdateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
