using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RefereeApp.Models.ModelsConfig
{
    public class CallendarEventConfig : IEntityTypeConfiguration<CallendarEvent>
    {
        public void Configure(EntityTypeBuilder<CallendarEvent> builder)
        {
            builder.ToTable("CallendarEvent");

            builder.HasKey(c => c.id);


        }
    }
}