using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WoofMe.Classes
{
    public interface IDogRepository
    {
        void AddDog(Dog dog);
        Dog GetDog(Guid dogId);
        List<Dog> GetAdopted();
        List<Dog> GetToBeAdpoted();
        List<Dog> GetFiltered(Func<Dog, bool> filterFunction);
        bool Adopt(Guid dogId);
        bool RemoveDog(Guid dogId);
        void Update(Dog newDoggie);
        void AddError(string text);
    }
}
