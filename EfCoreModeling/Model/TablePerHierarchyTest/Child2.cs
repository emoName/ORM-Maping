using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreModeling.Model.TablePerHierarchy
{
    [Table("Child2Table")]
    class Child2 :ParentClass
    {
        public string Descrioption;
        public string GetDescrioption()
        {
            return Descrioption;
        }
        public void SetDescrioption(string value)
        {
             Descrioption=value;
        }  

        public int? SomeChild_2_Value { get; set; }

    }
}
