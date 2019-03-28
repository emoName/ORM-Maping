using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling.Model.TablePerHierarchy
{
    class Child2Config : IEntityTypeConfiguration<Child2>
    {
        public void Configure(EntityTypeBuilder<Child2> builder)
        {
            builder.Property("Descrioption");
        }
    }
}
