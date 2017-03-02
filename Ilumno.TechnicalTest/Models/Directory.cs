using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ilumno.TechnicalTest.Models
{
    public class Directory
    {
        public int Id { get; set; }

        [Required]
        public List<Contact> Contact { get; set; }

        public DateTime DateAdded { get; set; }
    }
}