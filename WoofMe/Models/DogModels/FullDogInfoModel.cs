using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WoofMe.Classes;

namespace WoofMe.Models.DogModels
{
    public class FullDogInfoModel
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
        public int Age { get; set; }

        [Required]
        [Display(Name = "Birth date")]
        public string BirthDate { get; set; }

        [Required]
        [Display(Name = "Race")]
        public string Race { get; set; }

        [Display(Name = "Info")]
        public string Info { get; set; }

        public FullDogInfoModel(Dog dog)
        {
            Id = dog.Id;
            Name = dog.Name;
            Race = dog.Race;
            Info = dog.Info;
            Picture = dog.Picture;
            Age = (int) (dog.BirthDate - DateTime.Now).TotalDays / 365;
            BirthDate = dog.BirthDate.ToString();
        }

        public FullDogInfoModel()
        {
        }
    }
}
