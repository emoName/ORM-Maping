
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

            var _mail = new Email() { UserEmail = "Gheorghe@gmail.com", };
            emailRepository.Insert(_mail);
            _mail = new Email() { UserEmail = "Vasile@jora.com " };
            emailRepository.Insert(_mail);
            _mail = new Email() { UserEmail = "Jora&Vasile@ffrttt.md" };
            emailRepository.Insert(_mail);
            emailRepository.Save();

            var roleRepository = new GenericRepository<Role>();

            var _rol = new Role() { UserRole = "admin" };
            roleRepository.Insert(_rol);
            _rol = new Role() { UserRole = "Guest" };
            roleRepository.Insert(_rol);
            roleRepository.Save();

            var userRepository = new GenericRepository<User>();
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


            Console.WriteLine("-----------------<  Emails  >--------------------------");
            foreach ( var item in emailRepository.GetAll() )
            {
                Console.WriteLine(item.UserEmail);

            }

            Console.WriteLine("--------------------->------>--------->----------------");
            Console.WriteLine("-----------------<  Roles  >---------------------------");
            foreach ( var item in roleRepository.GetAll() )
            {
                Console.WriteLine(item.UserRole);
            }
            Console.WriteLine("--------------------->------>--------->----------------");
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
            Console.WriteLine("--------------------->------>--------->----------------");


            Console.ReadLine();

        }
    }
}
