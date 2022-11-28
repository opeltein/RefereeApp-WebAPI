using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RefereeApp.Models.ModelsConfig
{
    public class UserMatchesConfig : IEntityTypeConfiguration<UserMatches>
    {
        public void Configure(EntityTypeBuilder<UserMatches> builder)
        {
            builder.ToTable("UserMatches");

            builder.HasKey(um => um.Id);

            builder.HasOne(um => um.Match).WithMany(m => m.UserMatches).HasForeignKey(um => um.MatchId);

            builder.HasOne(um => um.Reffere).WithMany(m => m.UserMatches).HasForeignKey(um => um.ReffereId);


        }
    }
}
