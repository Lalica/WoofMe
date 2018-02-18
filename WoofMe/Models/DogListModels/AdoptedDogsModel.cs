using System.Collections.Generic;
using WoofMe.Models.DogModels;

namespace WoofMe.Models.DogListModels
{
    public class AdoptedDogsModel
    {
        public List<PartialDogInfoModel> Doggies;

        public AdoptedDogsModel()
        {
            Doggies = new List<PartialDogInfoModel>();
        }
    }
}
