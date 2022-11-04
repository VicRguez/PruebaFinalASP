using System.ComponentModel.DataAnnotations;

namespace ASPPrueba.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string DriverLicense { get; set; }
    }
}
