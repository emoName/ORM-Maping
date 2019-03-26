
using EfCoreModeling.Model;
using EfCoreModeling.Repository;
using System;

namespace EfCoreModeling
{
    class Program
    {
        static void Main(string[] args)
        {

            var _repository = new GenericRepository<Email>();

            var u = new Email() { UserEmail = "Gheorghe@gmail.com", };
            _repository.Insert(u);
            _repository.Save();

            foreach ( var item in _repository.GetAll() )
            {
                Console.WriteLine(item.UserEmail);

            }



            Console.ReadLine();

        }
    }
}
