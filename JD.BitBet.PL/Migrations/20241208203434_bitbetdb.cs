using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JD.BitBet.PL.Migrations
{
    /// <inheritdoc />
    public partial class bitbetdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rank = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    suit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblCard_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblErrorLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrorType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ErrorMessage = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ErrorDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblErrorLog_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameResult = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false),
                    tblUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblGame_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    gameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblUser_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUser_GameId",
                        column: x => x.gameId,
                        principalTable: "tblGame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblHand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BetAmount = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false),
                    Result = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false),
                    tblUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblHand_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblHand_tblUser_tblUserId",
                        column: x => x.tblUserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblWallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblWallet_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblWallet_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblGameState",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dealerHandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    playerHandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    playerHandVal = table.Column<int>(type: "int", nullable: false),
                    dealerHandVal = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    isPlayerTurn = table.Column<bool>(type: "bit", nullable: false),
                    isGameOver = table.Column<bool>(type: "bit", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblGameState_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGameState_GameId",
                        column: x => x.GameId,
                        principalTable: "tblGame",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGameState_tblHand_dealerHandId",
                        column: x => x.dealerHandId,
                        principalTable: "tblHand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGameState_tblHand_playerHandId",
                        column: x => x.playerHandId,
                        principalTable: "tblHand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGameState_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblTransaction_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTransaction_WalletId",
                        column: x => x.WalletId,
                        principalTable: "tblWallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("8bd3cdf4-9f22-413b-997e-f5fc1098d2c9"), 200.0, null },
                    { new Guid("a3073fd7-ad5b-433f-8856-024642c6e814"), 200.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "Result", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("27fa1b2b-be82-443c-b62e-2129a8862f37"), 20.0, 40.0, null },
                    { new Guid("a734b8d5-76a9-486e-ab79-a75ccbd6fdce"), 20.0, 40.0, null },
                    { new Guid("c3677ee3-1aa1-456b-bee7-78e969b56a55"), 20.0, -20.0, null },
                    { new Guid("dd860cdf-5413-44d3-bb9b-28da5065acef"), 20.0, -20.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password", "gameId" },
                values: new object[,]
                {
                    { new Guid("a439a569-97a3-44c3-9629-944538602d47"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", null },
                    { new Guid("c077ddb7-66e3-48d4-8872-19e9207992a6"), new DateTime(2024, 12, 8, 14, 34, 34, 228, DateTimeKind.Local).AddTicks(4511), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", null }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "rank", "suit" },
                values: new object[,]
                {
                    { new Guid("0c4511ba-fcbd-4e4a-a215-80d43b36ed93"), new Guid("c3677ee3-1aa1-456b-bee7-78e969b56a55"), "Ten", "Diamonds" },
                    { new Guid("27578867-37fa-4049-bce9-eafe554c0248"), new Guid("27fa1b2b-be82-443c-b62e-2129a8862f37"), "Ten", "Diamonds" },
                    { new Guid("2b1d3cc4-393b-4222-9fc9-10266aeff15d"), new Guid("c3677ee3-1aa1-456b-bee7-78e969b56a55"), "Ten", "Diamonds" },
                    { new Guid("578d36c7-9689-4dd6-afa2-0398a813e8fb"), new Guid("27fa1b2b-be82-443c-b62e-2129a8862f37"), "Ten", "Diamonds" },
                    { new Guid("7ec4a566-88ef-44f3-b45d-b6e91d58f879"), new Guid("dd860cdf-5413-44d3-bb9b-28da5065acef"), "Ten", "Diamonds" },
                    { new Guid("85435271-af75-4b58-88e3-b7c83851089a"), new Guid("dd860cdf-5413-44d3-bb9b-28da5065acef"), "Ten", "Diamonds" },
                    { new Guid("903744ec-750d-4c56-b1d7-4ee205253bd0"), new Guid("a734b8d5-76a9-486e-ab79-a75ccbd6fdce"), "Ten", "Diamonds" },
                    { new Guid("9abe4a8a-fb0b-4706-a468-5a09f75b94e2"), new Guid("a734b8d5-76a9-486e-ab79-a75ccbd6fdce"), "Ten", "Diamonds" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("2093f19c-e2f4-46a9-92a4-42fd612cf28f"), new DateTime(2024, 12, 8, 14, 34, 34, 228, DateTimeKind.Local).AddTicks(7048), "Test", "Login Exception", new Guid("c077ddb7-66e3-48d4-8872-19e9207992a6") },
                    { new Guid("9f03eb00-707b-4d80-b868-dd89e08a6088"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("a439a569-97a3-44c3-9629-944538602d47") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "GameId", "UserId", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "message", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("ed902398-fb22-4287-9281-d51659e56835"), new Guid("a3073fd7-ad5b-433f-8856-024642c6e814"), new Guid("a439a569-97a3-44c3-9629-944538602d47"), new Guid("a734b8d5-76a9-486e-ab79-a75ccbd6fdce"), 20, true, true, "Game Over", new Guid("c3677ee3-1aa1-456b-bee7-78e969b56a55"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("5aaac97e-7186-4b22-b3b4-876ea9493017"), 0.0, new Guid("a439a569-97a3-44c3-9629-944538602d47"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" },
                    { new Guid("ca9c6c0f-c632-4d1f-b074-ab20ec3b5ded"), 0.0, new Guid("c077ddb7-66e3-48d4-8872-19e9207992a6"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("077f197b-8e44-43b2-9f9d-ab4d1be5fcba"), 1.0, new DateTime(2024, 12, 8, 14, 34, 34, 228, DateTimeKind.Local).AddTicks(6111), "Withdrawal", new Guid("ca9c6c0f-c632-4d1f-b074-ab20ec3b5ded") },
                    { new Guid("3532b7a1-6a21-4c08-8f4b-0ad8c7d8b2a2"), 2.0, new DateTime(2024, 12, 8, 14, 34, 34, 228, DateTimeKind.Local).AddTicks(6096), "Withdrawal", new Guid("5aaac97e-7186-4b22-b3b4-876ea9493017") },
                    { new Guid("79e6252a-13e5-4118-b0ff-8098aa8e0ed4"), 2.0, new DateTime(2024, 12, 8, 14, 34, 34, 228, DateTimeKind.Local).AddTicks(6121), "Withdrawal", new Guid("ca9c6c0f-c632-4d1f-b074-ab20ec3b5ded") },
                    { new Guid("b2e7bf16-f34e-4f2c-b204-16d5170d0436"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("5aaac97e-7186-4b22-b3b4-876ea9493017") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCard_HandId",
                table: "tblCard",
                column: "HandId");

            migrationBuilder.CreateIndex(
                name: "IX_tblErrorLog_UserId",
                table: "tblErrorLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_tblUserId",
                table: "tblGame",
                column: "tblUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameState_dealerHandId",
                table: "tblGameState",
                column: "dealerHandId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameState_GameId",
                table: "tblGameState",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameState_playerHandId",
                table: "tblGameState",
                column: "playerHandId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameState_UserId",
                table: "tblGameState",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHand_tblUserId",
                table: "tblHand",
                column: "tblUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_WalletId",
                table: "tblTransaction",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_gameId",
                table: "tblUser",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblWallet_UserId",
                table: "tblWallet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCard_HandId",
                table: "tblCard",
                column: "HandId",
                principalTable: "tblHand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblErrorLog_UserId",
                table: "tblErrorLog",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblGame_tblUser_tblUserId",
                table: "tblGame",
                column: "tblUserId",
                principalTable: "tblUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblGame_tblUser_tblUserId",
                table: "tblGame");

            migrationBuilder.DropTable(
                name: "tblCard");

            migrationBuilder.DropTable(
                name: "tblErrorLog");

            migrationBuilder.DropTable(
                name: "tblGameState");

            migrationBuilder.DropTable(
                name: "tblTransaction");

            migrationBuilder.DropTable(
                name: "tblHand");

            migrationBuilder.DropTable(
                name: "tblWallet");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblGame");
        }
    }
}
