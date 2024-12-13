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
    [Migration("20241212013335_BitBetDb")]
    partial class BitBetDb
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
                            Id = new Guid("03520abb-c092-41dc-b0c9-1d693132ce82"),
                            HandId = new Guid("6e15dc31-540a-4abc-9c50-677c093048ca"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("3b8d817f-ccdd-4040-a713-1fa6529a7e92"),
                            HandId = new Guid("6e15dc31-540a-4abc-9c50-677c093048ca"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("55b4e339-bf61-4fa0-b904-d02b33dfb8a4"),
                            HandId = new Guid("1323b289-ea15-40a2-912c-7d67f2e8f087"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("fe1930e5-56b1-426e-bd9e-efa4b15962c8"),
                            HandId = new Guid("1323b289-ea15-40a2-912c-7d67f2e8f087"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("7c967c0a-4714-49ae-9fff-03c185be4c4d"),
                            HandId = new Guid("672d2c7c-1bcf-402a-86b4-cebbaa842608"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("5a3f3383-bc5e-4731-8c0e-1037ef15ef86"),
                            HandId = new Guid("672d2c7c-1bcf-402a-86b4-cebbaa842608"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("9623fc2d-65b8-40fa-923d-edfa28d4678e"),
                            HandId = new Guid("d874acdf-0ac9-4d78-bcdd-1cbaf50f1aeb"),
                            rank = "Ten",
                            suit = "Diamonds"
                        },
                        new
                        {
                            Id = new Guid("ed4f96a7-9a2c-412f-a59a-b50a23ac85a0"),
                            HandId = new Guid("d874acdf-0ac9-4d78-bcdd-1cbaf50f1aeb"),
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
                            Id = new Guid("9a620111-bb5e-4296-b04a-ddd0712e72bd"),
                            GameResult = 200.0
                        },
                        new
                        {
                            Id = new Guid("27d68521-e326-4699-bf99-cdebbb704210"),
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
                            Id = new Guid("47ecbaf4-bca5-42b7-ab83-70c89d7ee836"),
                            GameId = new Guid("9a620111-bb5e-4296-b04a-ddd0712e72bd"),
                            UserId = new Guid("16c0e7d7-25f4-4632-a6c5-421f7b767397"),
                            dealerHandId = new Guid("6e15dc31-540a-4abc-9c50-677c093048ca"),
                            dealerHandVal = 20,
                            isGameOver = true,
                            isPlayerTurn = true,
                            message = "Game Over",
                            playerHandId = new Guid("1323b289-ea15-40a2-912c-7d67f2e8f087"),
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
                            Id = new Guid("16c0e7d7-25f4-4632-a6c5-421f7b767397"),
                            CreateDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "knudtdaw0000@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g="
                        },
                        new
                        {
                            Id = new Guid("d0a0015b-dd89-44e9-a800-adadcac86605"),
                            CreateDate = new DateTime(2024, 12, 11, 19, 33, 34, 946, DateTimeKind.Local).AddTicks(9256),
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
                            Id = new Guid("d5422069-8a48-43ff-ba63-f5720842bbf7"),
                            Balance = 1000000.0,
                            UserId = new Guid("16c0e7d7-25f4-4632-a6c5-421f7b767397"),
                            WalletAddress = "0xE2dC61497FDD26F9ea285172A41F0b25373f22df"
                        },
                        new
                        {
                            Id = new Guid("79343ad5-a718-45b9-b269-dc62837716a2"),
                            Balance = 1000000.0,
                            UserId = new Guid("d0a0015b-dd89-44e9-a800-adadcac86605"),
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
                            Id = new Guid("d56dd140-ea07-4f6a-83a5-e98d12425819"),
                            ErrorDateTime = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("16c0e7d7-25f4-4632-a6c5-421f7b767397")
                        },
                        new
                        {
                            Id = new Guid("6907bd59-e35e-4cdd-8875-e0d7581727f3"),
                            ErrorDateTime = new DateTime(2024, 12, 11, 19, 33, 34, 947, DateTimeKind.Local).AddTicks(1849),
                            ErrorMessage = "Test",
                            ErrorType = "Login Exception",
                            UserId = new Guid("d0a0015b-dd89-44e9-a800-adadcac86605")
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
                            Id = new Guid("6e15dc31-540a-4abc-9c50-677c093048ca"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("1323b289-ea15-40a2-912c-7d67f2e8f087"),
                            Result = -20.0
                        },
                        new
                        {
                            Id = new Guid("672d2c7c-1bcf-402a-86b4-cebbaa842608"),
                            Result = 40.0
                        },
                        new
                        {
                            Id = new Guid("d874acdf-0ac9-4d78-bcdd-1cbaf50f1aeb"),
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
                            Id = new Guid("42c14355-6594-4740-b7d8-f1d8460865c5"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("d5422069-8a48-43ff-ba63-f5720842bbf7")
                        },
                        new
                        {
                            Id = new Guid("87c5d6a0-1c8a-4035-9dc7-3d719f84832e"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 12, 11, 19, 33, 34, 947, DateTimeKind.Local).AddTicks(788),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("d5422069-8a48-43ff-ba63-f5720842bbf7")
                        },
                        new
                        {
                            Id = new Guid("bfb26ed1-4599-4e89-b56d-727d2056f61c"),
                            Amount = 1.0,
                            TransactionDate = new DateTime(2024, 12, 11, 19, 33, 34, 947, DateTimeKind.Local).AddTicks(804),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("79343ad5-a718-45b9-b269-dc62837716a2")
                        },
                        new
                        {
                            Id = new Guid("57d6ec16-b86f-4a34-a000-53f3f888b0c7"),
                            Amount = 2.0,
                            TransactionDate = new DateTime(2024, 12, 11, 19, 33, 34, 947, DateTimeKind.Local).AddTicks(815),
                            TransactionType = "Withdrawal",
                            WalletId = new Guid("79343ad5-a718-45b9-b269-dc62837716a2")
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