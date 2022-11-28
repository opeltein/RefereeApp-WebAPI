using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RefereeApp.Models.ModelsConfig
{
    public class MarksConfig : IEntityTypeConfiguration<Marks>
    {
        public void Configure(EntityTypeBuilder<Marks> builder)
        {
            builder.ToTable("Marks");

            builder.HasKey(marks => marks.Id);


        }
    }
}