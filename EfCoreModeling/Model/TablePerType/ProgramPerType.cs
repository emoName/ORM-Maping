using EfCoreModeling.Model.TablePerHierarchy;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling.Model.TablePerType
{
    class ProgramPerType
    {
        public ProgramPerType()
        {
            Child12 p = new Child12()
            {
                SomeValueParent = 1,
                SomeChild_1_Value = 11
            };
            var c = new Child22()
            {
                SomeValueParent = 2,
                SomeChild_2_Value = 22
            };

            using ( var context = new AppContext() )
            {
                context.child12s.Add(p);
                context.child22s.Add(c);
                context.SaveChanges();
            }
        }
    }
}
