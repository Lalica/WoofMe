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
            if (ModelState.IsValid)
            {
                var dogs = _repository.GetToBeAdpoted();
                var result = new QuizResultModel();
                if (dogs.Count == 0)
                {
                    return View("QuizResult", result);
                }
                var dict = new Dictionary<Dog, int>();
                foreach (var dog in dogs)
                {
                    dict[dog] = 0;
                }

                foreach (var dog in dogs)
                {
                    if (dog.Size==model.Size) dict[dog]++;
                    if (dog.HairLenght==model.HairLenght) dict[dog]++;
                    if (dog.Gender == model.Gender) dict[dog]++;
                    if (dog.GetAge().Equals(model.Age)) dict[dog]++;
                }
                
                var max = dict.Values.Max();

                foreach (var key in dict.Keys)
                {
                    if (dict[key].Equals(max)) result.Doggies.Add(new PartialDogInfoModel(key));
                }
                return View("QuizResult", result);
            }
            return View(model);
        }
    }
}
