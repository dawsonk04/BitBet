using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JD.BitBet.PL.Migrations
{
    /// <inheritdoc />
    public partial class bitbetDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblUser_Id", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_tblErrorLog_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameResult = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblGame_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGame_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "tblHand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BetAmount = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false),
                    Result = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false),
                    tblGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tblUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblHand_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblHand_tblGame_tblGameId",
                        column: x => x.tblGameId,
                        principalTable: "tblGame",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblHand_tblUser_tblUserId",
                        column: x => x.tblUserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_tblCard_HandId",
                        column: x => x.HandId,
                        principalTable: "tblHand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblGameState",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_tblGameState_tblHand_dealerHandId",
                        column: x => x.dealerHandId,
                        principalTable: "tblHand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGameState_tblHand_playerHandId",
                        column: x => x.playerHandId,
                        principalTable: "tblHand",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "Result", "tblGameId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("6bdd6a0a-53a8-45bd-943d-38517b396ca8"), 20.0, 40.0, null, null },
                    { new Guid("7e60a080-9848-472d-b0af-e4711448fe13"), 20.0, -20.0, null, null },
                    { new Guid("8a6c9f10-6f4b-4394-a092-08015f6178c8"), 20.0, 40.0, null, null },
                    { new Guid("9a868bf9-d918-4aee-aed0-7a1b7e70779e"), 20.0, -20.0, null, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("3ca9704e-83f4-49ff-98a5-b6e69f5c70fe"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("57d00112-de2f-4d52-b5f3-49058a20f204"), new DateTime(2024, 11, 26, 21, 3, 51, 419, DateTimeKind.Local).AddTicks(6773), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "rank", "suit" },
                values: new object[,]
                {
                    { new Guid("00c1fba8-8e08-4164-9a11-8f557d4adde2"), new Guid("9a868bf9-d918-4aee-aed0-7a1b7e70779e"), "Ten", "Diamonds" },
                    { new Guid("0ccdcdf9-b74a-49b3-b9b5-06c76b5e71f5"), new Guid("8a6c9f10-6f4b-4394-a092-08015f6178c8"), "Ten", "Diamonds" },
                    { new Guid("3dcfd3f8-655e-46fd-820d-522ef5cb907b"), new Guid("6bdd6a0a-53a8-45bd-943d-38517b396ca8"), "Ten", "Diamonds" },
                    { new Guid("4a1bef39-3bcf-4c68-9fa0-cb18910d13ab"), new Guid("7e60a080-9848-472d-b0af-e4711448fe13"), "Ten", "Diamonds" },
                    { new Guid("6efc1ca5-2b1e-4c88-a95a-e0e9bea8165c"), new Guid("7e60a080-9848-472d-b0af-e4711448fe13"), "Ten", "Diamonds" },
                    { new Guid("71337b9f-5d2c-4396-b38a-3a00ba305750"), new Guid("8a6c9f10-6f4b-4394-a092-08015f6178c8"), "Ten", "Diamonds" },
                    { new Guid("b9cd4fe6-08cb-45f1-ba56-96be3916bc9d"), new Guid("6bdd6a0a-53a8-45bd-943d-38517b396ca8"), "Ten", "Diamonds" },
                    { new Guid("ef5da372-500e-42bd-b361-3e1573c6baae"), new Guid("9a868bf9-d918-4aee-aed0-7a1b7e70779e"), "Ten", "Diamonds" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("873a9d35-23d8-419c-8ada-e328fa432587"), new DateTime(2024, 11, 26, 21, 3, 51, 419, DateTimeKind.Local).AddTicks(9956), "Test", "Login Exception", new Guid("57d00112-de2f-4d52-b5f3-49058a20f204") },
                    { new Guid("f77fa109-ef1a-4aaa-bcb0-6c06039ff967"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("3ca9704e-83f4-49ff-98a5-b6e69f5c70fe") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("53608fcb-21cb-42cb-9af3-8b3c67c27a3e"), 200.0, new Guid("3ca9704e-83f4-49ff-98a5-b6e69f5c70fe") },
                    { new Guid("6db75397-018d-40db-8ff7-c83aaf522186"), 200.0, new Guid("3ca9704e-83f4-49ff-98a5-b6e69f5c70fe") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "message", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("13581f5f-b35d-40ac-ac73-0cf636a1fc6e"), new Guid("8a6c9f10-6f4b-4394-a092-08015f6178c8"), 20, true, true, "Game Over", new Guid("9a868bf9-d918-4aee-aed0-7a1b7e70779e"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("35066c4e-3898-4ee1-8e04-196541fe59cb"), 0.0, new Guid("57d00112-de2f-4d52-b5f3-49058a20f204"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("92b4c771-10a4-4bbe-9777-e291d64b3214"), 0.0, new Guid("3ca9704e-83f4-49ff-98a5-b6e69f5c70fe"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("18fe4836-31ff-4b58-bb1d-0fa12bebf898"), 2.0, new DateTime(2024, 11, 26, 21, 3, 51, 419, DateTimeKind.Local).AddTicks(8342), "Withdrawal", new Guid("35066c4e-3898-4ee1-8e04-196541fe59cb") },
                    { new Guid("5c33dc53-6702-4f46-850a-937657ae9f3c"), 1.0, new DateTime(2024, 11, 26, 21, 3, 51, 419, DateTimeKind.Local).AddTicks(8332), "Withdrawal", new Guid("35066c4e-3898-4ee1-8e04-196541fe59cb") },
                    { new Guid("a873d883-bf12-402f-94ac-e9004127312a"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("92b4c771-10a4-4bbe-9777-e291d64b3214") },
                    { new Guid("b7fd6cec-d00f-411f-b515-416c12510f3b"), 2.0, new DateTime(2024, 11, 26, 21, 3, 51, 419, DateTimeKind.Local).AddTicks(8315), "Withdrawal", new Guid("92b4c771-10a4-4bbe-9777-e291d64b3214") }
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
                name: "IX_tblGame_UserId",
                table: "tblGame",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameState_dealerHandId",
                table: "tblGameState",
                column: "dealerHandId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameState_playerHandId",
                table: "tblGameState",
                column: "playerHandId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHand_tblGameId",
                table: "tblHand",
                column: "tblGameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblHand_tblUserId",
                table: "tblHand",
                column: "tblUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_WalletId",
                table: "tblTransaction",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_tblWallet_UserId",
                table: "tblWallet",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
