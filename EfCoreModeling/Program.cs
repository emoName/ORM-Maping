
using EfCoreModeling.Model;
using EfCoreModeling.Repository;
using System;

namespace EfCoreModeling
{
    class Program
    {
        static void Main(string[] args)
        {

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
                EmailId = _mail.EmailId
            };
            userRepository.Insert(_user);
            _user = new User()
            {
                UserName = "Vasile",
                RoleID = roleRepository.GetById((long)1).RoleId,
                EmailId = emailRepository.GetById((long)2).EmailId
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
