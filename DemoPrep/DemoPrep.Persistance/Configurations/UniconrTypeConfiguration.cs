using DemoPrep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoPrep.Persistance.Configurations {
    public class UniconrTypeConfiguration : AuditedEntityTypeConfiguration<int, Unicorn> {
        public override void Configure(EntityTypeBuilder<Unicorn> builder) {
            base.Configure(builder);
            builder.ToTable("Unicorns");
        }
    }
}
