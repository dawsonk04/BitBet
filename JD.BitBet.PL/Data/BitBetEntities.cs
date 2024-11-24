using JD.BitBet.PL.Entities;
using Microsoft.EntityFrameworkCore;
using static JD.BitBet.PL.Entities.tblCard;

namespace JD.BitBet.PL.Data
{
    public class BitBetEntities : DbContext
    {
        Guid[] userId = new Guid[2];
        Guid[] walletId = new Guid[2];
        Guid[] transactionId = new Guid[4];
        Guid[] gameId = new Guid[2];
        Guid[] errorLogId = new Guid[2];
        Guid[] handId = new Guid[4];
        Guid[] cardId = new Guid[8];
        Guid[] gameStateId = new Guid[1];

        public BitBetEntities(DbContextOptions<BitBetEntities> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public BitBetEntities()
        {
        }

        public virtual DbSet<tblErrorLog> tblErrors { get; set; }
        public virtual DbSet<tblGame> tblGame { get; set; }
        public virtual DbSet<tblHand> tblHand { get; set; }
        public virtual DbSet<tblTransaction> tblTransaction { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }
        public virtual DbSet<tblWallet> tblWallet { get; set; }
        public virtual DbSet<tblGameState> tblGameState{ get; set; }
        public virtual DbSet<tblCard> tblCard { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateUsers(modelBuilder);
            CreateWallets(modelBuilder);
            CreateTransactions(modelBuilder);
            CreateGames(modelBuilder);
            CreateHands(modelBuilder);
            CreateErrors(modelBuilder);
            CreateCards(modelBuilder);
            CreateGameState(modelBuilder);

        }

        private void CreateGameState(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < gameStateId.Length; i++)
            {
                gameStateId[i] = Guid.NewGuid();
            }
            modelBuilder.Entity<tblGameState>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Pk__tblGameState_Id");

                entity.ToTable("tblGameState");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.isPlayerTurn);
                entity.Property(e => e.dealerHandVal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(e => e.playerHand)
                  .WithMany()
                  .HasForeignKey(e => e.playerHandId)
                  .OnDelete(DeleteBehavior.NoAction);  
                entity.HasOne(e => e.dealerHand)
                    .WithMany()
                    .HasForeignKey(e => e.dealerHandId)
                    .OnDelete(DeleteBehavior.NoAction);

            });
            modelBuilder.Entity<tblGameState>().HasData(new tblGameState
            {
                Id = gameStateId[0],
                isGameOver = true,
                isPlayerTurn = true,
                dealerHandId = handId[0],
                playerHandId = handId[1],
                playerHandVal = 20,
                dealerHandVal = 20,
            });
        }

        private void CreateWallets(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < walletId.Length; i++)
            {
                walletId[i] = Guid.NewGuid();
            }
            modelBuilder.Entity<tblWallet>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Pk__tblWallet_Id");

                entity.ToTable("tblWallet");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Balance)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.WalletAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.HasOne(e => e.User)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblWallet_UserId");
            });
            modelBuilder.Entity<tblWallet>().HasData(new tblWallet
            {
                Id = walletId[0],
                WalletAddress = "0xE2dC61497FDD26F9ea285172A41F0b25373f22df",
                UserId = userId[0],
                Balance = 0.0
            });
            modelBuilder.Entity<tblWallet>().HasData(new tblWallet
            {
                Id = walletId[1],
                WalletAddress = "0xE2dC61497FDD26F9eaYaBoi5373f22df",
                UserId = userId[1],
                Balance = 0.0
            });
        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userId.Length; i++)
            {
                userId[i] = Guid.NewGuid();
            }
            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Pk__tblUser_Id");

                entity.ToTable("tblUser");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CreateDate)
                   .HasMaxLength(50)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<tblUser>().HasData(new tblUser
            {
                Id = userId[0],
                Email = "knudtdaw0000@gmail.com",
                Password = GetHash("password"),
                CreateDate = new DateTime(1990, 12, 4),
            });
            modelBuilder.Entity<tblUser>().HasData(new tblUser
            {
                Id = userId[1],
                Email = "jbstrange2@gmail.com",
                Password = GetHash("password"),
                CreateDate = DateTime.Now,
            });
        }

        private void CreateTransactions(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < transactionId.Length; i++)
            {
                transactionId[i] = Guid.NewGuid();
            }
            modelBuilder.Entity<tblTransaction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Pk__tblTransaction_Id");

                entity.ToTable("tblTransaction");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TransactionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.HasOne(e => e.Wallet)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblTransaction_WalletId");
            });
            modelBuilder.Entity<tblTransaction>().HasData(new tblTransaction
            {
                Id = transactionId[0],
                WalletId = walletId[0],
                TransactionType = "Withdrawal",
                TransactionDate = new DateTime(1990, 12, 4),
                Amount = 1,
            });
            modelBuilder.Entity<tblTransaction>().HasData(new tblTransaction
            {
                Id = transactionId[1],
                WalletId = walletId[0],
                TransactionType = "Withdrawal",
                TransactionDate = DateTime.Now,
                Amount = 2,
            });
            modelBuilder.Entity<tblTransaction>().HasData(new tblTransaction
            {
                Id = transactionId[2],
                WalletId = walletId[1],
                TransactionType = "Withdrawal",
                TransactionDate = DateTime.Now,
                Amount = 1,
            });
            modelBuilder.Entity<tblTransaction>().HasData(new tblTransaction
            {
                Id = transactionId[3],
                WalletId = walletId[1],
                TransactionType = "Withdrawal",
                TransactionDate = DateTime.Now,
                Amount = 2,
            });
        }
        private void CreateHands(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < handId.Length; i++)
            {
                handId[i] = Guid.NewGuid();
            }
            modelBuilder.Entity<tblHand>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Pk__tblHand_Id");

                entity.ToTable("tblHand");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Result)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.BetAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<tblHand>().HasData(new tblHand
            {
                Id = handId[0],
                BetAmount = 20.00,
                Result = 40.00,
            });
            modelBuilder.Entity<tblHand>().HasData(new tblHand
            {
                Id = handId[1],
                BetAmount = 20.00,
                Result = -20.00,
            });
            modelBuilder.Entity<tblHand>().HasData(new tblHand
            {
                Id = handId[2],
                BetAmount = 20.00,
                Result = 40.00,
            });
            modelBuilder.Entity<tblHand>().HasData(new tblHand
            {
                Id = handId[3],
                BetAmount = 20.00,
                Result = -20.00,
            });
        }

        private void CreateGames(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < gameId.Length; i++)
            {
                gameId[i] = Guid.NewGuid();
            }
            modelBuilder.Entity<tblGame>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Pk__tblGame_Id");

                entity.ToTable("tblGame");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.GameResult)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.HasOne(e => e.User)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblGame_UserId");
            });
            modelBuilder.Entity<tblGame>().HasData(new tblGame
            {
                Id = gameId[0],
                GameResult = 200.00,
                UserId = userId[0],
            });
            modelBuilder.Entity<tblGame>().HasData(new tblGame
            {
                Id = gameId[1],
                GameResult = 200.00,
                UserId = userId[0],
            });
        }

        private void CreateErrors(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < errorLogId.Length; i++)
            {
                errorLogId[i] = Guid.NewGuid();
            }
            modelBuilder.Entity<tblErrorLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tblErrorLog_Id");

                entity.ToTable("tblErrorLog");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.ErrorType)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.HasOne(e => e.User)
                     .WithMany(p => p.ErrorLogs)
                     .HasForeignKey(d => d.UserId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_tblErrorLog_UserId");
            });
            modelBuilder.Entity<tblErrorLog>().HasData(new tblErrorLog
            {
                Id = errorLogId[0],
                UserId = userId[0],
                ErrorType = "Login Exception",
                ErrorMessage = "Test",
                ErrorDateTime = new DateTime(1990, 12, 4),
            });
            modelBuilder.Entity<tblErrorLog>().HasData(new tblErrorLog
            {
                Id = errorLogId[1],
                UserId = userId[1],
                ErrorType = "Login Exception",
                ErrorMessage = "Test",
                ErrorDateTime = DateTime.Now,
            });
        }

        private void CreateCards(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < cardId.Length; i++)
            {
                cardId[i] = Guid.NewGuid();
            }
            modelBuilder.Entity<tblCard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Pk__tblCard_Id");

                entity.ToTable("tblCard");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.rank)
                    .HasConversion<string>() // Converts enum to string in the database
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.suit)
                    .HasConversion<string>() // Converts enum to string in the database
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.HasOne(e => e.hand)
                    .WithMany(p => p.cards)
                    .HasForeignKey(d => d.HandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblCard_HandId");
            });
            modelBuilder.Entity<tblCard>().HasData(new tblCard
            {
                Id = cardId[0],
                HandId = handId[0],
                rank = Rank.Ten,
                suit = Suit.Diamonds
            });
            modelBuilder.Entity<tblCard>().HasData(new tblCard
            {
                Id = cardId[1],
                HandId = handId[0],
                rank = Rank.Ten,
                suit = Suit.Diamonds
            });
            modelBuilder.Entity<tblCard>().HasData(new tblCard
            {
                Id = cardId[2],
                HandId = handId[1],
                rank = Rank.Ten,
                suit = Suit.Diamonds
            });
            modelBuilder.Entity<tblCard>().HasData(new tblCard
            {
                Id = cardId[3],
                HandId = handId[1],
                rank = Rank.Ten,
                suit = Suit.Diamonds
            });
            modelBuilder.Entity<tblCard>().HasData(new tblCard
            {
                Id = cardId[4],
                HandId = handId[2],
                rank = Rank.Ten,
                suit = Suit.Diamonds
            });
            modelBuilder.Entity<tblCard>().HasData(new tblCard
            {
                Id = cardId[5],
                HandId = handId[2],
                rank = Rank.Ten,
                suit = Suit.Diamonds
            });
            modelBuilder.Entity<tblCard>().HasData(new tblCard
            {
                Id = cardId[6],
                HandId = handId[3],
                rank = Rank.Ten,
                suit = Suit.Diamonds
            });
            modelBuilder.Entity<tblCard>().HasData(new tblCard
            {
                Id = cardId[7],
                HandId = handId[3],
                rank = Rank.Ten,
                suit = Suit.Diamonds
            });
           
        }

        private static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }
    }
}
