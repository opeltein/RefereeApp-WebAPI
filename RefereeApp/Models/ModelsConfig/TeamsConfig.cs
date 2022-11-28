using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RefereeApp.Models.ModelsConfig;

public class TeamsConfig : IEntityTypeConfiguration<Teams>
{
    public void Configure(EntityTypeBuilder<Teams> builder)
    {
        builder.ToTable("Teams");

        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Stadium).WithMany(s => s.Teams).HasForeignKey(t => t.StadiumId);

        builder.HasMany(t => t.Players).WithOne(s => s.Teams).HasForeignKey(t => t.TeamsId);

        builder.HasIndex(t => t.Name).IsUnique();


    }
}
