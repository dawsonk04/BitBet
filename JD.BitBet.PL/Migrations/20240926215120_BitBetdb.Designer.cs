﻿// <auto-generated />
using System;
using JD.BitBet.PL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JD.BitBet.PL.Migrations
{
    [DbContext(typeof(BitBetEntities))]
    [Migration("20240926215120_BitBetdb")]
    partial class BitBetdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblGame", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("GameResult")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("Pk__tblGame_Id");

                    b.HasIndex("UserId");

                    b.ToTable("tblGame", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("36de6af2-fdb1-4513-baa9-aaf35e4cca62"),
                            GameResult = 200.0,
                            UserId = new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f")
                        },
                        new
                        {
                            Id = new Guid("2645dccf-8374-42dd-a9c7-8e8210983395"),
                            GameResult = 200.0,
                            UserId = new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f")
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("Pk__tblUser_Id");

                    b.ToTable("tblUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f"),
                            CreateDate = new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(2304),
                            Email = "knudtdaw0000@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g="
                        },
                        new
                        {
                            Id = new Guid("043502dc-a4ef-4aca-ac7e-d94cf40389a9"),
                            CreateDate = new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(2412),
                            Email = "jstrange2@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g="
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalletAddress")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("Pk__tblWallet_Id");

                    b.HasIndex("UserId");

                    b.ToTable("tblWallet", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a76f6f4c-64f7-492e-9be6-f6facbac5d1a"),
                            Balance = 0.0,
                            UserId = new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f"),
                            WalletAddress = "0xE2dC61497FDD26F9ea285172A41F0b25373f22df"
                        },
                        new
                        {
                            Id = new Guid("85c1dc16-16b1-4808-9cb8-d8e66afc98a3"),
                            Balance = 0.0,
                            UserId = new Guid("043502dc-a4ef-4aca-ac7e-d94cf40389a9"),
                            WalletAddress = "0xE2dC61497FDD26F9eaYaBoi5373f22df"
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.tblErrorLog", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ErrorDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorMessage")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ErrorType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__tblErrorLog_Id");

                    b.HasIndex("UserId");

                    b.ToTable("tblErrorLog", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b1ac1fe1-1638-4f8c-aae1-58d1376abed4"),
                            ErrorDateTime = new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(7085),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f")
                        },
                        new
                        {
                            Id = new Guid("240e5ea8-ecec-4560-8b9b-668e228ae1c0"),
                            ErrorDateTime = new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(7116),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("043502dc-a4ef-4aca-ac7e-d94cf40389a9")
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.tblHand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BetAmount")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("float");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Result")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("float");

                    b.HasKey("Id")
                        .HasName("Pk__tblHand_Id");

                    b.HasIndex("GameId");

                    b.ToTable("tblHand", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f924a577-b305-4a5b-abb0-f5fdf4ce3b9e"),
                            BetAmount = 20.0,
                            GameId = new Guid("36de6af2-fdb1-4513-baa9-aaf35e4cca62"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("ab52786c-ee16-4f56-9526-e27ba9e64fda"),
                            BetAmount = 20.0,
                            GameId = new Guid("2645dccf-8374-42dd-a9c7-8e8210983395"),
                            Result = -20.0
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.tblTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("TransactionDate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("Pk__tblTransaction_Id");

                    b.HasIndex("WalletId");

                    b.ToTable("tblTransaction", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e653c8a-0c31-434d-add2-f4e69d19ebda"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(4463),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("a76f6f4c-64f7-492e-9be6-f6facbac5d1a")
                        },
                        new
                        {
                            Id = new Guid("4281543e-57fb-4193-a87f-bafd7c6fe6d8"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(4480),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("a76f6f4c-64f7-492e-9be6-f6facbac5d1a")
                        },
                        new
                        {
                            Id = new Guid("815ef812-c47b-405d-83a1-1cbd119fd9c1"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(4491),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("85c1dc16-16b1-4808-9cb8-d8e66afc98a3")
                        },
                        new
                        {
                            Id = new Guid("81e91b41-b934-4de0-aec9-cc9518e73b15"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(4502),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("85c1dc16-16b1-4808-9cb8-d8e66afc98a3")
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblGame", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblUser", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_tblGame_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblWallet", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblUser", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_tblWallet_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JD.BitBet.PL.tblErrorLog", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblUser", "User")
                        .WithMany("ErrorLogs")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_tblErrorLog_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JD.BitBet.PL.tblHand", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblGame", "Game")
                        .WithMany("Hands")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_tblHand_UserId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("JD.BitBet.PL.tblTransaction", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblWallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .IsRequired()
                        .HasConstraintName("FK_tblTransaction_WalletId");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblGame", b =>
                {
                    b.Navigation("Hands");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblUser", b =>
                {
                    b.Navigation("ErrorLogs");

                    b.Navigation("Games");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblWallet", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}