using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPPrueba.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }

        public string Vin { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public Owner owner { get; set; }
    }
}
