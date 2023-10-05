﻿// <auto-generated />
using System;
using Lab4_04_10_2023.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab4_04_10_2023.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lab4_04_10_2023.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseID = 1050,
                            Credits = 3,
                            Title = "Chemistry"
                        },
                        new
                        {
                            CourseID = 4022,
                            Credits = 3,
                            Title = "Microeconomics"
                        },
                        new
                        {
                            CourseID = 4041,
                            Credits = 3,
                            Title = "Macroeconomics"
                        });
                });

            modelBuilder.Entity("Lab4_04_10_2023.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"), 1L, 1);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<float>("Grade")
                        .HasColumnType("real");

                    b.Property<int>("LearnerID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("LearnerID");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            EnrollmentID = 1,
                            CourseID = 1050,
                            Grade = 5.5f,
                            LearnerID = 1
                        },
                        new
                        {
                            EnrollmentID = 2,
                            CourseID = 4022,
                            Grade = 7.5f,
                            LearnerID = 1
                        },
                        new
                        {
                            EnrollmentID = 3,
                            CourseID = 1050,
                            Grade = 3.5f,
                            LearnerID = 2
                        },
                        new
                        {
                            EnrollmentID = 4,
                            CourseID = 4041,
                            Grade = 7f,
                            LearnerID = 2
                        });
                });

            modelBuilder.Entity("Lab4_04_10_2023.Models.Learner", b =>
                {
                    b.Property<int>("LearnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LearnerID"), 1L, 1);

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstMidName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MajorID")
                        .HasColumnType("int");

                    b.HasKey("LearnerID");

                    b.HasIndex("MajorID");

                    b.ToTable("Learners");

                    b.HasData(
                        new
                        {
                            LearnerID = 1,
                            EnrollmentDate = new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Carson",
                            LastName = "Alexander",
                            MajorID = 1
                        },
                        new
                        {
                            LearnerID = 2,
                            EnrollmentDate = new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstMidName = "Meredith",
                            LastName = "Alonso",
                            MajorID = 2
                        });
                });

            modelBuilder.Entity("Lab4_04_10_2023.Models.Major", b =>
                {
                    b.Property<int>("MajorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MajorID"), 1L, 1);

                    b.Property<string>("MajorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MajorID");

                    b.ToTable("Majors");

                    b.HasData(
                        new
                        {
                            MajorID = 1,
                            MajorName = "IT"
                        },
                        new
                        {
                            MajorID = 2,
                            MajorName = "Economics"
                        },
                        new
                        {
                            MajorID = 3,
                            MajorName = "Mathematics"
                        });
                });

            modelBuilder.Entity("Lab4_04_10_2023.Models.Enrollment", b =>
                {
                    b.HasOne("Lab4_04_10_2023.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab4_04_10_2023.Models.Learner", "Learner")
                        .WithMany("Enrollments")
                        .HasForeignKey("LearnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("Lab4_04_10_2023.Models.Learner", b =>
                {
                    b.HasOne("Lab4_04_10_2023.Models.Major", "Major")
                        .WithMany("Learners")
                        .HasForeignKey("MajorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("Lab4_04_10_2023.Models.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Lab4_04_10_2023.Models.Learner", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Lab4_04_10_2023.Models.Major", b =>
                {
                    b.Navigation("Learners");
                });
#pragma warning restore 612, 618
        }
    }
}
