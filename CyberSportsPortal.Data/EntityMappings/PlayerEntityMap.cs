using CyberSportsPortal.Data.Entities;
using CyberSportsPortal.Data.Model.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberSportsPortal.Data.EntityMappings
{
    public class PlayerEntityMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(DatabaseDefaults.NORMAL_STRING_LENGTH);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(DatabaseDefaults.NORMAL_STRING_LENGTH);
            builder.Property(p => p.Nickname).IsRequired().HasMaxLength(DatabaseDefaults.NORMAL_STRING_LENGTH);
            builder.Property(p => p.Country).IsRequired();
            builder.HasOne(x => x.Team).WithMany(x => x.Players).HasForeignKey(x => x.TeamId);
        }
    }
}
