using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name = "Preffered gender")]
        public Gender Gender { get; set; }
    }
}
