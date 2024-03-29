﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testSibers.Models;

#nullable disable

namespace testSibers.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    partial class SystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<int>("ProjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserProjects", (string)null);
                });

            modelBuilder.Entity("testSibers.Models.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientCompany")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("ContractorCompany")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("testSibers.Models.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("testSibers.Models.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("db1fb1be-3342-4233-8ea1-ba887cee50fe"),
                            Name = "Supervisor",
                            NormalizedName = "SUPERVISOR"
                        },
                        new
                        {
                            Id = new Guid("4e59e1fa-92e7-434c-b344-20c574486690"),
                            Name = "ProjectManager",
                            NormalizedName = "PROJECT MANAGER"
                        },
                        new
                        {
                            Id = new Guid("a96abf16-cbaf-48cf-a245-068829f7d858"),
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("testSibers.Models.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("AssigneeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TaskProjectId");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("testSibers.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9f51b901-3f29-40f8-9ab7-037edc99db74"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "efab2074-38e1-422c-87c7-47ce19ea0108",
                            Email = "supervisor@test.test",
                            EmailConfirmed = false,
                            FirstName = "supervisorName",
                            LastName = "lastName",
                            LockoutEnabled = false,
                            MiddleName = "middleName",
                            NormalizedUserName = "SUPERVISOR@TEST.TEST",
                            PasswordHash = "AQAAAAIAAYagAAAAEJUfdSk60ZEb7mBv+QK/rhopowCclcuVI4zv4qQaoi9FLJkdVFuonUPmdGa/UZbRsg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c39e2d27-c065-45bb-b896-7cdc18684f50",
                            TwoFactorEnabled = false,
                            UserName = "supervisor@test.test"
                        },
                        new
                        {
                            Id = new Guid("56ad9457-b3e5-4f1a-9df3-387b17c008f8"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c644f6e1-09a5-4ce7-99e5-5ef13f3f1d0e",
                            Email = "projectManager@test.test",
                            EmailConfirmed = false,
                            FirstName = "projectManagerName",
                            LastName = "lastName",
                            LockoutEnabled = false,
                            MiddleName = "middleName",
                            NormalizedUserName = "PROJECTMANAGER@TEST.TEST",
                            PasswordHash = "AQAAAAIAAYagAAAAEJaei06IMZurxuzHuwr3sofrp1vqfMmG5CMEAykdKi1pHEnFJB7e4CkjNJOO8sFtMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "916fc5d6-55c2-4a95-8c0d-f2a7a3f6535b",
                            TwoFactorEnabled = false,
                            UserName = "projectManager@test.test"
                        },
                        new
                        {
                            Id = new Guid("7b336654-32c4-44ef-88a1-16e3cb1c2a6e"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "990e2411-78ea-4efe-9df8-9bcde29922a0",
                            Email = "employee@test.test",
                            EmailConfirmed = false,
                            FirstName = "employeeName",
                            LastName = "lastName",
                            LockoutEnabled = false,
                            MiddleName = "middleName",
                            NormalizedUserName = "EMPLOYEE@TEST.TEST",
                            PasswordHash = "AQAAAAIAAYagAAAAEAe9ae1xDRO7usHKGX3Ftjwz2wlcb/4kSOVsQsZUPHfDnHhGs9JC2QNP/+oj+nUbrQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "68e8107c-ed73-4eb7-b7aa-cbdb51bf5f73",
                            TwoFactorEnabled = false,
                            UserName = "employee@test.test"
                        });
                });

            modelBuilder.Entity("testSibers.Models.Entities.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("db1fb1be-3342-4233-8ea1-ba887cee50fe"),
                            UserId = new Guid("9f51b901-3f29-40f8-9ab7-037edc99db74")
                        },
                        new
                        {
                            RoleId = new Guid("4e59e1fa-92e7-434c-b344-20c574486690"),
                            UserId = new Guid("56ad9457-b3e5-4f1a-9df3-387b17c008f8")
                        },
                        new
                        {
                            RoleId = new Guid("a96abf16-cbaf-48cf-a245-068829f7d858"),
                            UserId = new Guid("7b336654-32c4-44ef-88a1-16e3cb1c2a6e")
                        },
                        new
                        {
                            RoleId = new Guid("a96abf16-cbaf-48cf-a245-068829f7d858"),
                            UserId = new Guid("9f51b901-3f29-40f8-9ab7-037edc99db74")
                        },
                        new
                        {
                            RoleId = new Guid("a96abf16-cbaf-48cf-a245-068829f7d858"),
                            UserId = new Guid("56ad9457-b3e5-4f1a-9df3-387b17c008f8")
                        });
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("testSibers.Models.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testSibers.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("testSibers.Models.Entities.Project", b =>
                {
                    b.HasOne("testSibers.Models.Entities.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("testSibers.Models.Entities.RefreshToken", b =>
                {
                    b.HasOne("testSibers.Models.Entities.User", "Owner")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("testSibers.Models.Entities.Task", b =>
                {
                    b.HasOne("testSibers.Models.Entities.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("testSibers.Models.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testSibers.Models.Entities.Project", "TaskProject")
                        .WithMany()
                        .HasForeignKey("TaskProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Creator");

                    b.Navigation("TaskProject");
                });

            modelBuilder.Entity("testSibers.Models.Entities.UserRole", b =>
                {
                    b.HasOne("testSibers.Models.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testSibers.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("testSibers.Models.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
