﻿using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace WoofMe.Classes
{
    public class DogDbContext : DbContext
    {
        public IDbSet<Dog> Dogs { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Errors> Errors { get; set; }
        public DogDbContext(string cnnstr) : base(cnnstr)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dog>().HasKey(i => i.Id);
            modelBuilder.Entity<Dog>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<Dog>().Property(i => i.Race).IsRequired();
            modelBuilder.Entity<Dog>().Property(i => i.BirthDate).IsRequired();
            modelBuilder.Entity<Dog>().Property(i => i.Picture).IsRequired();
            modelBuilder.Entity<Dog>().Property(i => i.HasHome).IsRequired();
            modelBuilder.Entity<Dog>().Property(i => i.Info).IsOptional();
            modelBuilder.Entity<Dog>().Property(i => i.Size).IsOptional();
            modelBuilder.Entity<Dog>().Property(i => i.HairLenght).IsOptional();
            //modelBuilder.Entity<Dog>().HasMany(i => i.Vaccines);

            modelBuilder.Entity<User>().HasKey(i => i.Id);
            modelBuilder.Entity<User>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<User>().Property(i => i.EMail).IsRequired();

            modelBuilder.Entity<Errors>().HasKey(i => i.Id);
            modelBuilder.Entity<Errors>().Property(i => i.Text).IsRequired();
        }
    }
}