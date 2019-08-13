

using Archysoft.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archysoft.Data.Configurations
{
   public class CityConfiguration:IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.HasKey(x => x.Id);
          
            builder.HasMany(x => x.UserProfiles).WithOne(x => x.City).HasForeignKey(x => x.CityId);
        }
    }
}
