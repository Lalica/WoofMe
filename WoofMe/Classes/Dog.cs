using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WoofMe.Classes
{
    public class Dog
    {
        public String Name { get; set; }
        public string Picture { get; set; }
        public String Race { get; set; }
        public String Info { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid Id { get; set; }
        public bool HasHome { get; set; }
        public DogSize Size { get; set; }
        public HairLenght HairLenght { get; set; }
        //public List<String> Vaccines { get; set; }

        public Dog(String name, String race, DateTime birthDate, string picture)
        {
            Name = name;
            Race = race;
            HasHome = false;
            BirthDate = birthDate;
            Picture = picture;
            Id = Guid.NewGuid();
            //Vaccines = new List<string>();
        }
        public Dog()
        {
        }

        public string GetAge()
        {
            if ((DateTime.Now - BirthDate).Days < 1 * 365)
            {
                return "Baby";
            }
            if ((DateTime.Now - BirthDate).Days < 3 * 365)
            {
                return "Young";
            }
            if ((DateTime.Now - BirthDate).Days < 9 * 365)
            {
                return "Adult";
            }
            return "Old";
        }

        public void AddInfo(String text)
        {
            Info = text;
        }

        public void AddSize(DogSize size)
        {
            Size = size;
        }

        public void AddHairLenght(HairLenght lenght)
        {
            HairLenght = lenght;
        }

        //public bool AddVaccine(String vaccine)
        //{
        //    if (vaccine == null || Vaccines.Contains(vaccine))
        //    {
        //        return false;
        //    }
        //    Vaccines.Add(vaccine);
        //    return true;
        //}

        public bool Adopt()
        {
            if (!HasHome)
            {
                HasHome = true;
            }
            return HasHome;
        }
    }

    public enum DogSize
    {
        Small,
        Medium,
        Big
    }

    public enum HairLenght
    {
        Short,
        Medium,
        Long
    }
}
