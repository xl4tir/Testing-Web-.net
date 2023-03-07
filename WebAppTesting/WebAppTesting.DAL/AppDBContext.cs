using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppTesting.Domain.Entity;
using WebAppTesting.Domain.Enum;
using WebAppTesting.Domain.Helpers;

namespace WebAppTesting.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Testing> Testing { get; set; }
       public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Tests> Tests { get; set; }
        public DbSet<Answers> Answers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasData(new User
                {
                    Id = 1,
                    Name = "xl4tir",
                    Password = HashPasswordHelper.HashPassword("home2022"),
                    Role = Role.Admin
                });
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();


                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            }
            );


            
        }



    }
}
