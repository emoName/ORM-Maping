using EfCoreModeling.Model;
using EfCoreModeling.Model.TablePerHierarchy;
using EfCoreModeling.Model.TablePerType;
using EfCoreModeling.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCoreModeling
{
    class ShowClass
    {
        AppContext _context;

        public ShowClass()
        {
            _context = new AppContext();



            //ShowGruping();
            //SelectManyProjection();
            //DinamicQuery();
            //SelectMagicString();



            //_context.Messages.Where(x => x.Date.Month == DateTime.Now.Month).GroupBy(x => x.UserId).Select(x => new
            //{
            //    UserName = x.Key,
            //    NrMessage = x.Count()
            //})
            //.OrderBy(f => f.NrMessage)
            //.ToList();


            //var a = _context.users.Where(x => x.Message.Where(y => y.Date.Month == DateTime.Now.Month)
            //.Select(f => new { f.Description)}).Select(x => new
            //{
            //    userName = x.UserName,
            //    NrMessages = x.Message.Count()

            //})
            //  .ToList();


            var aaa = _context.users.Select(x => new
            {
                userName = x.UserId,
                NrMessages = x.Message.Count(y=> y.Date.Month == DateTime.Now.Month),
            }
            )
                .ToList();



        }

        private void SelectMagicString()
        {
            var UserData = _context.Messages.FromSql("Select * from [Messages]")
                  .Where(x => x.UserId != 1)
                  .Select(x => new
                  {
                      UserID = x.UserId,
                      UserMessage = x.Description
                  }).ToList();

            var AllMessagesExcept2 = _context.Messages
                .FromSql("select * from [Messages] where UserId<>@id ", 2)
                .Select(x => x.Description)
                .ToList();

        }

        private void DinamicQuery()
        {

            IQueryable<Message> query = _context.Messages;

            if ( true )
            {
                query.Where(x => x.UserId != 1);
            }
            if ( 2>7 )
            {
                query.Where(x => x.Description.Length > 5);
            }
            if ( true )
            {
                query.Where(x => x.Description.Contains("a"));
            }


            query.Select(x => new
            {
                UserId = x.UserId,
                Description = x.Description
            }).ToList();


        }

        private void SelectManyProjection()
        {
            //selecting
            var UserContent = _context.users.AsNoTracking().SelectMany(x => x.Message, (x, y) => new
            {
                UserName = x.UserName,
                Description = y.Description
            }).ToList();

            // Projrction


            var a = _context.users.AsNoTracking().Select(x => new
            {

                UserName = x.UserName,
                AdrressID = x.AdrresId ?? 88,
                RoleID = x.RoleID != null ? x.RoleID : 88

            }).ToList();


        }

        private void ShowGruping()
        {
            var grouping = _context.Messages
                .Where(x => x.UserId != 1)
                .GroupBy(x => x.UserId)
                .Select(x =>
            new
            {
                UserId = x.Key,
                MessageEverege = x.Average(y => y.Description.Length),
                NrMesages = x.Count()
            })
            .Where(x => x.NrMesages > 1)
            .ToList();

            var grpoupJoin = _context.users.GroupJoin(
                _context.Messages,
                a => a.UserId,
                b => b.UserId,
                (x, yy) => new
                {
                    UserName = x.UserName,
                    Description = yy.Select(v => v.Description)
                }
                ).ToList();
        }


    }
}
