using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ilumno.TechnicalTest.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Contact's name. ")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Contact's lastname. ")]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Phone number must be between 7 and 50 digits", MinimumLength = 7)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Cell Phone number must be between 7 and 50 digits", MinimumLength = 7)]
        [Display(Name = "Cell Phone Number")]
        public string CellPhoneNumber { get; set; }
    }
}