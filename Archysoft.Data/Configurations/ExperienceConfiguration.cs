
using Archysoft.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archysoft.Data.Configurations
{
    class ExperienceConfiguration: IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Position).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(x => x.BeginDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();

            builder.HasOne(x => x.UserProfile).WithMany(x => x.Experiences).HasForeignKey(x => x.UserProfileId);
        }
    }
}
