using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WoofMe.Classes;

namespace WoofMe.Models.QuizModels
{
    public class QuizModel
    {
        [Required]
        [Display(Name = "Prefferd size")]
        public DogSize Size { get; set; }
        [Required]
        [Display(Name = "Preffered hair lenght")]
        public HairLenght HairLenght{ get; set; }
        [Required]
        [Display(Name = "Preffered age")]
        public string Age { get; set; }
    }
}
