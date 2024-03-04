using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Election
    {
        [Key]
        public int UpdatedId { get; set; }

        [Required]
        public DateTime LastTime;

        [Required]
        public double Condidate1 { get; set; }

        [Required]
        public double Candidate2 { get; set; }
    }
}
