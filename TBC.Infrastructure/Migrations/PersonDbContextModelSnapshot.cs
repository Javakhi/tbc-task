﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBC.Infrastructure.DbContexts;

#nullable disable

namespace TBC.Infrastructure.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    partial class PersonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TBC.Domain.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CityEntity");
                });

            modelBuilder.Entity("TBC.Domain.Entities.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("FirstName");

                    b.HasIndex("LastName");

                    b.HasIndex("PersonalNumber")
                        .IsUnique();

                    b.ToTable("PersonEntity");
                });

            modelBuilder.Entity("TBC.Domain.Entities.PersonNumber", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberType")
                        .HasColumnType("int");

                    b.Property<int?>("PersonEntityId")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("Number");

                    b.HasIndex("PersonEntityId");

                    b.ToTable("PersonNumber");
                });

            modelBuilder.Entity("TBC.Domain.Entities.RelatedPersonEntity", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<int?>("PersonEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonType")
                        .HasColumnType("int");

                    b.Property<int>("RelatedPersonId")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("PersonEntityId");

                    b.HasIndex("PersonType");

                    b.ToTable("RelatedPersonEntity");
                });

            modelBuilder.Entity("TBC.Domain.Entities.PersonEntity", b =>
                {
                    b.HasOne("TBC.Domain.Entities.CityEntity", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("TBC.Domain.Entities.PersonNumber", b =>
                {
                    b.HasOne("TBC.Domain.Entities.PersonEntity", null)
                        .WithMany("PersonNumbers")
                        .HasForeignKey("PersonEntityId");
                });

            modelBuilder.Entity("TBC.Domain.Entities.RelatedPersonEntity", b =>
                {
                    b.HasOne("TBC.Domain.Entities.PersonEntity", null)
                        .WithMany("RelatedPerson")
                        .HasForeignKey("PersonEntityId");
                });

            modelBuilder.Entity("TBC.Domain.Entities.PersonEntity", b =>
                {
                    b.Navigation("PersonNumbers");

                    b.Navigation("RelatedPerson");
                });
#pragma warning restore 612, 618
        }
    }
}
