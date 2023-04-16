using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObraShalomAPI.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        
        [Required]        
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(80)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(2)]
        public string DDDWhats { get; set; }

        [Required]
        [StringLength(10)]
        public string Whats { get; set; }

        public bool Status { get; set; }
    }
}
