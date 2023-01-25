using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        public string FullName { get; set; }
        [StringLength(maximumLength: 50)]
        public string Profession { get; set; }  
        public string? Imagge { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string Action { get; set; }  
    }
}
