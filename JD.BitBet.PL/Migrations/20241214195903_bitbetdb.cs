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
                    CreateDate = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: false),
                    BetAmount = table.Column<double>(type: "float", nullable: true)
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
                    Balance = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: true)
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
                    { new Guid("cc033691-e53c-401d-822a-fa82d8c25f92"), 200.0, null },
                    { new Guid("f1045c5c-cd61-4560-a5b8-fbb331c494cf"), 200.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "Result", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("378f22f9-510d-4495-9c6f-7955218d4c18"), -20.0, null },
                    { new Guid("3e79311e-a5c2-4eec-b178-de657b477398"), 40.0, null },
                    { new Guid("65fe62ce-6136-4489-a9a8-db018a25ffe6"), -20.0, null },
                    { new Guid("775f25ae-7b4a-4d13-b277-8a70b1cec19b"), 40.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "BetAmount", "CreateDate", "Email", "Password", "gameId" },
                values: new object[,]
                {
                    { new Guid("4c7055c4-714f-4e5d-a542-d9566ff66e56"), null, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", null },
                    { new Guid("eae9bc9e-0c8e-4293-be74-a39708b7f18b"), null, new DateTime(2024, 12, 14, 13, 59, 2, 948, DateTimeKind.Local).AddTicks(9829), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", null }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "rank", "suit" },
                values: new object[,]
                {
                    { new Guid("1c055e8c-0f55-4a13-8ea4-5e33d799ecff"), new Guid("378f22f9-510d-4495-9c6f-7955218d4c18"), "Ten", "Diamonds" },
                    { new Guid("4b1eada4-a8f2-408a-b50a-47b3011c6c1e"), new Guid("775f25ae-7b4a-4d13-b277-8a70b1cec19b"), "Ten", "Diamonds" },
                    { new Guid("4ec42f4d-df06-4103-a369-cb1142de26a4"), new Guid("3e79311e-a5c2-4eec-b178-de657b477398"), "Ten", "Diamonds" },
                    { new Guid("56fa8eb6-2d01-41bc-a46b-f82d4ee6179f"), new Guid("65fe62ce-6136-4489-a9a8-db018a25ffe6"), "Ten", "Diamonds" },
                    { new Guid("61075f11-6e99-43d4-b7fc-daec128e8e7a"), new Guid("775f25ae-7b4a-4d13-b277-8a70b1cec19b"), "Ten", "Diamonds" },
                    { new Guid("6858bb38-b24d-4d5b-83cf-453e6e0ec0d2"), new Guid("3e79311e-a5c2-4eec-b178-de657b477398"), "Ten", "Diamonds" },
                    { new Guid("9ca18eb8-c5c4-4231-a43d-4e9f251f5b6a"), new Guid("378f22f9-510d-4495-9c6f-7955218d4c18"), "Ten", "Diamonds" },
                    { new Guid("e1abb0dd-e729-4f05-866e-455477b8cebf"), new Guid("65fe62ce-6136-4489-a9a8-db018a25ffe6"), "Ten", "Diamonds" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("2966cdf1-8e1c-4e3c-b3d7-90f711f4cea6"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("4c7055c4-714f-4e5d-a542-d9566ff66e56") },
                    { new Guid("ea0ef307-d0ad-4c11-a74d-e5403195b13d"), new DateTime(2024, 12, 14, 13, 59, 2, 949, DateTimeKind.Local).AddTicks(2218), "Test", "Login Exception", new Guid("eae9bc9e-0c8e-4293-be74-a39708b7f18b") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "GameId", "UserId", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "message", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("b0eee03d-0346-4308-b649-ce80ace0fea8"), new Guid("cc033691-e53c-401d-822a-fa82d8c25f92"), new Guid("4c7055c4-714f-4e5d-a542-d9566ff66e56"), new Guid("3e79311e-a5c2-4eec-b178-de657b477398"), 20, true, true, "Game Over", new Guid("65fe62ce-6136-4489-a9a8-db018a25ffe6"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("8163955c-6e9b-4a0a-abbc-dc1734ffce2f"), 1000000.0, new Guid("4c7055c4-714f-4e5d-a542-d9566ff66e56"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" },
                    { new Guid("ffb7243a-490d-4436-9503-e9f80331f9cb"), 1000000.0, new Guid("eae9bc9e-0c8e-4293-be74-a39708b7f18b"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("3ec0df88-95ba-456a-aae0-c5c6d6ff4a04"), 2.0, new DateTime(2024, 12, 14, 13, 59, 2, 949, DateTimeKind.Local).AddTicks(1262), "Withdrawal", new Guid("8163955c-6e9b-4a0a-abbc-dc1734ffce2f") },
                    { new Guid("4276b241-80db-499b-bd11-eadc25a0b0f6"), 2.0, new DateTime(2024, 12, 14, 13, 59, 2, 949, DateTimeKind.Local).AddTicks(1289), "Withdrawal", new Guid("ffb7243a-490d-4436-9503-e9f80331f9cb") },
                    { new Guid("484bfe78-d1d6-49e7-b50d-a76e50680d38"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("8163955c-6e9b-4a0a-abbc-dc1734ffce2f") },
                    { new Guid("c666abf7-1886-4517-b1aa-2bac12adf20f"), 1.0, new DateTime(2024, 12, 14, 13, 59, 2, 949, DateTimeKind.Local).AddTicks(1278), "Withdrawal", new Guid("ffb7243a-490d-4436-9503-e9f80331f9cb") }
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
