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
                            Id = new Guid("418b8864-9d1e-4a75-bd3e-c86d32cde528"),
                            HandId = new Guid("9141772f-228f-4c20-9a72-2b965ecd3210"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("28dddae7-a7aa-49a2-96ec-875281657b57"),
                            HandId = new Guid("9141772f-228f-4c20-9a72-2b965ecd3210"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("1b553851-aa0f-423c-9c7a-7f7a33aa082b"),
                            HandId = new Guid("eeeda15d-170d-4011-886f-424eb8cad0b0"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("49f2374f-1260-44c4-8ff6-6f4bcb67b5fd"),
                            HandId = new Guid("eeeda15d-170d-4011-886f-424eb8cad0b0"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("b2840e55-9169-4a96-a747-8b331d70a645"),
                            HandId = new Guid("1c55ec13-96e9-44e8-b016-2899b10ce6da"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("47f130c2-474c-40a7-97f0-afa4b491b6a7"),
                            HandId = new Guid("1c55ec13-96e9-44e8-b016-2899b10ce6da"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("f7f04368-0f1e-44e6-b451-bf6bf025fa76"),
                            HandId = new Guid("1f573f60-6376-4281-884c-176c49989698"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("d5301eea-17d6-4521-9305-ccb32c115c00"),
                            HandId = new Guid("1f573f60-6376-4281-884c-176c49989698"),
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
                            Id = new Guid("d547d7d1-79cd-459f-9f0e-5f3ffa07d76b"),
                            GameResult = 200.0
                        },
                        new
                        {
                            Id = new Guid("0d32d021-2549-4a81-b99b-aeb50a8b7096"),
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
                            Id = new Guid("8a3040d7-5f95-453f-bbe3-0c7d51b6b162"),
                            GameId = new Guid("d547d7d1-79cd-459f-9f0e-5f3ffa07d76b"),
                            UserId = new Guid("1ef43f52-2f54-4570-a45e-bea01e8e3424"),
                            dealerHandId = new Guid("9141772f-228f-4c20-9a72-2b965ecd3210"),
                            dealerHandVal = 20,
                            isGameOver = true,
                            isPlayerTurn = true,
                            message = "Game Over",
                            playerHandId = new Guid("eeeda15d-170d-4011-886f-424eb8cad0b0"),
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
                            Id = new Guid("1ef43f52-2f54-4570-a45e-bea01e8e3424"),
                            CreateDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "knudtdaw0000@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g="
                        },
                        new
                        {
                            Id = new Guid("a3a521bc-8ffa-4642-8146-4aa93dfff0e3"),
                            CreateDate = new DateTime(2024, 12, 15, 17, 4, 20, 36, DateTimeKind.Local).AddTicks(8138),
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
                            Id = new Guid("447f0152-c8ad-4bbb-8ecd-2e8304391019"),
                            Balance = 1000000.0,
                            UserId = new Guid("1ef43f52-2f54-4570-a45e-bea01e8e3424"),
                            WalletAddress = "0xE2dC61497FDD26F9ea285172A41F0b25373f22df"
                        },
                        new
                        {
                            Id = new Guid("c5c4e216-0975-42df-b3dc-ddd97012f97c"),
                            Balance = 1000000.0,
                            UserId = new Guid("a3a521bc-8ffa-4642-8146-4aa93dfff0e3"),
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
                            Id = new Guid("92291cf9-b5d2-40a4-a386-8d4f77233eb5"),
                            ErrorDateTime = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("1ef43f52-2f54-4570-a45e-bea01e8e3424")
                        },
                        new
                        {
                            Id = new Guid("fabcbe3b-b2f5-48b4-8c6e-28897d91e973"),
                            ErrorDateTime = new DateTime(2024, 12, 15, 17, 4, 20, 37, DateTimeKind.Local).AddTicks(1719),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("a3a521bc-8ffa-4642-8146-4aa93dfff0e3")
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
                            Id = new Guid("9141772f-228f-4c20-9a72-2b965ecd3210"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("eeeda15d-170d-4011-886f-424eb8cad0b0"),
                            Result = -20.0
                        },
                        new
                        {
                            Id = new Guid("1c55ec13-96e9-44e8-b016-2899b10ce6da"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("1f573f60-6376-4281-884c-176c49989698"),
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
                            Id = new Guid("e2fa0255-4f58-400b-94cc-5fde116195a5"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("447f0152-c8ad-4bbb-8ecd-2e8304391019")
                        },
                        new
                        {
                            Id = new Guid("f5c51c54-831c-427d-bea8-e36fd916e4a5"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 12, 15, 17, 4, 20, 37, DateTimeKind.Local).AddTicks(218),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("447f0152-c8ad-4bbb-8ecd-2e8304391019")
                        },
                        new
                        {
                            Id = new Guid("f6b7bf1f-04a1-4d86-a7a3-49a4965c5718"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(2024, 12, 15, 17, 4, 20, 37, DateTimeKind.Local).AddTicks(240),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("c5c4e216-0975-42df-b3dc-ddd97012f97c")
                        },
                        new
                        {
                            Id = new Guid("ba170866-7e46-41d0-aa94-f4b5ad4a01e8"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 12, 15, 17, 4, 20, 37, DateTimeKind.Local).AddTicks(251),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("c5c4e216-0975-42df-b3dc-ddd97012f97c")
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
