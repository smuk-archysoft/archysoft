
using Archysoft.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archysoft.Data.Configurations
{
    public class UserProfileLanguageConfiguration : IEntityTypeConfiguration<UserProfileLanguage>
    {
        public void Configure(EntityTypeBuilder<UserProfileLanguage> builder)
        {
            builder.HasKey(x => new { x.UserProfileId, x.LanguageId });


            builder.HasOne(pc => pc.UserProfile)
                .WithMany(p => p.UserProfileLanguages)
                .HasForeignKey(pc => pc.UserProfileId);


            builder.HasOne(pc => pc.Language)
                .WithMany(c => c.UserProfileLanguages)
                .HasForeignKey(pc => pc.LanguageId);

        }
    }
}
