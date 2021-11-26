using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PavApp.Models
{
    public class Empreado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string? LastName { get; set; }

        public int Year { get; set; }


    }
}
