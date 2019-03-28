using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling.Model.TablePerHierarchy
{
    class ProgramPerH
    {

        public ProgramPerH()
        {

            var s = new ParentClass() {
                SomeValueParent = 000
            };
            ParentClass p = new Child1() {
                SomeValueParent=1,
                SomeChild_1_Value=11
            };
            var c = new Child2() {
                Descrioption = "||Child2 Description||",
                SomeValueParent = 2,
                SomeChild_2_Value = 22
            };

            using ( var context = new AppContext() )
            {
                context.parentClasses.Add(s);
                context.parentClasses.Add(p);
                context.Child2s.Add(c);
                context.SaveChanges();
            }

        }


    }
}
