﻿// <auto-generated />
using Assessment.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assessment.Models.Migrations
{
    [DbContext(typeof(UnitConversionDbContext))]
    [Migration("20241221131235_NewMigration")]
    partial class NewMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assessment.Models.ConversionHistory", b =>
                {
                    b.Property<int>("ConversionHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConversionHistoryId"));

                    b.Property<double>("DerivedFactor")
                        .HasColumnType("float");

                    b.Property<double>("InputValue")
                        .HasColumnType("float");

                    b.Property<double>("OutputValue")
                        .HasColumnType("float");

                    b.Property<string>("SourceUnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetUnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConversionHistoryId");

                    b.ToTable("ConversionHistories");
                });

            modelBuilder.Entity("Assessment.Models.UnitDetails", b =>
                {
                    b.Property<int>("UnitDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitDetailsId"));

                    b.Property<double>("NumberOfBaseUnits")
                        .HasColumnType("float");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitTypeId")
                        .HasColumnType("int");

                    b.HasKey("UnitDetailsId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("UnitDetails");
                });

            modelBuilder.Entity("Assessment.Models.UnitTypes", b =>
                {
                    b.Property<int>("UnitTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitTypeId"));

                    b.Property<string>("UnitTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitTypeId");

                    b.ToTable("UnitTypes");
                });

            modelBuilder.Entity("Assessment.Models.UnitDetails", b =>
                {
                    b.HasOne("Assessment.Models.UnitTypes", "UnitType")
                        .WithMany("unitDetails")
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("Assessment.Models.UnitTypes", b =>
                {
                    b.Navigation("unitDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
