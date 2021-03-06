﻿using EfCoreModeling.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling.Configuration
{
    class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasIndex(x => x.UserEmail).IsUnique();
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasData(new { UserEmail = "FirstExample@Test.Com", EmailId = 1 });
        }
    }
}
