﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart.FA.Catalog.Infrastructure.Persistence;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Cfa")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.Authorization.BlackListedTrainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TrainerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainerId"), 1L, 1);

                    b.HasKey("TrainerId");

                    b.ToTable("BlackListedTrainer", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.Authorization.SuperUser", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainerId"), 1L, 1);

                    b.HasKey("TrainerId");

                    b.ToTable("SuperUser", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("DefaultLanguage")
                        .IsRequired()
                        .HasColumnType("nchar(2)");

                    b.Property<string>("Email")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("ProfileImagePath")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Trainer", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainerApproval", b =>
                {
                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<int>("UserChartId")
                        .HasColumnType("int");

                    b.HasKey("TrainerId", "UserChartId");

                    b.HasIndex("UserChartId");

                    b.ToTable("TrainerApproval", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainerAssignment", b =>
                {
                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("TrainingId", "TrainerId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("TrainingId", "TrainerId"));

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerAssignment", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainerSocialNetwork", b =>
                {
                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<int>("SocialNetwork")
                        .HasColumnType("int")
                        .HasColumnName("SocialNetworkId");

                    b.Property<string>("UrlToProfile")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TrainerId", "SocialNetwork");

                    b.HasIndex("SocialNetwork");

                    b.ToTable("TrainerSocialNetwork", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsGivenBySmart")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("StatusType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("TrainingStatusTypeId");

                    b.HasKey("Id");

                    b.ToTable("Training", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainingAttendance", b =>
                {
                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("AttendanceType")
                        .HasColumnType("int")
                        .HasColumnName("AttendanceTypeId");

                    b.HasKey("TrainingId", "AttendanceType");

                    b.ToTable("TrainingAttendance", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainingLocalizedDetails", b =>
                {
                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasColumnType("NCHAR(2)")
                        .HasColumnName("Language");

                    b.Property<string>("Goal")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Methodology")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("PracticalModalities")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("TrainingId", "Language");

                    b.ToTable("TrainingLocalizedDetails", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainingTargetAudience", b =>
                {
                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("TargetAudienceType")
                        .HasColumnType("int")
                        .HasColumnName("TargetAudienceTypeId");

                    b.HasKey("TrainingId", "TargetAudienceType");

                    b.ToTable("TrainingTargetAudience", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainingTopic", b =>
                {
                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("Topic")
                        .HasColumnType("int")
                        .HasColumnName("TopicId");

                    b.HasKey("TrainingId", "Topic");

                    b.ToTable("TrainingTopic", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.UserChartRevision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ValidFrom")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<DateTime?>("ValidUntil")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserChartRevision", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.VatExemptionClaim", b =>
                {
                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("VatExemptionType")
                        .HasColumnType("int")
                        .HasColumnName("VatExemptionTypeId");

                    b.HasKey("TrainingId", "VatExemptionType");

                    b.ToTable("VatExemptionClaim", "Cfa");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Shared.Domain.Enumerations.Trainer.SocialNetwork", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SocialNetwork", "Cfa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Twitter"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Instagram"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Facebook"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Github"
                        },
                        new
                        {
                            Id = 5,
                            Name = "LinkedIn"
                        },
                        new
                        {
                            Id = 6,
                            Name = "PersonalWebsite"
                        });
                });

            modelBuilder.Entity("Smart.FA.Catalog.Shared.Domain.Enumerations.Training.AttendanceType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AttendanceType", "Cfa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Group"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Single"
                        });
                });

            modelBuilder.Entity("Smart.FA.Catalog.Shared.Domain.Enumerations.Training.TargetAudienceType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TargetAudienceType", "Cfa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Employee"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Student"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Unemployed"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Smart.FA.Catalog.Shared.Domain.Enumerations.Training.Topic", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Topic", "Cfa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "LanguageCourse"
                        },
                        new
                        {
                            Id = 2,
                            Name = "InformationTechnology"
                        },
                        new
                        {
                            Id = 3,
                            Name = "SocialScience"
                        },
                        new
                        {
                            Id = 4,
                            Name = "School"
                        },
                        new
                        {
                            Id = 5,
                            Name = "HealthCare"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Communication"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Culture"
                        },
                        new
                        {
                            Id = 8,
                            Name = "EconomyMarketing"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Smart.FA.Catalog.Shared.Domain.Enumerations.Training.TrainingStatusType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TrainingStatusType", "Cfa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Draft"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PendingValidation"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Published"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("Smart.FA.Catalog.Shared.Domain.Enumerations.Training.VatExemptionType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VatExemptionType", "Cfa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "LanguageCourse"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Professional"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ScholarTraining"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.Trainer", b =>
                {
                    b.OwnsOne("Smart.FA.Catalog.Core.Domain.Trainer.Identity#Smart.FA.Catalog.Core.Domain.ValueObjects.TrainerIdentity", "Identity", b1 =>
                        {
                            b1.Property<int>("TrainerId")
                                .HasColumnType("int");

                            b1.Property<int>("ApplicationTypeId")
                                .HasColumnType("int")
                                .HasColumnName("ApplicationType");

                            b1.Property<string>("UserId")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("UserId");

                            b1.HasKey("TrainerId");

                            b1.ToTable("Trainer", "Cfa");

                            b1.WithOwner()
                                .HasForeignKey("TrainerId");
                        });

                    b.OwnsOne("Smart.FA.Catalog.Core.Domain.Trainer.Name#Smart.FA.Catalog.Core.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("TrainerId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("LastName");

                            b1.HasKey("TrainerId");

                            b1.ToTable("Trainer", "Cfa");

                            b1.WithOwner()
                                .HasForeignKey("TrainerId");
                        });

                    b.Navigation("Identity")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainerApproval", b =>
                {
                    b.HasOne("Smart.FA.Catalog.Core.Domain.Trainer", "Trainer")
                        .WithMany("Approvals")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart.FA.Catalog.Core.Domain.UserChartRevision", "UserChartRevision")
                        .WithMany("TrainerApprovals")
                        .HasForeignKey("UserChartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");

                    b.Navigation("UserChartRevision");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainerAssignment", b =>
                {
                    b.HasOne("Smart.FA.Catalog.Core.Domain.Trainer", "Trainer")
                        .WithMany("Assignments")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart.FA.Catalog.Core.Domain.Training", "Training")
                        .WithMany("TrainerAssignments")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainerSocialNetwork", b =>
                {
                    b.HasOne("Smart.FA.Catalog.Core.Domain.Trainer", "Trainer")
                        .WithMany("SocialNetworks")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainingAttendance", b =>
                {
                    b.HasOne("Smart.FA.Catalog.Core.Domain.Training", "Training")
                        .WithMany("Attendances")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainingLocalizedDetails", b =>
                {
                    b.HasOne("Smart.FA.Catalog.Core.Domain.Training", "Training")
                        .WithMany("Details")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainingTargetAudience", b =>
                {
                    b.HasOne("Smart.FA.Catalog.Core.Domain.Training", "Training")
                        .WithMany("Targets")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.TrainingTopic", b =>
                {
                    b.HasOne("Smart.FA.Catalog.Core.Domain.Training", "Training")
                        .WithMany("Topics")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.VatExemptionClaim", b =>
                {
                    b.HasOne("Smart.FA.Catalog.Core.Domain.Training", "Training")
                        .WithMany("VatExemptionClaims")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.Trainer", b =>
                {
                    b.Navigation("Approvals");

                    b.Navigation("Assignments");

                    b.Navigation("SocialNetworks");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.Training", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Details");

                    b.Navigation("Targets");

                    b.Navigation("Topics");

                    b.Navigation("TrainerAssignments");

                    b.Navigation("VatExemptionClaims");
                });

            modelBuilder.Entity("Smart.FA.Catalog.Core.Domain.UserChartRevision", b =>
                {
                    b.Navigation("TrainerApprovals");
                });
#pragma warning restore 612, 618
        }
    }
}
