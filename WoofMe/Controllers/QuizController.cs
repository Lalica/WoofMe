using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoofMe.Classes;
using WoofMe.Models.DogListModels;
using WoofMe.Models.DogModels;
using WoofMe.Models.QuizModels;

namespace WoofMe.Controllers
{
    public class QuizController : Controller
    {
        private readonly IDogRepository _repository;
        
        public QuizController(IDogRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Quiz()
        {
            return View();
        }

        public IActionResult QuizResult()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Quiz(QuizModel model)
        {
            List<Dog> dogs = _repository.GetToBeAdpoted();
            dogs = dogs.Where(i => i.Size == model.Size && i.HairLenght == model.HairLenght && i.GetAge() == model.Age)
                .ToList();
            QuizResultModel result = new QuizResultModel();
            foreach(Dog d in dogs)
            {
                PartialDogInfoModel dog = new PartialDogInfoModel(d);
                result.Doggies.Add(dog);
            }
            return View("QuizResult",result);
        }
    }
}