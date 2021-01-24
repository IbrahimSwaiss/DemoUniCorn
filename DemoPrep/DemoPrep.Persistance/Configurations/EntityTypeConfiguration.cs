using DemoPrep.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoPrep.Persistance.Configurations {
    public class EntityTypeConfiguration<TId, TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity<TId> {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Id).IsRequired();
        }
    }

    public class AuditedEntityTypeConfiguration<TId, TEntity>
        : EntityTypeConfiguration<TId, TEntity> where TEntity : class, IAuditedEntity<TId> {
        public override void Configure(EntityTypeBuilder<TEntity> builder) {
            base.Configure(builder);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired(false);
            builder.Property(p => p.ModifiedBy).IsRequired(false);
        }
    }
}
