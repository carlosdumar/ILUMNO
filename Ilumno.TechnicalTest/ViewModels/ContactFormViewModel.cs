using Ilumno.TechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ilumno.TechnicalTest.ViewModels
{
    public class ContactFormViewModel
    {
        public ContactFormViewModel()
        {
            Id = 0;
        }

        public ContactFormViewModel(Contact contact)
        {
            Id = contact.Id;
            Name = contact.Name;
            Email = contact.Email;
            PhoneNumber = contact.PhoneNumber;
            CellPhoneNumber = contact.CellPhoneNumber;
        }

        public int? Id { get; set; }

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