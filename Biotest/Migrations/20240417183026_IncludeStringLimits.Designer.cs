﻿// <auto-generated />
using System;
using Biotest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biotest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240417183026_IncludeStringLimits")]
    partial class IncludeStringLimits
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biotest.Model.Analysis", b =>
                {
                    b.Property<int>("AnalysisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnalysisID"));

                    b.Property<int>("AnalysisTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeneticTestID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Results")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("AnalysisID");

                    b.HasIndex("AnalysisTypeID");

                    b.HasIndex("GeneticTestID");

                    b.ToTable("Analysis");
                });

            modelBuilder.Entity("Biotest.Model.AnalysisType", b =>
                {
                    b.Property<int>("AnalysisTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnalysisTypeID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AnalysisTypeID");

                    b.ToTable("AnalysisType");
                });

            modelBuilder.Entity("Biotest.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<int>("EmployeePositionID")
                        .HasColumnType("int");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("EmployeePositionID");

                    b.HasIndex("GenderID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Biotest.Model.EmployeePosition", b =>
                {
                    b.Property<int>("EmployeePositionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeePositionID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmployeePositionID");

                    b.ToTable("EmployeePosition");
                });

            modelBuilder.Entity("Biotest.Model.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("GenderID");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Biotest.Model.GeneticTest", b =>
                {
                    b.Property<int>("GeneticTestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneticTestID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("GeneticTestTypeID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("SampleID")
                        .HasColumnType("int");

                    b.HasKey("GeneticTestID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("GeneticTestTypeID");

                    b.HasIndex("SampleID");

                    b.ToTable("GeneticTest");
                });

            modelBuilder.Entity("Biotest.Model.GeneticTestType", b =>
                {
                    b.Property<int>("GeneticTestTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneticTestTypeID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("GeneticTestTypeID");

                    b.ToTable("GeneticTestType");
                });

            modelBuilder.Entity("Biotest.Model.GeneticVariant", b =>
                {
                    b.Property<int>("GeneticVariantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneticVariantID"));

                    b.Property<int>("AnalysisID")
                        .HasColumnType("int");

                    b.Property<int>("GeneticVariantTypeID")
                        .HasColumnType("int");

                    b.Property<int>("GenotypeID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PredictedEffectID")
                        .HasColumnType("int");

                    b.HasKey("GeneticVariantID");

                    b.HasIndex("AnalysisID");

                    b.HasIndex("GeneticVariantTypeID");

                    b.HasIndex("GenotypeID");

                    b.HasIndex("PredictedEffectID");

                    b.ToTable("GeneticVariant");
                });

            modelBuilder.Entity("Biotest.Model.GeneticVariantType", b =>
                {
                    b.Property<int>("GeneticVariantTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneticVariantTypeID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("GeneticVariantTypeID");

                    b.ToTable("GeneticVariantType");
                });

            modelBuilder.Entity("Biotest.Model.Genotype", b =>
                {
                    b.Property<int>("GenotypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenotypeID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("GenotypeID");

                    b.ToTable("Genotype");
                });

            modelBuilder.Entity("Biotest.Model.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("PatientID");

                    b.HasIndex("GenderID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Biotest.Model.PredictedEffect", b =>
                {
                    b.Property<int>("PredictedEffectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PredictedEffectID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PredictedEffectID");

                    b.ToTable("PredictedEffect");
                });

            modelBuilder.Entity("Biotest.Model.Sample", b =>
                {
                    b.Property<int>("SampleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SampleID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<int>("SampleSourceID")
                        .HasColumnType("int");

                    b.Property<int>("SampleTypeID")
                        .HasColumnType("int");

                    b.HasKey("SampleID");

                    b.HasIndex("PatientID");

                    b.HasIndex("SampleSourceID");

                    b.HasIndex("SampleTypeID");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("Biotest.Model.SampleSource", b =>
                {
                    b.Property<int>("SampleSourceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SampleSourceID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SampleSourceID");

                    b.ToTable("SampleSource");
                });

            modelBuilder.Entity("Biotest.Model.SampleType", b =>
                {
                    b.Property<int>("SampleTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SampleTypeID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SampleTypeID");

                    b.ToTable("SampleType");
                });

            modelBuilder.Entity("Biotest.Model.Analysis", b =>
                {
                    b.HasOne("Biotest.Model.AnalysisType", "AnalysisType")
                        .WithMany()
                        .HasForeignKey("AnalysisTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.GeneticTest", "GeneticTest")
                        .WithMany()
                        .HasForeignKey("GeneticTestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnalysisType");

                    b.Navigation("GeneticTest");
                });

            modelBuilder.Entity("Biotest.Model.Employee", b =>
                {
                    b.HasOne("Biotest.Model.EmployeePosition", "EmployeePosition")
                        .WithMany()
                        .HasForeignKey("EmployeePositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeePosition");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Biotest.Model.GeneticTest", b =>
                {
                    b.HasOne("Biotest.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.GeneticTestType", "GeneticTestType")
                        .WithMany()
                        .HasForeignKey("GeneticTestTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.Sample", "Sample")
                        .WithMany()
                        .HasForeignKey("SampleID");

                    b.Navigation("Employee");

                    b.Navigation("GeneticTestType");

                    b.Navigation("Sample");
                });

            modelBuilder.Entity("Biotest.Model.GeneticVariant", b =>
                {
                    b.HasOne("Biotest.Model.Analysis", "Analysis")
                        .WithMany()
                        .HasForeignKey("AnalysisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.GeneticVariantType", "GeneticVariantType")
                        .WithMany()
                        .HasForeignKey("GeneticVariantTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.Genotype", "Genotype")
                        .WithMany()
                        .HasForeignKey("GenotypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.PredictedEffect", "PredictedEffect")
                        .WithMany()
                        .HasForeignKey("PredictedEffectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analysis");

                    b.Navigation("GeneticVariantType");

                    b.Navigation("Genotype");

                    b.Navigation("PredictedEffect");
                });

            modelBuilder.Entity("Biotest.Model.Patient", b =>
                {
                    b.HasOne("Biotest.Model.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Biotest.Model.Sample", b =>
                {
                    b.HasOne("Biotest.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.SampleSource", "SampleSource")
                        .WithMany()
                        .HasForeignKey("SampleSourceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biotest.Model.SampleType", "SampleType")
                        .WithMany()
                        .HasForeignKey("SampleTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("SampleSource");

                    b.Navigation("SampleType");
                });
#pragma warning restore 612, 618
        }
    }
}
