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
                    { new Guid("26d0567c-5cca-4616-95b4-543330b2e448"), 200.0, null },
                    { new Guid("e5d2afca-d67e-4b3a-b6dc-99384ca86fcf"), 200.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "Result", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("66909f48-7305-41e8-a1ce-40582cbb16d3"), 20.0, -20.0, null },
                    { new Guid("6f83187b-f57e-4ad9-a26b-5375ff650027"), 20.0, -20.0, null },
                    { new Guid("8eb08e72-593f-4cc3-bb0c-2acf48b318c3"), 20.0, 40.0, null },
                    { new Guid("d318a61a-4569-413f-9a8c-4d99808b55dc"), 20.0, 40.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password", "gameId" },
                values: new object[,]
                {
                    { new Guid("0478b54a-2061-4df5-a0b0-a966e6ffc71a"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", null },
                    { new Guid("956e5dbe-3dac-4a09-9599-685e52f0deaa"), new DateTime(2024, 12, 2, 21, 52, 0, 436, DateTimeKind.Local).AddTicks(7982), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", null }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "rank", "suit" },
                values: new object[,]
                {
                    { new Guid("05802083-e84c-4b33-a03c-281b13ba1e47"), new Guid("66909f48-7305-41e8-a1ce-40582cbb16d3"), "Ten", "Diamonds" },
                    { new Guid("6183cb27-983f-4097-ba6e-ed209b0f90b3"), new Guid("d318a61a-4569-413f-9a8c-4d99808b55dc"), "Ten", "Diamonds" },
                    { new Guid("76c9cc38-e613-4b72-8ace-4e25b4f9ba3e"), new Guid("d318a61a-4569-413f-9a8c-4d99808b55dc"), "Ten", "Diamonds" },
                    { new Guid("957c028a-269b-4fd6-8da2-dbd4df6d78f6"), new Guid("8eb08e72-593f-4cc3-bb0c-2acf48b318c3"), "Ten", "Diamonds" },
                    { new Guid("9f940adb-ba1d-4f86-a17d-8efefb1539ed"), new Guid("8eb08e72-593f-4cc3-bb0c-2acf48b318c3"), "Ten", "Diamonds" },
                    { new Guid("b1dce868-c01a-4735-b891-b0f51cc2c2be"), new Guid("66909f48-7305-41e8-a1ce-40582cbb16d3"), "Ten", "Diamonds" },
                    { new Guid("f48a4164-2437-4587-9c62-3ca40d157c2a"), new Guid("6f83187b-f57e-4ad9-a26b-5375ff650027"), "Ten", "Diamonds" },
                    { new Guid("fc176d9e-6b2c-48cb-a0c3-9a67921171d7"), new Guid("6f83187b-f57e-4ad9-a26b-5375ff650027"), "Ten", "Diamonds" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("61581e9f-617c-4c39-80d4-3969f5a93b58"), new DateTime(2024, 12, 2, 21, 52, 0, 437, DateTimeKind.Local).AddTicks(782), "Test", "Login Exception", new Guid("956e5dbe-3dac-4a09-9599-685e52f0deaa") },
                    { new Guid("9858000b-4bc9-4fad-a5b3-c465ea8a6355"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("0478b54a-2061-4df5-a0b0-a966e6ffc71a") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "GameId", "UserId", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "message", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("3ec05eb5-3d1f-4716-89db-94f4fe6eaaed"), new Guid("e5d2afca-d67e-4b3a-b6dc-99384ca86fcf"), new Guid("0478b54a-2061-4df5-a0b0-a966e6ffc71a"), new Guid("d318a61a-4569-413f-9a8c-4d99808b55dc"), 20, true, true, "Game Over", new Guid("66909f48-7305-41e8-a1ce-40582cbb16d3"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("1ffaa532-0b18-4725-abae-ad59aaab323e"), 0.0, new Guid("0478b54a-2061-4df5-a0b0-a966e6ffc71a"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" },
                    { new Guid("f928a6f5-0335-4fa0-bdb7-60a78504e47c"), 0.0, new Guid("956e5dbe-3dac-4a09-9599-685e52f0deaa"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("1ea04b68-d430-4b64-b3c9-02e274151a75"), 1.0, new DateTime(2024, 12, 2, 21, 52, 0, 436, DateTimeKind.Local).AddTicks(9623), "Withdrawal", new Guid("f928a6f5-0335-4fa0-bdb7-60a78504e47c") },
                    { new Guid("200d6a84-2007-4db6-abe8-892ee7d999e1"), 2.0, new DateTime(2024, 12, 2, 21, 52, 0, 436, DateTimeKind.Local).AddTicks(9599), "Withdrawal", new Guid("1ffaa532-0b18-4725-abae-ad59aaab323e") },
                    { new Guid("4d8d1477-5cb0-4803-b44f-27a47551af90"), 2.0, new DateTime(2024, 12, 2, 21, 52, 0, 436, DateTimeKind.Local).AddTicks(9634), "Withdrawal", new Guid("f928a6f5-0335-4fa0-bdb7-60a78504e47c") },
                    { new Guid("a8033aeb-9ca8-4190-92ce-1900ce255eb3"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("1ffaa532-0b18-4725-abae-ad59aaab323e") }
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
