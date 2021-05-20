﻿// <auto-generated />
using System;
using BTDCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BTDCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210520190608_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BTDCore.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("A0")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("A1")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("A2")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("A3")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("A4")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfChanges")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRegistration")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCanceled")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<bool>("IsTemporary")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSheets")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("BTDCore.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BTDCore.Models.TypeOfDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfDocument");
                });

            modelBuilder.Entity("BTDCore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BTDCore.Models.UserCapability", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("CanAddInfo")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteInfo")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteUser")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<bool>("CanEditInfo")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<bool>("CanEditUser")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<bool>("CanMakeNewUser")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<bool>("CanMakeReport")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.Property<bool>("IsEntered")
                        .IsConcurrencyToken()
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("UserCapabilities");
                });

            modelBuilder.Entity("BTDCore.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("BTDCore.ViewModels.AllDocumentation", b =>
                {
                    b.Property<int>("A0")
                        .HasColumnType("int");

                    b.Property<int>("A1")
                        .HasColumnType("int");

                    b.Property<int>("A2")
                        .HasColumnType("int");

                    b.Property<int>("A3")
                        .HasColumnType("int");

                    b.Property<int>("A4")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfChanges")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTemporary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSheets")
                        .HasColumnType("int");

                    b.ToView("View_AllDocumentation");
                });

            modelBuilder.Entity("BTDCore.ViewModels.DesDocumentation", b =>
                {
                    b.Property<int>("A0")
                        .HasColumnType("int");

                    b.Property<int>("A1")
                        .HasColumnType("int");

                    b.Property<int>("A2")
                        .HasColumnType("int");

                    b.Property<int>("A3")
                        .HasColumnType("int");

                    b.Property<int>("A4")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfChanges")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTemporary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSheets")
                        .HasColumnType("int");

                    b.ToView("View_DesDocumentation");
                });

            modelBuilder.Entity("BTDCore.ViewModels.TechDocumentation", b =>
                {
                    b.Property<int>("A0")
                        .HasColumnType("int");

                    b.Property<int>("A1")
                        .HasColumnType("int");

                    b.Property<int>("A2")
                        .HasColumnType("int");

                    b.Property<int>("A3")
                        .HasColumnType("int");

                    b.Property<int>("A4")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfChanges")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTemporary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSheets")
                        .HasColumnType("int");

                    b.ToView("View_TechDocumentation");
                });

            modelBuilder.Entity("BTDCore.ViewModels.ViewUserDetails", b =>
                {
                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToView("View_UserDetails");
                });

            modelBuilder.Entity("BTDCore.Models.Card", b =>
                {
                    b.HasOne("BTDCore.Models.TypeOfDocument", "TypeOfDocument")
                        .WithMany("Karts")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfDocument");
                });

            modelBuilder.Entity("BTDCore.Models.User", b =>
                {
                    b.HasOne("BTDCore.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BTDCore.Models.UserCapability", b =>
                {
                    b.HasOne("BTDCore.Models.User", "User")
                        .WithOne("UserCapabilities")
                        .HasForeignKey("BTDCore.Models.UserCapability", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BTDCore.Models.UserProfile", b =>
                {
                    b.HasOne("BTDCore.Models.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("BTDCore.Models.UserProfile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BTDCore.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BTDCore.Models.TypeOfDocument", b =>
                {
                    b.Navigation("Karts");
                });

            modelBuilder.Entity("BTDCore.Models.User", b =>
                {
                    b.Navigation("UserCapabilities")
                        .IsRequired();

                    b.Navigation("UserDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}