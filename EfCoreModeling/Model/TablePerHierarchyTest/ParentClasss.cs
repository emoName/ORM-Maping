﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreModeling.Model.TablePerHierarchy
{
    [Table("ParentTable")]
    class ParentClass
    {
        [Key]
        public int id { get; set; }
        public int SomeValueParent { get; set; }

    }
}
