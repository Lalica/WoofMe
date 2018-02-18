using System.Collections.Generic;
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
