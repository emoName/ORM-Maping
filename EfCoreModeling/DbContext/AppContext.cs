using EfCoreModeling.Configuration;
using EfCoreModeling.Model;
using EfCoreModeling.Model.TablePerHierarchy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
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


        //TablePerHierarchy
        public DbSet<ParentClass> parentClasses { get; set; }
        public DbSet<Child1> Child1s { get; set; }
        public DbSet<Child2> Child2s { get; set; }
        //Table Per Type 
        public DbSet<Child12> child12s { get; set; }
        public DbSet<Child22> child22s { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
            //                             Initial Catalog=MyNewDatabase;
            //                             Integrated Security=True;
            //                             ApplicationIntent =ReadWrite;
            //                           ");
            optionsBuilder.UseSqlServer(@"
                                          Data Source = MDDSK40076\DB_ION;
                                          Initial Catalog = EfCoreMaping;
                                          Integrated Security = True;"
                                        );

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
