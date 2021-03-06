﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quizer.DataAccessLayer;

namespace Quizer.DataAccessLayer.Migrations
{
    [DbContext(typeof(QuizerContext))]
    [Migration("20190125171719_Model changes")]
    partial class Modelchanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quizer.DataAccessLayer.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new { Id = 1, QuestionId = 1, Text = "4" },
                        new { Id = 2, QuestionId = 1, Text = "3" },
                        new { Id = 3, QuestionId = 1, Text = "2" },
                        new { Id = 4, QuestionId = 1, Text = "1" }
                    );
                });

            modelBuilder.Entity("Quizer.DataAccessLayer.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Mathematics" },
                        new { Id = 2, Name = "Overall knowledge" }
                    );
                });

            modelBuilder.Entity("Quizer.DataAccessLayer.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("CorrectAnswerId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions");

                    b.HasData(
                        new { Id = 1, CategoryId = 1, CorrectAnswerId = 1, Text = "2 + 2 = ?" }
                    );
                });

            modelBuilder.Entity("Quizer.DataAccessLayer.Entities.Answer", b =>
                {
                    b.HasOne("Quizer.DataAccessLayer.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Quizer.DataAccessLayer.Entities.Question", b =>
                {
                    b.HasOne("Quizer.DataAccessLayer.Entities.Category", "Category")
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
