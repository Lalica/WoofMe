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
        public NotAdoptedDogsModel()
        {
            Doggies = new List<PartialDogInfoModel>();
        }
    }
}
