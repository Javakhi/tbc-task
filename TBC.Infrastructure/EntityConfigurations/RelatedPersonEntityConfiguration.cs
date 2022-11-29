using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.Entities;

namespace TBC.Infrastructure.EntityConfigurations
{
    public class RelatedPersonEntityConfiguration : IEntityTypeConfiguration<RelatedPersonEntity>
    {
        public void Configure(EntityTypeBuilder<RelatedPersonEntity> builder)
        {
            builder.HasKey(x => x.PersonId);
            builder.HasIndex(x => x.PersonType);
        }
    }
}
