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
        [Display(Name = "Race")]
        public string Race { get; set; }
        [Required]
        [Display(Name = "Race")]
        public string Size { get; set; }

        public PartialDogInfoModel(Dog dog)
        {
            Id = dog.Id;
            Name = dog.Name;
            Picture = dog.Picture;
            Age = dog.GetAge().ToLower();
            Race = dog.Race.ToLower();
            Size = dog.Size.ToString().ToLower();
        }
    }
}
