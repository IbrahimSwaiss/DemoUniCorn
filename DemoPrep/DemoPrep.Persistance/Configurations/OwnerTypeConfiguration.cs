using DemoPrep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoPrep.Persistance.Configurations
{
    public class OwnerTypeConfiguration : AuditedEntityTypeConfiguration<int, Owner> {
        public override void Configure(EntityTypeBuilder<Owner> builder) {
            base.Configure(builder);
            builder.ToTable("Owners");
        }
    }
}