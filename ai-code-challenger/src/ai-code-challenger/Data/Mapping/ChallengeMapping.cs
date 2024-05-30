using ai_code_challenger.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_code_challenger.Data.Maping;

public class ChallengeMapping : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.ToTable("Challenge");

        builder.HasKey(x=>x.Id);

        builder.Property("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("bigint")
            .HasColumnName("ChallengeId");

        NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(builder.Property("Id"));

        builder.Property(x=>x.Wording)
            .IsRequired(true)
            .HasColumnType("text")
            .HasColumnName("Wording");
        
        builder.Property(x=>x.Title)
            .IsRequired(true)
            .HasColumnType("text")
            .HasColumnName("Title");

        builder.Property(x=>x.Answer)
            .IsRequired(false)
            .HasColumnType("text")
            .HasColumnName("Answer");
            
        builder.Property(x=>x.CreationDate)
            .IsRequired(true)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("CreationDate");

        builder.Property(x=>x.DeleteDate)
            .IsRequired(false)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("DeleteDate");

        builder.Property(x=>x.UpdateDate)
            .IsRequired(false)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("UpdateDate");

        builder.Property(x=>x.IsSolved)
            .IsRequired(true)
            .HasColumnType("boolean")
            .HasColumnName("IsSolved");
    
        builder.Property(x=>x.Language)
            .IsRequired(false)
            .HasColumnType("text")
            .HasColumnName("Language");

        builder.Property(x=>x.AccountId)
            .IsRequired(true)
            .HasColumnType("bigint")
            .HasColumnName("AccountId");
    }
}
