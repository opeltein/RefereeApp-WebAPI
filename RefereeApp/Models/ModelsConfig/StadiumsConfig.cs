using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RefereeApp.Models.ModelsConfig
{
    public class StadiumsConfig : IEntityTypeConfiguration<Stadiums>
    {
        public void Configure(EntityTypeBuilder<Stadiums> builder)
        {
            builder.ToTable("Stadiums");

            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.Name).IsUnique();


        }
    }
    
    
}
