using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Domain.Common;

namespace Report.Infrastructure.Persistence.Configurations
{
    public class BaseEntityMapping<TEntity, TId> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                 .HasColumnName("id");

            builder.Property(b => b.CreateDate)
                .HasColumnName("create_date");
        }
    }
}