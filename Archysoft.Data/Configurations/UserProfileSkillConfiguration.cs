
using Archysoft.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archysoft.Data.Configurations
{
    public class UserProfileSkillConfiguration : IEntityTypeConfiguration<UserProfileSkill>
    {
        public void Configure(EntityTypeBuilder<UserProfileSkill> builder)
        {
            builder.HasKey(x => new { x.UserProfileId, x.SkillId });

            builder.HasOne(pc => pc.UserProfile)
                   .WithMany(p => p.UserProfileSkills)
                   .HasForeignKey(pc => pc.UserProfileId);

            builder.HasOne(pc => pc.Skill)
                   .WithMany(c => c.UserProfileSkills)
                   .HasForeignKey(pc => pc.SkillId);

        }
    }
}
