using EfCoreModeling.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling.Configuration
{
    class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.RowVersion).IsRowVersion();
            //builder.HasData(
            //    new Message() { MessageId = 1, Description = "Hello ",  },
            //    new Message() { MessageId = 2, Description = "World !!! " }
            //    );
        }
    }
}
