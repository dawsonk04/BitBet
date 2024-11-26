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
                    tblGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblHand_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblHand_tblGame_tblGameId",
                        column: x => x.tblGameId,
                        principalTable: "tblGame",
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
                columns: new[] { "Id", "BetAmount", "Result", "tblGameId" },
                values: new object[,]
                {
                    { new Guid("17babe6a-f8d9-4752-804d-f87b3c2a4712"), 20.0, -20.0, null },
                    { new Guid("67e812ed-46e5-47c5-b678-14c03b4b4abb"), 20.0, 40.0, null },
                    { new Guid("8d381b24-702c-4c41-ad01-184e159f5c14"), 20.0, 40.0, null },
                    { new Guid("b8d6ed97-1ff5-4ecd-bf24-00f21138c3fe"), 20.0, -20.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("322839d4-dee9-43ab-9cb1-71c2fd12888f"), new DateTime(2024, 11, 25, 18, 17, 13, 265, DateTimeKind.Local).AddTicks(5446), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("a364545d-0b82-4b12-8f68-4d49cfef25d3"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "rank", "suit" },
                values: new object[,]
                {
                    { new Guid("182787e4-11ed-4164-926d-129f32f5bfac"), new Guid("b8d6ed97-1ff5-4ecd-bf24-00f21138c3fe"), "Ten", "Diamonds" },
                    { new Guid("2fed1e4f-ac22-4584-9b4b-98c533de351a"), new Guid("67e812ed-46e5-47c5-b678-14c03b4b4abb"), "Ten", "Diamonds" },
                    { new Guid("3253dea8-713e-4a6b-86f7-e0269a0ce16e"), new Guid("67e812ed-46e5-47c5-b678-14c03b4b4abb"), "Ten", "Diamonds" },
                    { new Guid("4f271e57-81e7-4c88-a163-d421d0217036"), new Guid("b8d6ed97-1ff5-4ecd-bf24-00f21138c3fe"), "Ten", "Diamonds" },
                    { new Guid("9a58b4d9-da55-432f-9a51-b74c108edff3"), new Guid("8d381b24-702c-4c41-ad01-184e159f5c14"), "Ten", "Diamonds" },
                    { new Guid("9c581e5a-34cf-44b9-bd9e-c1f92f91cc71"), new Guid("8d381b24-702c-4c41-ad01-184e159f5c14"), "Ten", "Diamonds" },
                    { new Guid("a5bc1750-f4f4-4bfb-81f4-5909570789a0"), new Guid("17babe6a-f8d9-4752-804d-f87b3c2a4712"), "Ten", "Diamonds" },
                    { new Guid("b8677208-98dc-4d25-9836-c5d5938d9527"), new Guid("17babe6a-f8d9-4752-804d-f87b3c2a4712"), "Ten", "Diamonds" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("e4c490ad-17b3-4008-b68a-91c3ee5aafbb"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("a364545d-0b82-4b12-8f68-4d49cfef25d3") },
                    { new Guid("fee51f1c-75fa-40a5-905e-6cbf0de42188"), new DateTime(2024, 11, 25, 18, 17, 13, 265, DateTimeKind.Local).AddTicks(8858), "Test", "Login Exception", new Guid("322839d4-dee9-43ab-9cb1-71c2fd12888f") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("5c704396-1c6a-4ebe-b2ed-87ec12d36349"), 200.0, new Guid("a364545d-0b82-4b12-8f68-4d49cfef25d3") },
                    { new Guid("cf08ea01-ae74-4b5b-a235-d04812f3e00f"), 200.0, new Guid("a364545d-0b82-4b12-8f68-4d49cfef25d3") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "message", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("524ec0df-e41c-41ce-8755-980bd97a3f48"), new Guid("8d381b24-702c-4c41-ad01-184e159f5c14"), 20, true, true, "Game Over", new Guid("17babe6a-f8d9-4752-804d-f87b3c2a4712"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("37e94a2f-78a1-413b-870e-b751cf475bd5"), 0.0, new Guid("a364545d-0b82-4b12-8f68-4d49cfef25d3"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" },
                    { new Guid("ed86dac4-1562-47b8-bc31-7881a697bd43"), 0.0, new Guid("322839d4-dee9-43ab-9cb1-71c2fd12888f"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("52def000-b3aa-4cf7-b16d-e6c7fc6acf99"), 2.0, new DateTime(2024, 11, 25, 18, 17, 13, 265, DateTimeKind.Local).AddTicks(7178), "Withdrawal", new Guid("37e94a2f-78a1-413b-870e-b751cf475bd5") },
                    { new Guid("b5bbbc57-c100-4549-8e41-a12be8275528"), 2.0, new DateTime(2024, 11, 25, 18, 17, 13, 265, DateTimeKind.Local).AddTicks(7203), "Withdrawal", new Guid("ed86dac4-1562-47b8-bc31-7881a697bd43") },
                    { new Guid("bd36e1e1-b047-4a2b-8b81-8f0ba9d83c40"), 1.0, new DateTime(2024, 11, 25, 18, 17, 13, 265, DateTimeKind.Local).AddTicks(7193), "Withdrawal", new Guid("ed86dac4-1562-47b8-bc31-7881a697bd43") },
                    { new Guid("ec447bb6-d4bc-4fcd-9a39-4863eaa00825"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("37e94a2f-78a1-413b-870e-b751cf475bd5") }
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
