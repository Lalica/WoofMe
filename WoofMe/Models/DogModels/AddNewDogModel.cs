using System;
using System.ComponentModel.DataAnnotations;
using WoofMe.Classes;

namespace WoofMe.Models.DogModels
{
    public class AddNewDogModel
    {
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Breed")]
        public string Race { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Required]
        [Display(Name = "Dog Size")]
        public DogSize Size { get; set; }
        [Required]
        [Display(Name = "Hair Lenght")]
        public HairLenght Lenght { get; set; }
    }
}
