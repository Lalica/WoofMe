using System.Collections.Generic;
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
