using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreModeling.Model.TablePerHierarchy
{
   [Table("Child22")]
    class Child22 :ParentClass2
    {
        public int? SomeChild_2_Value { get; set; }

    }
}
