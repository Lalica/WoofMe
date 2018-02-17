using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WoofMe.Classes;

namespace WoofMe.Models.DogModels
{
    public class PartialDogInfoModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Age")]
        public string Age { get; set; }
        [Required]
        [Display(Name = "Breed")]
        public string Race { get; set; }
        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        public PartialDogInfoModel(Dog dog)
        {
            Id = dog.Id;
            Name = dog.Name;
            Picture = dog.Picture;
            Age = dog.GetAge();
            Race = dog.Race;
            Size = dog.Size.ToString().ToLower();
            Gender = dog.Gender.ToString().ToLower(); ;
        }
    }
}
