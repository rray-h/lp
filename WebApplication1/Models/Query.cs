using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Query
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Classification? Classification { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Problem { get; set; }
        [Required]
        public string Urgency { get; set; }
        public bool CanBeRedacted { get; set; }
        public bool hasTaken { get; set; }
        
    }
}
