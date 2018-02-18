using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
                dogs = _repository.GetAdopted().OrderBy(d=>d.Name).ToList();
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
                                    newDog.AddSize(model.Size);
                                    newDog.SetGender(model.Gender);
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
                dogs = _repository.GetToBeAdpoted().OrderBy(d => d.Name).ToList();
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

        [Authorize(Roles = "Employee")]
        public IActionResult Remove(Guid Id)
        {
            Dog dog = _repository.GetDog(Id);
            try
            {
                _repository.RemoveDog(dog.Id);
                return RedirectToAction("Adopted");
            }
            catch (Exception ex)
            {
                _repository.AddError(ex.Message);
                return RedirectToAction("Detail", Id);
            }
        }
        
        [Authorize(Roles = "Employee")]
        public IActionResult Edit(Guid Id)
        {
            Dog dog = _repository.GetDog(Id);
            EditDogModel editedDog = new EditDogModel
            {
                Id = dog.Id,
                Picture = dog.Picture,
                Race = dog.Race,
                BirthDate = dog.BirthDate,
                Gender = dog.Gender,
                HasHome = dog.HasHome,
                Info = dog.Info,
                Lenght = dog.HairLenght,
                Name = dog.Name,
                Size = dog.Size
            };

            return View("Edit", editedDog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Edit(EditDogModel editedDog)
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
                                editedDog.Picture = fileName;
                            }
                        }
                    }
                }
                Dog dog = _repository.GetDog(editedDog.Id);
                dog.Picture = editedDog.Picture;
                dog.Race = editedDog.Race;
                dog.BirthDate = editedDog.BirthDate;
                dog.Gender = editedDog.Gender;
                dog.HasHome = editedDog.HasHome;
                dog.Info = editedDog.Info;
                dog.HairLenght = editedDog.Lenght;
                dog.Name = editedDog.Name;
                dog.Size = editedDog.Size;

                try
                {
                    _repository.Update(dog);
                }
                catch (Exception ex)
                {
                    _repository.AddError(ex.Message);
                }
                if (dog.HasHome)
                {
                    return RedirectToAction("Adopted");
                }
                return RedirectToAction("Home");
            }
            return View(editedDog);
        }
    }
}