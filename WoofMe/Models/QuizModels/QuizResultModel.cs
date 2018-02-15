using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoofMe.Models.DogModels;

namespace WoofMe.Models.QuizModels
{
    public class QuizResultModel
    {
        public List<PartialDogInfoModel> Doggies;

        public QuizResultModel()
        {
            Doggies = new List<PartialDogInfoModel>();
        }
    }
}
