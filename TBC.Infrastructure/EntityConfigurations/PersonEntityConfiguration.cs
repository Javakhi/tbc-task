using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.Entities;

namespace TBC.Infrastructure.EntityConfigurations
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.PersonalNumber).IsUnique();
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);
            builder.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId)
                .OnDelete(deleteBehavior: DeleteBehavior.SetNull);
        }
    }
}
