using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RefereeApp.Models.ModelsConfig
{
    public class FinancesConfig : IEntityTypeConfiguration<Finances>

    {
        public void Configure(EntityTypeBuilder<Finances> builder)
        {
            builder.ToTable("Finances");

            builder.HasKey(f => f.Id);


        }


    }
}
