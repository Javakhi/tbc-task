using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.Entities;

namespace TBC.Infrastructure.EntityConfigurations
{
    public class PersonNumberEntityConfiguration : IEntityTypeConfiguration<PersonNumber>
    {
        public void Configure(EntityTypeBuilder<PersonNumber> builder)
        {
            builder.HasKey(x => x.PersonId);
            builder.HasIndex(x => x.Number);
        }
    }
}
