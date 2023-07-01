using System.ComponentModel.DataAnnotations;

namespace Api___intro.DTOs.Country
{
    public class CreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
