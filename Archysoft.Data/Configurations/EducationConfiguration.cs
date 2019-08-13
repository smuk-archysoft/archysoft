
using Archysoft.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archysoft.Data.Configurations
{
    public class EducationConfiguration: IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.School).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Degree).HasMaxLength(255);
            builder.Property(x => x.YearAttendedFrom).IsRequired();
            builder.Property(x => x.YearAttendedTo).IsRequired();

            builder.HasOne(x => x.UserProfile).WithMany(x => x.Educations).HasForeignKey(x => x.UserProfileId);
        }
    }
}
