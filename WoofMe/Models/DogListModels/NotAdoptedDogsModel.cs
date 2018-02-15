using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoofMe.Classes;
using WoofMe.Models.DogModels;

namespace WoofMe.Models.DogListModels
{
    public class NotAdoptedDogsModel
    {
        public List<PartialDogInfoModel> Doggies;
        public bool RaceSelected { get; set; }
        public string RaceFilter { get; set; }
        public bool SizeSelected { get; set; }
        public string SizeFilter { get; set; }
        public bool AgeSelected { get; set; }
        public string AgeFilter { get; set; }

        public NotAdoptedDogsModel()
        {
            Doggies = new List<PartialDogInfoModel>();
            RaceSelected = false;
            SizeSelected = false;
            AgeSelected = false;
        }
    }
}
