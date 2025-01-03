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
                            Id = new Guid("1e6cd016-4cbf-48cb-a5fb-e4d4dc010262"),
                            HandId = new Guid("0d821c4f-52a8-49db-9a80-14f86a67fa7e"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("57a2b94a-274e-4a83-b1df-8afa82bac4c7"),
                            HandId = new Guid("0d821c4f-52a8-49db-9a80-14f86a67fa7e"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("c4dd6b5b-cb7e-4fd4-a11c-4f3fc7c68290"),
                            HandId = new Guid("53c0fdc6-5266-4c28-a26e-a7d253d9104e"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("7ef76c9f-ddcd-48fa-9611-314248707de5"),
                            HandId = new Guid("53c0fdc6-5266-4c28-a26e-a7d253d9104e"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("42d9ca1b-af91-4119-add6-79b0c867347a"),
                            HandId = new Guid("15528964-c3eb-46c4-9403-c1485f6ab04c"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("2be2ccb3-983a-4ff4-a02b-ce4694ecc7ed"),
                            HandId = new Guid("15528964-c3eb-46c4-9403-c1485f6ab04c"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("00e6c15b-d763-46da-b305-43e279c1fa94"),
                            HandId = new Guid("56879e2d-8906-4535-8f92-2a94ce5d9c76"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("44d69ee6-7c84-433b-9b95-72721f15e905"),
                            HandId = new Guid("56879e2d-8906-4535-8f92-2a94ce5d9c76"),
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

                    b.Property<Guid?>("tblUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("Pk__tblGame_Id");

                    b.HasIndex("tblUserId");

                    b.ToTable("tblGame", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d4dd326-6933-4a8c-bf4e-816d5428c30e"),
                            GameResult = 200.0
                        },
                        new
                        {
                            Id = new Guid("df1ef9a4-4d42-4ef3-8caf-c6ce5b4fce1c"),
                            GameResult = 200.0
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblGameState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
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

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("playerHandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("playerHandVal")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("Pk__tblGameState_Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.HasIndex("dealerHandId");

                    b.HasIndex("playerHandId");

                    b.ToTable("tblGameState", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("aba25b4b-eb63-4866-b7cc-d8bb6dd0ec95"),
                            GameId = new Guid("7d4dd326-6933-4a8c-bf4e-816d5428c30e"),
                            UserId = new Guid("77944e84-0b2f-4a5d-9816-41c8fb695a54"),
                            dealerHandId = new Guid("0d821c4f-52a8-49db-9a80-14f86a67fa7e"),
                            dealerHandVal = 20,
                            isGameOver = true,
                            isPlayerTurn = true,
                            message = "Game Over",
                            playerHandId = new Guid("53c0fdc6-5266-4c28-a26e-a7d253d9104e"),
                            playerHandVal = 20
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("BetAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("HasBet")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("gameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("Pk__tblUser_Id");

                    b.HasIndex("gameId");

                    b.ToTable("tblUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("77944e84-0b2f-4a5d-9816-41c8fb695a54"),
                            CreateDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "knudtdaw0000@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g="
                        },
                        new
                        {
                            Id = new Guid("be4218cc-3930-4ed0-95f8-f7719cafbbd0"),
                            CreateDate = new DateTime(2024, 12, 16, 13, 4, 40, 443, DateTimeKind.Local).AddTicks(6283),
                            Email = "jbstrange2@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g="
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Balance")
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
                            Id = new Guid("cb211477-0870-4712-b763-3ea5932794b3"),
                            Balance = 1000000.0,
                            UserId = new Guid("77944e84-0b2f-4a5d-9816-41c8fb695a54"),
                            WalletAddress = "0xE2dC61497FDD26F9ea285172A41F0b25373f22df"
                        },
                        new
                        {
                            Id = new Guid("2477bef5-d264-4f20-8124-eb6145d78d36"),
                            Balance = 1000000.0,
                            UserId = new Guid("be4218cc-3930-4ed0-95f8-f7719cafbbd0"),
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
                            Id = new Guid("e22af1d9-b17f-47fb-83bc-561e96d10f69"),
                            ErrorDateTime = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("77944e84-0b2f-4a5d-9816-41c8fb695a54")
                        },
                        new
                        {
                            Id = new Guid("a0e87f4c-b3f3-4eb3-b81c-8786080de538"),
                            ErrorDateTime = new DateTime(2024, 12, 16, 13, 4, 40, 443, DateTimeKind.Local).AddTicks(8516),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("be4218cc-3930-4ed0-95f8-f7719cafbbd0")
                        });
                });

            modelBuilder.Entity("JD.BitBet.PL.tblHand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Result")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("float");

                    b.Property<Guid?>("tblUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("Pk__tblHand_Id");

                    b.HasIndex("tblUserId");

                    b.ToTable("tblHand", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("0d821c4f-52a8-49db-9a80-14f86a67fa7e"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("53c0fdc6-5266-4c28-a26e-a7d253d9104e"),
                            Result = -20.0
                        },
                        new
                        {
                            Id = new Guid("15528964-c3eb-46c4-9403-c1485f6ab04c"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("56879e2d-8906-4535-8f92-2a94ce5d9c76"),
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
                            Id = new Guid("5294742e-512e-4fa2-8e76-8cd3bc1a4860"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("cb211477-0870-4712-b763-3ea5932794b3")
                        },
                        new
                        {
                            Id = new Guid("c806b784-f93f-424a-bdf7-4a34a12c5d9a"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 12, 16, 13, 4, 40, 443, DateTimeKind.Local).AddTicks(7588),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("cb211477-0870-4712-b763-3ea5932794b3")
                        },
                        new
                        {
                            Id = new Guid("c36cb3ca-399a-49a8-b3b2-e6a321a84b59"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(2024, 12, 16, 13, 4, 40, 443, DateTimeKind.Local).AddTicks(7605),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("2477bef5-d264-4f20-8124-eb6145d78d36")
                        },
                        new
                        {
                            Id = new Guid("b4ecc2ee-b451-4de8-9732-47182c109d6e"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 12, 16, 13, 4, 40, 443, DateTimeKind.Local).AddTicks(7615),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("2477bef5-d264-4f20-8124-eb6145d78d36")
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
                    b.HasOne("JD.BitBet.PL.Entities.tblUser", null)
                        .WithMany("Games")
                        .HasForeignKey("tblUserId");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblGameState", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblGame", "game")
                        .WithMany("GameStates")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_tblGameState_GameId");

                    b.HasOne("JD.BitBet.PL.Entities.tblUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("User");

                    b.Navigation("dealerHand");

                    b.Navigation("game");

                    b.Navigation("playerHand");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblUser", b =>
                {
                    b.HasOne("JD.BitBet.PL.Entities.tblGame", "Game")
                        .WithMany("Users")
                        .HasForeignKey("gameId")
                        .HasConstraintName("FK_tblUser_GameId");

                    b.Navigation("Game");
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
                    b.HasOne("JD.BitBet.PL.Entities.tblUser", null)
                        .WithMany("Hands")
                        .HasForeignKey("tblUserId");
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
                    b.Navigation("GameStates");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("JD.BitBet.PL.Entities.tblUser", b =>
                {
                    b.Navigation("ErrorLogs");

                    b.Navigation("Games");

                    b.Navigation("Hands");

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
