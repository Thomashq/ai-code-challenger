using System.Data.Entity.Core.Metadata.Edm;
using ai_code_challenger.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ai_code_challenger;

public class AccountMapping : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");

        builder.HasKey(x => x.Id);

        builder.Property("Id")
            .ValueGeneratedOnAdd()
            .HasColumnType("bigint")
            .HasColumnName("AccountId");

        NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(builder.Property("Id"));

        builder.Property(x=>x.CreationDate)
            .IsRequired()
            .HasColumnType("timestamp with time zone")
            .HasColumnName("CreationDate");

        builder.Property(x=>x.DeleteDate)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("DeleteDate");

        builder.Property(x=>x.IsVerified)
            .HasColumnType("boolean")
            .HasColumnName("IsVerified");

        builder.Property(x=>x.Login)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnType("character varying(20)")
            .HasColumnName("Login");

        builder.Property(x=>x.Mail)
            .IsRequired()
            .HasColumnType("text")
            .HasColumnName("Mail");

        builder.Property(x=>x.Password)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnType("character varying(20)")
            .HasColumnName("Password");

        builder.Property(x=>x.Role)
            .HasColumnType("text")
            .HasColumnName("Role");

        builder.Property(x=>x.SolvedAmmount)
            .HasColumnType("integer")
            .HasColumnName("SolvedAmmount");

        builder.Property(x=>x.UpdateDate)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("UpdateDate");
    }
}
