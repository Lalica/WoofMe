﻿using System;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Breed")]
        public string Race { get; set; }

        [Display(Name = "Info")]
        public string Info { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        public FullDogInfoModel(Dog dog)
        {
            Id = dog.Id;
            Name = dog.Name;
            Race = dog.Race;
            Info = dog.Info;
            Picture = dog.Picture;
            Age = (int) (DateTime.Now - dog.BirthDate).TotalDays / 365;
            BirthDate = dog.BirthDate.ToString();
            Gender = dog.Gender;
        }

        public FullDogInfoModel()
        {
        }
    }
}
