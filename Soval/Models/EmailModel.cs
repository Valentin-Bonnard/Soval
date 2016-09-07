using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Soval.Models
{
    public class EmailModel
    {
        [Display(Name = "Nom :")]
        [Required]
        public string _name { get; set; }
        [Display(Name = "Email :")]
        [Required]
        public string _email { get; set; }
        [Display(Name = "Object :")]
        [Required]
        public string _subject { get; set; }
        [MaxLength(140), MinLength(20), Display(Name = "Commentaire :")]
        public string _comment { get; set; }
    }
}