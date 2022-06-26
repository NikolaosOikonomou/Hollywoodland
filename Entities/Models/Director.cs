using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    internal class Director : HollywoodEntity
    {
        public int DirectorId { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Country Country { get; set; }
        [Display(Name = "Photo URL")]
        public string PhotoUrl { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Date of Death")]
        public DateTime? DateOfDeath { get; set; }
        [NotMapped]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //Navigation Properties
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
