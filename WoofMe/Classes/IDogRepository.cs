using System;
using System.Collections.Generic;

namespace WoofMe.Classes
{
    public interface IDogRepository
    {
        void AddDog(Dog dog);
        Dog GetDog(Guid dogId);
        List<Dog> GetAdopted();
        List<Dog> GetToBeAdpoted();
        bool Adopt(Guid dogId);
        bool RemoveDog(Guid dogId);
        void Update(Dog newDoggie);
        void AddError(string text);
    }
}
