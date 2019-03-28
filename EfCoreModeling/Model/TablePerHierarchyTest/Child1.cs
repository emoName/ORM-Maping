using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreModeling.Model.TablePerHierarchy
{
    [Table("Child1Table")]
    class Child1 :ParentClass
    {
        public int? SomeChild_1_Value { get; set; }

    }
}
