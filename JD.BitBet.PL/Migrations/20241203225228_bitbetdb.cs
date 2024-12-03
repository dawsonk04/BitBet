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
                    { new Guid("20b67422-e4a5-4cb9-b9fe-f4a4e53f502e"), 200.0, null },
                    { new Guid("4c8dbf1a-3ff8-4c6d-b663-5137f0b41f96"), 200.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "Result", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("08c25cd7-0b05-4794-88ff-d95796d27900"), 20.0, -20.0, null },
                    { new Guid("2dc606e4-2ae9-46c1-8f6a-f2da4a13764c"), 20.0, 40.0, null },
                    { new Guid("adf851d1-f68c-4e08-b3e3-c5dfa7ea2089"), 20.0, -20.0, null },
                    { new Guid("c27c09f7-9893-4635-9d7f-82d1525e6bdb"), 20.0, 40.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password", "gameId" },
                values: new object[,]
                {
                    { new Guid("0d3b174a-08a8-4cdd-9ea3-c171b6fdc0be"), new DateTime(2024, 12, 3, 16, 52, 28, 137, DateTimeKind.Local).AddTicks(3122), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", null },
                    { new Guid("a460247e-8f29-4b77-9433-bc0ed95cbf2c"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", null }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "rank", "suit" },
                values: new object[,]
                {
                    { new Guid("14c622e1-1e5c-4d91-aadf-c5313a8aeaac"), new Guid("c27c09f7-9893-4635-9d7f-82d1525e6bdb"), "Ten", "Diamonds" },
                    { new Guid("2e610ebe-930c-46f4-8377-c65d4ab681fe"), new Guid("08c25cd7-0b05-4794-88ff-d95796d27900"), "Ten", "Diamonds" },
                    { new Guid("5c44d7c3-bf7b-4754-9de1-cf3efac349a9"), new Guid("adf851d1-f68c-4e08-b3e3-c5dfa7ea2089"), "Ten", "Diamonds" },
                    { new Guid("8dab0ee9-327c-417e-8c70-6b7622bd91f1"), new Guid("08c25cd7-0b05-4794-88ff-d95796d27900"), "Ten", "Diamonds" },
                    { new Guid("b5839949-3b8f-4809-87f7-2576f8f47d2b"), new Guid("2dc606e4-2ae9-46c1-8f6a-f2da4a13764c"), "Ten", "Diamonds" },
                    { new Guid("d6f6fff5-cf1e-4953-ba25-a75a64858c93"), new Guid("c27c09f7-9893-4635-9d7f-82d1525e6bdb"), "Ten", "Diamonds" },
                    { new Guid("e1f5311c-f576-4659-9232-22862ef19f1a"), new Guid("2dc606e4-2ae9-46c1-8f6a-f2da4a13764c"), "Ten", "Diamonds" },
                    { new Guid("f3bcc768-cd56-41c3-a819-3dbcf504401f"), new Guid("adf851d1-f68c-4e08-b3e3-c5dfa7ea2089"), "Ten", "Diamonds" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("35ab8030-7ab8-4d06-8951-75d4a05a70cc"), new DateTime(2024, 12, 3, 16, 52, 28, 137, DateTimeKind.Local).AddTicks(6085), "Test", "Login Exception", new Guid("0d3b174a-08a8-4cdd-9ea3-c171b6fdc0be") },
                    { new Guid("d16f66fb-ae5c-444e-81aa-2c08f18abddd"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("a460247e-8f29-4b77-9433-bc0ed95cbf2c") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "GameId", "UserId", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "message", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("7ec14922-40e8-481e-aa2a-cf12e69751bb"), new Guid("4c8dbf1a-3ff8-4c6d-b663-5137f0b41f96"), new Guid("a460247e-8f29-4b77-9433-bc0ed95cbf2c"), new Guid("2dc606e4-2ae9-46c1-8f6a-f2da4a13764c"), 20, true, true, "Game Over", new Guid("08c25cd7-0b05-4794-88ff-d95796d27900"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("88b1eee4-ee56-47c6-ab77-c818bf438a68"), 0.0, new Guid("a460247e-8f29-4b77-9433-bc0ed95cbf2c"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" },
                    { new Guid("977d7c99-e479-400f-a027-53fdcb735c5a"), 0.0, new Guid("0d3b174a-08a8-4cdd-9ea3-c171b6fdc0be"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("43bc3884-0b6f-4b43-9228-6daedeabce45"), 2.0, new DateTime(2024, 12, 3, 16, 52, 28, 137, DateTimeKind.Local).AddTicks(4832), "Withdrawal", new Guid("88b1eee4-ee56-47c6-ab77-c818bf438a68") },
                    { new Guid("a8eb764b-8dc8-41f5-95e5-7c1f5eca01ab"), 2.0, new DateTime(2024, 12, 3, 16, 52, 28, 137, DateTimeKind.Local).AddTicks(4867), "Withdrawal", new Guid("977d7c99-e479-400f-a027-53fdcb735c5a") },
                    { new Guid("b9527c70-1076-4b00-a9af-17716916866a"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("88b1eee4-ee56-47c6-ab77-c818bf438a68") },
                    { new Guid("dc600d0a-1754-45b2-851a-5a0a01341f15"), 1.0, new DateTime(2024, 12, 3, 16, 52, 28, 137, DateTimeKind.Local).AddTicks(4852), "Withdrawal", new Guid("977d7c99-e479-400f-a027-53fdcb735c5a") }
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
