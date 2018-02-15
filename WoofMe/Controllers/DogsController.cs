using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WoofMe.Classes;
using WoofMe.Models;
using WoofMe.Models.DogListModels;
using WoofMe.Models.DogModels;

namespace WoofMe.Controllers
{
    public class DogsController : Controller
    {
        private readonly IDogRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _appEnvironment;


        public DogsController(IDogRepository repository, UserManager<ApplicationUser> userManager, IHostingEnvironment appEnvironment)
        {
            _repository = repository;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
    }

        [HttpGet]
        public IActionResult Adopted()
        {
            List<Dog> dogs;
            PartialDogInfoModel partialDog;
            AdoptedDogsModel model = new AdoptedDogsModel();
            try
            {
                dogs = _repository.GetAdopted();
                foreach (Dog d in dogs)
                {
                    partialDog = new PartialDogInfoModel(d);
                    model.Doggies.Add(partialDog);
                }
            }
            catch (Exception ex)
            {
                _repository.AddError(ex.Message);
                return View("Error");
            }
            return View(model);
        }

        [Authorize(Roles="Employee, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDog(AddNewDogModel model)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                if (ModelState.IsValid)
                {
                    var files = HttpContext.Request.Form.Files;
                    foreach (var Image in files)
                    {
                        if (Image != null && Image.Length > 0)
                        {
                            var file = Image;
                            var uploads = Path.Combine(_appEnvironment.WebRootPath, "images");
                            if (file.Length > 0)
                            {
                                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                    var newDog = new Dog(model.Name, model.Race, model.BirthDate, fileName);
                                    if (model.Info != null)
                                    {
                                        newDog.AddInfo(model.Info);
                                    }
                                    newDog.AddSize(model.Size);
                                    newDog.AddHairLenght(model.Lenght);
                                    _repository.AddDog(newDog);
                                    return RedirectToAction("Home");
                                }
                            }
                        }
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                _repository.AddError(ex.Message);
                return View("Error");
            }
            return View(model);
        }

        [Authorize(Roles = "Employee, Admin")]
        public IActionResult AddDog()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            List<Dog> dogs;
            PartialDogInfoModel partialDog;
            NotAdoptedDogsModel model = new NotAdoptedDogsModel();
            try
            {
                dogs = _repository.GetToBeAdpoted();
                foreach (Dog d in dogs)
                {
                    partialDog = new PartialDogInfoModel(d);
                    model.Doggies.Add(partialDog);
                }
            }
            catch (Exception ex)
            {
                _repository.AddError(ex.Message);
                return View("Error");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ApplyFilters(NotAdoptedDogsModel model)
        {
            model.Doggies = model.AgeSelected ? model.Doggies.Where(d => d.Age == model.AgeFilter).ToList() : model.Doggies;
            model.Doggies = model.RaceSelected ? model.Doggies.Where(d => d.Race == model.RaceFilter).ToList() : model.Doggies;
            model.Doggies = model.SizeSelected ? model.Doggies.Where(d => d.Size == model.SizeFilter).ToList() : model.Doggies;
            return View("Home",model);
        }

        [HttpGet]
        public IActionResult Detail(Guid Id)
        {
            Dog dog =_repository.GetDog(Id);
            FullDogInfoModel fullDog = new FullDogInfoModel(dog);
            return RedirectToAction("DetailDog",fullDog);
        }

        [HttpGet]
        public IActionResult DetailDog(FullDogInfoModel dog)
        {
            return View(dog);
        }
    }
}