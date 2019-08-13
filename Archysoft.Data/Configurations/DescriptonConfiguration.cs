

using Archysoft.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Archysoft.Data.Configurations
{
    public class DescriptonConfiguration: IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.ToTable("Descriptions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Text).IsRequired().HasColumnType("nvarchar(max)");

        }
    }
}
