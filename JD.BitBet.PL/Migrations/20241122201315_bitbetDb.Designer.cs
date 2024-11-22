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
    [Migration("20241122201315_bitbetDb")]
    partial class bitbetDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Rank")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<string>("Suit")
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
                            Id = new Guid("73d97004-ab8b-46c9-83b2-1082f49b0ec7"),
                            HandId = new Guid("4cb54be3-1564-48bd-8b56-861afb1e3cd4"),
                            Rank = 10,
                            Suit = "King"
                        },
                        new
                        {
                            Id = new Guid("08eb2ccd-d7f5-4c05-9b74-310806ebcc71"),
                            HandId = new Guid("4cb54be3-1564-48bd-8b56-861afb1e3cd4"),
                            Rank = 10,
                            Suit = "King"
                        },
                        new
                        {
                            Id = new Guid("cdd9b8ce-2f94-4e8f-b840-c488ec9af4b0"),
                            HandId = new Guid("e5de3280-da6f-4c37-b681-cc10f43e02e5"),
                            Rank = 10,
                            Suit = "King"
                        },
                        new
                        {
                            Id = new Guid("3eef7fc9-01c0-4d7c-9079-98524bc28b12"),
                            HandId = new Guid("e5de3280-da6f-4c37-b681-cc10f43e02e5"),
                            Rank = 10,
                            Suit = "King"
                        },
                        new
                        {
                            Id = new Guid("4ece2805-0808-4279-904f-6486188fcb95"),
                            HandId = new Guid("5f2ea554-16fc-4aad-8cad-45ce2d06fa25"),
                            Rank = 10,
                            Suit = "King"
                        },
                        new
                        {
                            Id = new Guid("f7167733-62f9-4f22-ad4a-189ea65e6c5b"),
                            HandId = new Guid("5f2ea554-16fc-4aad-8cad-45ce2d06fa25"),
                            Rank = 10,
                            Suit = "King"
                        },
                        new
                        {
                            Id = new Guid("ffb2760d-a0f7-4afe-95a0-ac99a35a77f7"),
                            HandId = new Guid("f29f1db4-b7df-4c8d-b05d-5bf4617aa984"),
                            Rank = 10,
                            Suit = "King"
                        },
                        new
                        {
                            Id = new Guid("cab833fe-a603-4db7-970a-887b30c4a8a1"),
                            HandId = new Guid("f29f1db4-b7df-4c8d-b05d-5bf4617aa984"),
                            Rank = 10,
                            Suit = "King"
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
                            Id = new Guid("3599c810-222f-44f1-88a4-8a5717f039fc"),
                            GameResult = 200.0,
                            UserId = new Guid("be50dafe-171b-4c91-ac0a-194403de1c77")
                        },
                        new
                        {
                            Id = new Guid("6b3ee27d-9fc0-48ed-a0fd-ec1b72ee5c03"),
                            GameResult = 200.0,
                            UserId = new Guid("be50dafe-171b-4c91-ac0a-194403de1c77")
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
                            Id = new Guid("95d78504-43ac-4f05-9e8b-96c83ba44cb8"),
                            dealerHandId = new Guid("4cb54be3-1564-48bd-8b56-861afb1e3cd4"),
                            dealerHandVal = 20,
                            isGameOver = true,
                            isPlayerTurn = true,
                            playerHandId = new Guid("e5de3280-da6f-4c37-b681-cc10f43e02e5"),
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
                            Id = new Guid("be50dafe-171b-4c91-ac0a-194403de1c77"),
                            CreateDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "knudtdaw0000@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g="
                        },
                        new
                        {
                            Id = new Guid("73958790-a19a-48f6-9ff4-5b2c6b34115a"),
                            CreateDate = new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(2287),
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
                            Id = new Guid("fcee1dc0-13b6-4ce3-bd3f-01149118296d"),
                            Balance = 0.0,
                            UserId = new Guid("be50dafe-171b-4c91-ac0a-194403de1c77"),
                            WalletAddress = "0xE2dC61497FDD26F9ea285172A41F0b25373f22df"
                        },
                        new
                        {
                            Id = new Guid("f106a3d6-7b57-4c4a-b5ae-9d344a31475d"),
                            Balance = 0.0,
                            UserId = new Guid("73958790-a19a-48f6-9ff4-5b2c6b34115a"),
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
                            Id = new Guid("d4e1175b-e2db-48c5-9325-1ddb0060dc3b"),
                            ErrorDateTime = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("be50dafe-171b-4c91-ac0a-194403de1c77")
                        },
                        new
                        {
                            Id = new Guid("1172c75a-d9dd-4515-8ac1-9659efaa8b97"),
                            ErrorDateTime = new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(6716),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("73958790-a19a-48f6-9ff4-5b2c6b34115a")
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
                            Id = new Guid("4cb54be3-1564-48bd-8b56-861afb1e3cd4"),
                            BetAmount = 20.0,
                            GameId = new Guid("3599c810-222f-44f1-88a4-8a5717f039fc"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("e5de3280-da6f-4c37-b681-cc10f43e02e5"),
                            BetAmount = 20.0,
                            GameId = new Guid("6b3ee27d-9fc0-48ed-a0fd-ec1b72ee5c03"),
                            Result = -20.0
                        },
                        new
                        {
                            Id = new Guid("5f2ea554-16fc-4aad-8cad-45ce2d06fa25"),
                            BetAmount = 20.0,
                            GameId = new Guid("3599c810-222f-44f1-88a4-8a5717f039fc"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("f29f1db4-b7df-4c8d-b05d-5bf4617aa984"),
                            BetAmount = 20.0,
                            GameId = new Guid("6b3ee27d-9fc0-48ed-a0fd-ec1b72ee5c03"),
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
                            Id = new Guid("058a62a0-f457-416d-9b12-35b4124f474c"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("fcee1dc0-13b6-4ce3-bd3f-01149118296d")
                        },
                        new
                        {
                            Id = new Guid("f2a524c6-3449-46ce-b6b5-7b9666e5f6c9"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(4204),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("fcee1dc0-13b6-4ce3-bd3f-01149118296d")
                        },
                        new
                        {
                            Id = new Guid("496730a7-fc72-41c9-aa0a-6183e8558884"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(4240),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("f106a3d6-7b57-4c4a-b5ae-9d344a31475d")
                        },
                        new
                        {
                            Id = new Guid("b78d1052-b687-45de-a40e-741694a3488e"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(4251),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("f106a3d6-7b57-4c4a-b5ae-9d344a31475d")
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
                        .WithMany("dealerGameStates")
                        .HasForeignKey("dealerHandId")
                        .IsRequired()
                        .HasConstraintName("FK_tblGameState_DealerHandId");

                    b.HasOne("JD.BitBet.PL.tblHand", "playerHand")
                        .WithMany("playerGameStates")
                        .HasForeignKey("playerHandId")
                        .IsRequired()
                        .HasConstraintName("FK_tblGameState_PlayerHand");

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
                    b.HasOne("JD.BitBet.PL.Entities.tblGame", "Game")
                        .WithMany("Hands")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tblHand_GameId");

                    b.Navigation("Game");
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

                    b.Navigation("dealerGameStates");

                    b.Navigation("playerGameStates");
                });
#pragma warning restore 612, 618
        }
    }
}