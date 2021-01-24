using DemoPrep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoPrep.Persistance.Configurations {
    public class AdminTypeConfiguration : AuditedEntityTypeConfiguration<int, Admin> {
        public override void Configure(EntityTypeBuilder<Admin> builder) {
            base.Configure(builder);
            builder.ToTable("Admins");
        }
    }
}
