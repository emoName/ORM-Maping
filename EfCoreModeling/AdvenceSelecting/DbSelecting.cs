using EfCoreModeling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCoreModeling.AdvenceSelecting
{
    class DbSelecting
    {
        AppContext context;
        public DbSelecting()
        {
            context = new AppContext();



        //    ShowGroupBy();
            ShowSelectMany();

        }

        public void ShowGroupBy()
        {
            var usersRoles = context.users.GroupBy(x=>x.RoleID).Select(x=> new {
                Role=x.Key,
                count=x.Count()
            });
            var uRoleWhere = context.users.Select(x => new
            {
                UserName = x.UserName,
                UserEmail = x.EmailId
            }).Where(x => x.UserEmail > 2);
            var groupJoin = context.users.GroupJoin(
                context.Messages,
                a => a.UserId,
                b => b.UserId,
                (x, col) => new {
                    a=x.UserName,
                    b=col.Select(c=>c.Description)
                }
                );

            foreach ( var item in uRoleWhere )
            {
                Console.WriteLine(item.UserName+item.UserEmail);
            }
            foreach ( var item in usersRoles )
            {
                Console.WriteLine(item.Role+item.count);
            }
        }
        public void ShowSelectMany()
        {
            var userMessages = context.users.SelectMany(x => x.Message, (a, b) => new
            {
                UserName = a.UserName,
                Mesages = b.Description
            }).ToList();

            foreach ( var item in userMessages )
            {
                Console.WriteLine(item.UserName+item.Mesages);
            }



            return;


        }


    }
}
