using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreModeling.Model.TablePerHierarchy
{
    [Table("Child12")]
    class Child12 :ParentClass2
    {
        public int? SomeChild_1_Value { get; set; }

    }
}
