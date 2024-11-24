﻿// <auto-generated />
using System;
using JD.BitBet.PL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JD.BitBet.PL.Migrations
{
    [DbContext(typeof(BitBetEntities))]
    partial class BitBetEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblCard", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("rank")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("suit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("Pk__tblCard_Id");

                    b.HasIndex("HandId");

                    b.ToTable("tblCard", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae90c1ad-f881-4f57-8914-f8225d2f9a95"),
                            HandId = new Guid("8cc24b18-114b-4c6b-bbaf-4ef73d0ff877"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("e8ce52c9-9f5a-47e5-8cc7-5d972c7627eb"),
                            HandId = new Guid("8cc24b18-114b-4c6b-bbaf-4ef73d0ff877"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("398b6e2b-f5ae-4c39-91c0-ead55daf11e9"),
                            HandId = new Guid("dafe3578-c370-48f1-a9f6-27362028037b"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("4337ede6-0dde-41a8-92b7-9b927863ed83"),
                            HandId = new Guid("dafe3578-c370-48f1-a9f6-27362028037b"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("cdafb0ef-07d4-484d-b5d0-af623b824cd4"),
                            HandId = new Guid("eb725450-61ff-475c-89be-2dac93de7d21"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("563257e2-5af5-4946-83af-e885e127a293"),
                            HandId = new Guid("eb725450-61ff-475c-89be-2dac93de7d21"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("7fb456e9-465f-4764-91fb-e99b73a1a818"),
                            HandId = new Guid("3b22a988-1f72-4a99-bc03-5f75d699176e"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("8147366d-db11-4d69-a7bd-f25270946a27"),
                            HandId = new Guid("3b22a988-1f72-4a99-bc03-5f75d699176e"),
                            rank = "Ten",
                            suit = "Diamonds"
                        });
                });

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
                            Id = new Guid("263d413d-d4d7-4527-b063-ea3ab6231f04"),
                            GameResult = 200.0,
                            UserId = new Guid("0eb59487-6e41-4326-a624-9065f0f0a875")
                        },
                        new
                        {
                            Id = new Guid("3f18bf8b-91e2-4eba-8a8b-e76fabe3cc9a"),
                            GameResult = 200.0,
                            UserId = new Guid("0eb59487-6e41-4326-a624-9065f0f0a875")
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblGameState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("dealerHandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("dealerHandVal")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<bool>("isGameOver")
                        .HasColumnType("bit");

                    b.Property<bool>("isPlayerTurn")
                        .HasColumnType("bit");

                    b.Property<Guid>("playerHandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("playerHandVal")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("Pk__tblGameState_Id");

                    b.HasIndex("dealerHandId");

                    b.HasIndex("playerHandId");

                    b.ToTable("tblGameState", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("42670a49-3a3c-49cf-b562-3a4affe311b2"),
                            dealerHandId = new Guid("8cc24b18-114b-4c6b-bbaf-4ef73d0ff877"),
                            dealerHandVal = 20,
                            isGameOver = true,
                            isPlayerTurn = true,
                            playerHandId = new Guid("dafe3578-c370-48f1-a9f6-27362028037b"),
                            playerHandVal = 20
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
                            Id = new Guid("0eb59487-6e41-4326-a624-9065f0f0a875"),
                            CreateDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "knudtdaw0000@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g="
                        },
                        new
                        {
                            Id = new Guid("35be2300-cee8-4289-bd14-0ff826076909"),
                            CreateDate = new DateTime(2024, 11, 24, 3, 2, 14, 318, DateTimeKind.Local).AddTicks(2197),
                            Email = "jbstrange2@gmail.com",
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
                            Id = new Guid("7f722214-2039-46b3-8a34-a485fbf9f709"),
                            Balance = 0.0,
                            UserId = new Guid("0eb59487-6e41-4326-a624-9065f0f0a875"),
                            WalletAddress = "0xE2dC61497FDD26F9ea285172A41F0b25373f22df"
                        },
                        new
                        {
                            Id = new Guid("2b973b7c-26e5-4132-b2a8-bd78c6c7aff1"),
                            Balance = 0.0,
                            UserId = new Guid("35be2300-cee8-4289-bd14-0ff826076909"),
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
                            Id = new Guid("84aaf7e7-54ca-41d0-98e7-f2a931d97024"),
                            ErrorDateTime = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("0eb59487-6e41-4326-a624-9065f0f0a875")
                        },
                        new
                        {
                            Id = new Guid("f800da83-5da1-4a85-a775-338db87fa20a"),
                            ErrorDateTime = new DateTime(2024, 11, 24, 3, 2, 14, 318, DateTimeKind.Local).AddTicks(9240),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("35be2300-cee8-4289-bd14-0ff826076909")
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

                    b.Property<double>("Result")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("float");

                    b.Property<Guid?>("tblGameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("Pk__tblHand_Id");

                    b.HasIndex("tblGameId");

                    b.ToTable("tblHand", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8cc24b18-114b-4c6b-bbaf-4ef73d0ff877"),
                            BetAmount = 20.0,
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("dafe3578-c370-48f1-a9f6-27362028037b"),
                            BetAmount = 20.0,
                            Result = -20.0
                        },
                        new
                        {
                            Id = new Guid("eb725450-61ff-475c-89be-2dac93de7d21"),
                            BetAmount = 20.0,
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("3b22a988-1f72-4a99-bc03-5f75d699176e"),
                            BetAmount = 20.0,
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
                            Id = new Guid("5f1f725e-2c20-4c1a-a151-84ff894d8268"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("7f722214-2039-46b3-8a34-a485fbf9f709")
                        },
                        new
                        {
                            Id = new Guid("05e605e7-60c4-40d8-8acd-435de6a0dfe4"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 11, 24, 3, 2, 14, 318, DateTimeKind.Local).AddTicks(5319),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("7f722214-2039-46b3-8a34-a485fbf9f709")
                        },
                        new
                        {
                            Id = new Guid("4a209c62-d3ea-4dc2-9142-b8e8a3132bdc"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(2024, 11, 24, 3, 2, 14, 318, DateTimeKind.Local).AddTicks(5364),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("2b973b7c-26e5-4132-b2a8-bd78c6c7aff1")
                        },
                        new
                        {
                            Id = new Guid("dbd99b78-c699-49ee-b9bc-d477bc5f1221"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 11, 24, 3, 2, 14, 318, DateTimeKind.Local).AddTicks(5375),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("2b973b7c-26e5-4132-b2a8-bd78c6c7aff1")
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblCard", b =>
                {
                    b.HasOne("JD.BitBet.PL.tblHand", "hand")
                        .WithMany("cards")
                        .HasForeignKey("HandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tblCard_HandId");

                    b.Navigation("hand");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblGame", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblUser", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tblGame_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblGameState", b =>
                {
                    b.HasOne("JD.BitBet.PL.tblHand", "dealerHand")
                        .WithMany()
                        .HasForeignKey("dealerHandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JD.BitBet.PL.tblHand", "playerHand")
                        .WithMany()
                        .HasForeignKey("playerHandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("dealerHand");

                    b.Navigation("playerHand");
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
                    b.HasOne("JD.BitBet.PL.Entities.tblGame", null)
                        .WithMany("Hands")
                        .HasForeignKey("tblGameId");
                });

            modelBuilder.Entity("JD.BitBet.PL.tblTransaction", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblWallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
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

            modelBuilder.Entity("JD.BitBet.PL.tblHand", b =>
                {
                    b.Navigation("cards");
                });
#pragma warning restore 612, 618
        }
    }
}
