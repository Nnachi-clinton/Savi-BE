﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Savi.Data.Context;

#nullable disable

namespace Savi.Data.Migrations
{
    [DbContext(typeof(SaviDbContext))]
    [Migration("20240109114121_AddMigration ")]
    partial class AddMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppUserGroup", b =>
                {
                    b.Property<string>("AppUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppUsersId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("AppUserGroup");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<string>", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Savi.Model.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Savi.Model.Entities.AppUserTransaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("AppUserTransactions");
                });

            modelBuilder.Entity("Savi.Model.Entities.CardDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CVV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOnCard")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("CardDetails");
                });

            modelBuilder.Entity("Savi.Model.Entities.Group", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CashoutDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ContributionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<int>("MaxNumberOfParticipants")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NextDueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("Schedule")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Savi.Model.Entities.GroupTransaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupsTransaction");
                });

            modelBuilder.Entity("Savi.Model.Entities.Kyc", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentificationType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProofOfAddressUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kycs");
                });

            modelBuilder.Entity("Savi.Model.Entities.Saving", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("AmountSaved")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AmountToAdd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FundFrequency")
                        .HasColumnType("int");

                    b.Property<decimal>("GoalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Savings");
                });

            modelBuilder.Entity("Savi.Model.Entities.Wallet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaystackCustomerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionPin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Savi.Model.Entities.WalletFunding", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FundAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Narration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("WalletFundings");
                });

            modelBuilder.Entity("AppUserGroup", b =>
                {
                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("AppUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Savi.Model.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<string>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<string>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Savi.Model.Entities.AppUserTransaction", b =>
                {
                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany("AppUserTransactions")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Savi.Model.Entities.CardDetail", b =>
                {
                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany("CardDetails")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Savi.Model.Entities.GroupTransaction", b =>
                {
                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany("GroupTransactions")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Savi.Model.Entities.Group", null)
                        .WithMany("GroupTransactions")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Savi.Model.Entities.Saving", b =>
                {
                    b.HasOne("Savi.Model.Entities.AppUser", null)
                        .WithMany("Savings")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Savi.Model.Entities.WalletFunding", b =>
                {
                    b.HasOne("Savi.Model.Entities.Wallet", null)
                        .WithMany("WalletFundings")
                        .HasForeignKey("WalletId");
                });

            modelBuilder.Entity("Savi.Model.Entities.AppUser", b =>
                {
                    b.Navigation("AppUserTransactions");

                    b.Navigation("CardDetails");

                    b.Navigation("GroupTransactions");

                    b.Navigation("Savings");
                });

            modelBuilder.Entity("Savi.Model.Entities.Group", b =>
                {
                    b.Navigation("GroupTransactions");
                });

            modelBuilder.Entity("Savi.Model.Entities.Wallet", b =>
                {
                    b.Navigation("WalletFundings");
                });
#pragma warning restore 612, 618
        }
    }
}
