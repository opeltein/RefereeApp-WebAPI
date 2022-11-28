using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RefereeApp.Models.ModelsConfig
{
    public class MatchesConfig : IEntityTypeConfiguration<Matches>
    {
        public void Configure(EntityTypeBuilder<Matches> builder)
        {
            builder.ToTable("Matches");

            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.HomeTeam).WithMany(t => t.HomeTeamMatches).HasForeignKey(m => m.HomeTeamId).OnDelete(DeleteBehavior.Restrict).IsRequired();

            builder.HasOne(m => m.AwayTeam).WithMany(t => t.AwayTeamMatches).HasForeignKey(m => m.AwayTeamId).OnDelete(DeleteBehavior.Restrict).IsRequired();



        }
    }
}
