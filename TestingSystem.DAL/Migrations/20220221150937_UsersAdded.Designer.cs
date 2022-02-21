﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestingSystem.DAL.DbContexts;

namespace TestingSystem.DAL.Migrations
{
    [DbContext(typeof(TestingSystemDbContext))]
    [Migration("20220221150937_UsersAdded")]
    partial class UsersAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestingSystem.DAL.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CorrectAnswerId")
                        .HasColumnType("int");

                    b.Property<int>("TestSetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestSetId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.TestCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestCategories");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.TestLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestLevels");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.TestSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TestLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestCategoryId");

                    b.HasIndex("TestLevelId");

                    b.ToTable("TestSets");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.Answer", b =>
                {
                    b.HasOne("TestingSystem.DAL.Models.Test", "Test")
                        .WithMany("Answers")
                        .HasForeignKey("TestId")
                        .HasConstraintName("FK_Answers_Tests")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.Question", b =>
                {
                    b.HasOne("TestingSystem.DAL.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.Test", b =>
                {
                    b.HasOne("TestingSystem.DAL.Models.TestSet", "TestSet")
                        .WithMany("Tests")
                        .HasForeignKey("TestSetId")
                        .HasConstraintName("FK_Tests_TestSets")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestSet");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.TestSet", b =>
                {
                    b.HasOne("TestingSystem.DAL.Models.TestCategory", "TestCategory")
                        .WithMany("TestSets")
                        .HasForeignKey("TestCategoryId")
                        .HasConstraintName("FK_TestSets_TestCategories")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingSystem.DAL.Models.TestLevel", "TestLevel")
                        .WithMany("TestSets")
                        .HasForeignKey("TestLevelId")
                        .HasConstraintName("FK_TestSets_TestLevels")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestCategory");

                    b.Navigation("TestLevel");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.Test", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.TestCategory", b =>
                {
                    b.Navigation("TestSets");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.TestLevel", b =>
                {
                    b.Navigation("TestSets");
                });

            modelBuilder.Entity("TestingSystem.DAL.Models.TestSet", b =>
                {
                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
