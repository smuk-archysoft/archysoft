using Archysoft.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archysoft.Data.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Skype).HasMaxLength(255);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Photo).HasColumnType("image");         

            builder.HasOne(u => u.User).WithOne(u => u.Profile).HasForeignKey<UserProfile>(u => u.UserId);
            builder.HasOne(x => x.Description).WithOne(x => x.UserProfile).HasForeignKey<Description>(x => x.UserProfileId);
          
        }
    }
}
