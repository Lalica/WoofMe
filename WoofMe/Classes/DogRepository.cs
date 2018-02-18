using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WoofMe.Classes
{
    public class DogRepository : IDogRepository
    {
        private readonly DogDbContext _context;

        public DogRepository(DogDbContext con)
        {
            _context = con;
        }
        public void AddDog(Dog doggie)
        {
            if (doggie == null)
            {
                throw new ArgumentNullException();
            }
            if (_context.Dogs.Any(t => t.Name == doggie.Name && t.BirthDate == doggie.BirthDate && t.Race == doggie.Race))
            {
                throw new DuplicateNameException("Duplicate dog: " + doggie.Id);
            }
            _context.Dogs.Add(doggie);
            _context.SaveChanges();
        }

        public Dog GetDog(Guid dogId)
        {
            return _context.Dogs.FirstOrDefault(t => t.Id == dogId);
        }

        public List<Dog> GetAdopted()
        {
            return _context.Dogs.Where(t => t.HasHome).ToList();
        }

        public List<Dog> GetToBeAdpoted()
        {
            return _context.Dogs.Where(t => !t.HasHome).ToList();
        }

        public bool Adopt(Guid dogId)
        {
            Dog oldDoggie = GetDog(dogId);
            if (oldDoggie == null)
            {
                return false;
            }
            bool b = oldDoggie.Adopt();
            Update(oldDoggie);
            return b;
        }

        public bool RemoveDog(Guid dogId)
        {
            Dog doggie = GetDog(dogId);
            if (doggie == null)
            {
                return false;
            }
            _context.Dogs.Remove(doggie);
            _context.SaveChanges();
            return true;
        }

        public void Update(Dog newDoggie)
        {
            Dog doggie = GetDog(newDoggie.Id);
            if (doggie != null)
            {
                _context.Dogs.Remove(doggie);
                _context.SaveChanges();
                doggie.Picture = newDoggie.Picture;
                doggie.Race = newDoggie.Race;
                doggie.BirthDate = newDoggie.BirthDate;
                doggie.Gender = newDoggie.Gender;
                doggie.HasHome = newDoggie.HasHome;
                doggie.Info = newDoggie.Info;
                doggie.HairLenght = newDoggie.HairLenght;
                doggie.Name = newDoggie.Name;
                doggie.Size = newDoggie.Size;
                _context.Dogs.Add(doggie);
                _context.SaveChanges();
            }
        }

        public void AddError(string text)
        {
            Errors error = new Errors(text);
            _context.Errors.Add(error);
            _context.SaveChanges();
        }
    }
}
