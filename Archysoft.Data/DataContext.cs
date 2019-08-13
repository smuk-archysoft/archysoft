using System;
using Archysoft.Data.Configurations;
using Archysoft.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Archysoft.Data
{
    public class DataContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IConfiguration _configuration;

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var connection = environment == "Development" ? _configuration.GetConnectionString("DataContext") : Environment.GetEnvironmentVariable("ARCHYSOFT_DATACONTEXT") ?? "";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new ExperienceConfiguration());
            builder.ApplyConfiguration(new EducationConfiguration());
            builder.ApplyConfiguration(new DescriptonConfiguration());
            builder.ApplyConfiguration(new UserProfileLanguageConfiguration());
            builder.ApplyConfiguration(new UserProfileSkillConfiguration());
            builder.ApplyConfiguration(new LanguageConfiguration());
            builder.ApplyConfiguration(new SkillConfiguration());
            builder.ApplyConfiguration(new UserProfileConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
