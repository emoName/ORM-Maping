
using EfCoreModeling.AdvenceSelecting;
using EfCoreModeling.Model;
using EfCoreModeling.Model.TablePerHierarchy;
using EfCoreModeling.Model.TablePerType;
using EfCoreModeling.Repository;
using System;
using System.Linq;

namespace EfCoreModeling
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateConcurency();

            ShowExperiment();

            var emailRepository = new GenericRepository<Email>();
            Email _mail = AddEmails(emailRepository);

            var roleRepository = new GenericRepository<Role>();

            Role _rol = AddRoles(roleRepository);

            var userRepository = new GenericRepository<User>();
            AddUsers(emailRepository, _mail, roleRepository, _rol, userRepository);

            ShowEmails(emailRepository);

            Console.WriteLine("--------------------->------>--------->----------------");
            ShowRoles(roleRepository);
            Console.WriteLine("--------------------->------>--------->----------------");
            ShowUsers(userRepository);
            Console.WriteLine("--------------------->------>--------->----------------");


            Console.ReadLine();

        }

        private static void UpdateConcurency()
        {
            var email = new Email() { UserEmail = "asdfg@lkjh.md" };

            var context = new AppContext();

            try
            {
                context.Emails.Add(email);
                context.SaveChanges();
                email.UserEmail = "gfdsaa@lki.com";

                email.UserEmail = "gfdssssssaa@lki.com";

                context.SaveChanges();
            }
            catch ( Exception )
            {
                Console.WriteLine("Concurency  Exception !!!");
            }
        }

        private static void ShowExperiment()
        {
            var th = new ProgramPerH();
            var tc = new ProgramPerType();
            using ( var context = new AppContext() )
            {
                var parent = context.parentClasses.ToList();
                foreach ( var item in parent )
                {
                    if ( item is Child1 aa )
                    {
                        Console.WriteLine($"Child1 : {aa.id}  {aa.SomeValueParent}  {aa.SomeChild_1_Value}");
                        continue;
                    }
                    if ( item is Child2 bb )
                    {
                        Console.WriteLine($"Child1 : {bb.id}  {bb.SomeValueParent}  {bb.SomeChild_2_Value}  {bb.GetDescrioption()}");
                        continue;
                    }

                    Console.WriteLine($"Parent : {item.id}  {item.SomeValueParent}");
                }

                foreach ( var item in context.child12s.ToList() )
                {
                    Console.WriteLine($"Child12 : {item.id}  {item.SomeValueParent}  {item.SomeChild_1_Value}");
                }
                foreach ( var item in context.child22s.ToList() )
                {
                    Console.WriteLine($"Child12 : {item.id}  {item.SomeValueParent}  {item.SomeChild_2_Value}");
                }

            }
        }

        private static void ShowUsers(GenericRepository<User> userRepository)
        {
            Console.WriteLine("-----------------<  Users  >---------------------------");
            foreach ( var item in userRepository.GetAll() )
            {
                Console.WriteLine("======================================================");
                Console.WriteLine(item.UserId +
                                  " " + item.UserName +
                                  " " + item.RoleID +
                                  " " + item.EmailId +
                                  " " + item.AdrresId
                                  );
                //  Console.WriteLine(item.UserId + " " + item.UserName + " " + item.Role.UserRole + " " + item.Email.UserEmail);
                Console.WriteLine("======================================================");

            }
        }

        private static void ShowRoles(GenericRepository<Role> roleRepository)
        {
            Console.WriteLine("-----------------<  Roles  >---------------------------");
            foreach ( var item in roleRepository.GetAll() )
            {
                Console.WriteLine(item.UserRole);
            }
        }

        private static void ShowEmails(GenericRepository<Email> emailRepository)
        {
            Console.WriteLine("-----------------<  Emails  >--------------------------");
            foreach ( var item in emailRepository.GetAll() )
            {
                Console.WriteLine(item.UserEmail);

            }
        }

        private static void AddUsers(GenericRepository<Email> emailRepository,
                                     Email _mail,
                                     GenericRepository<Role> roleRepository,
                                     Role _rol,
                                     GenericRepository<User> userRepository)
        {
            var _user = new User()
            {
                UserName = "Ghiorghe",
                RoleID = _rol.RoleId,
                EmailId = _mail.EmailId,
                Adrres = new Adrres() { Adrress = "str.Chisinau 5" }
            };
            userRepository.Insert(_user);
            _user = new User()
            {
                UserName = "Vasile",
                RoleID = roleRepository.GetById((int)1).RoleId,
                EmailId = emailRepository.GetById((int)2).EmailId
            };
            userRepository.Insert(_user);
            userRepository.Save();
        }

        private static Role AddRoles(GenericRepository<Role> roleRepository)
        {
            var _rol = new Role() { UserRole = "admin" };
            roleRepository.Insert(_rol);
            _rol = new Role() { UserRole = "Guest" };
            roleRepository.Insert(_rol);
            roleRepository.Save();
            return _rol;
        }

        private static Email AddEmails(GenericRepository<Email> emailRepository)
        {
            var _mail = new Email() { UserEmail = "Gheorghe@gmail.com", };
            emailRepository.Insert(_mail);
            _mail = new Email() { UserEmail = "Vasile@jora.com " };
            emailRepository.Insert(_mail);
            _mail = new Email() { UserEmail = "Jora&Vasile@ffrttt.md" };
            emailRepository.Insert(_mail);
            emailRepository.Save();
            return _mail;
        }
    }
}
