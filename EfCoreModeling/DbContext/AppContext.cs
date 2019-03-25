using EfCoreModeling.Configuration;
using EfCoreModeling.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling
{
    internal class AppContext : DbContext
    {

        public DbSet<User> users { get; set; }
        public DbSet<Adrres> Adrres { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                         Initial Catalog=MyNewDatabase;
                                         Integrated Security=True;
                                         ApplicationIntent =ReadWrite;
            ");
            //   base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsersConfiguration());

            //    base.OnModelCreating(modelBuilder);
        }

    }
}
