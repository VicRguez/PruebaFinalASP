using System.ComponentModel.DataAnnotations;

namespace ASPPrueba.Models
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime Date { get; set; }

        public Vehicle Vehicle { get; set; }

    }
}
