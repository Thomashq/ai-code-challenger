﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ai_code_challenger.Data;

#nullable disable

namespace ai_code_challenger.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240512030436_FistTestMiraton")]
    partial class FistTestMiraton
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ai_code_challenger.Models.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("AccountId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SolvedAmmount")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ai_code_challenger.Models.Challenge", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ChallengeId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("Answer")
                        .HasColumnType("text");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeleteDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsSolved")
                        .HasColumnType("boolean");

                    b.Property<DateOnly?>("UpdateDate")
                        .HasColumnType("date");

                    b.Property<string>("Wording")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Challenge");
                });
#pragma warning restore 612, 618
        }
    }
}
