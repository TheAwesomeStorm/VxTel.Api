﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VxTel.Api.Data;

#nullable disable

namespace VxTel.Api.Migrations
{
    [DbContext(typeof(VxTelDbContext))]
    [Migration("20220925143911_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VxTel.Api.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DddCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DddCode")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("VxTel.Api.Models.DataPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FreeMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(95)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DataPlans");
                });

            modelBuilder.Entity("VxTel.Api.Models.Fare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DestinationCityId")
                        .HasColumnType("int");

                    b.Property<int>("OriginCityId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DestinationCityId");

                    b.HasIndex("OriginCityId", "DestinationCityId")
                        .IsUnique();

                    b.ToTable("Fares");
                });

            modelBuilder.Entity("VxTel.Api.Models.Fare", b =>
                {
                    b.HasOne("VxTel.Api.Models.City", "DestinationCity")
                        .WithMany("FaresAsDestination")
                        .HasForeignKey("DestinationCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VxTel.Api.Models.City", "OriginCity")
                        .WithMany("FaresAsOrigin")
                        .HasForeignKey("OriginCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationCity");

                    b.Navigation("OriginCity");
                });

            modelBuilder.Entity("VxTel.Api.Models.City", b =>
                {
                    b.Navigation("FaresAsDestination");

                    b.Navigation("FaresAsOrigin");
                });
#pragma warning restore 612, 618
        }
    }
}
