
using EfCoreModeling.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling.Configuration
{
    class AdrressConfiguration : IEntityTypeConfiguration<Adrres>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Adrres> builder)
        {
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasData(new Adrres() { AdrresId = 1, Adrress = "Str.Ismail" });

        }
    }
}
