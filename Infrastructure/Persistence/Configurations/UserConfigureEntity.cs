using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{
    public partial class ApplicationDbContext { public virtual DbSet<UserEntity> Users { get; set; } }
    public class UserConfigureEntity : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasKey(e => e.id).HasName("pk_users");

            builder.Property(e => e.id).HasColumnName("id");

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("name");

            builder.Property(e => e.LastName).HasColumnName("last_name");
        }
    }
}
