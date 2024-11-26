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
                    { new Guid("39bb55b2-7f6a-403d-88d9-dd046742bf1d"), 20.0, 40.0, null },
                    { new Guid("61d10f4e-a7dc-46a5-b795-45ad3a97392f"), 20.0, -20.0, null },
                    { new Guid("77ae2c0d-d600-469a-b6ef-8ec9d1ab0a9e"), 20.0, -20.0, null },
                    { new Guid("7e10e828-50e3-45c0-bc7b-4a2ac2ba696c"), 20.0, 40.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("2a1f4034-1b4e-47bb-b0d4-73a15dbb25fa"), new DateTime(2024, 11, 26, 17, 4, 4, 994, DateTimeKind.Local).AddTicks(9919), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("3a0eb3ff-e2f1-4345-8d62-a21eb3fa64e4"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "rank", "suit" },
                values: new object[,]
                {
                    { new Guid("4ec3d6d7-ace9-4089-9c1f-344f30263566"), new Guid("61d10f4e-a7dc-46a5-b795-45ad3a97392f"), "Ten", "Diamonds" },
                    { new Guid("711a6459-1649-4726-bc76-d86a30a77201"), new Guid("39bb55b2-7f6a-403d-88d9-dd046742bf1d"), "Ten", "Diamonds" },
                    { new Guid("8eab3034-1ad9-4dc3-89b7-b417cedea079"), new Guid("7e10e828-50e3-45c0-bc7b-4a2ac2ba696c"), "Ten", "Diamonds" },
                    { new Guid("908bac09-98d3-4220-b911-19440100f9de"), new Guid("39bb55b2-7f6a-403d-88d9-dd046742bf1d"), "Ten", "Diamonds" },
                    { new Guid("9811ebc9-537d-42a3-857d-4bfc72698882"), new Guid("77ae2c0d-d600-469a-b6ef-8ec9d1ab0a9e"), "Ten", "Diamonds" },
                    { new Guid("beddcc64-f549-42a7-833a-e0914c6aee90"), new Guid("7e10e828-50e3-45c0-bc7b-4a2ac2ba696c"), "Ten", "Diamonds" },
                    { new Guid("c1a93cda-3097-4595-805f-23dcd2c41450"), new Guid("61d10f4e-a7dc-46a5-b795-45ad3a97392f"), "Ten", "Diamonds" },
                    { new Guid("d3238a91-03f4-4105-ba59-e75561402d22"), new Guid("77ae2c0d-d600-469a-b6ef-8ec9d1ab0a9e"), "Ten", "Diamonds" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("54e1d2f8-c2a8-48a9-ade1-1ee591513d77"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("3a0eb3ff-e2f1-4345-8d62-a21eb3fa64e4") },
                    { new Guid("e611cd10-b3c7-4442-9fa4-3286d183a219"), new DateTime(2024, 11, 26, 17, 4, 4, 995, DateTimeKind.Local).AddTicks(4925), "Test", "Login Exception", new Guid("2a1f4034-1b4e-47bb-b0d4-73a15dbb25fa") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("91f73ce5-0bbb-4e20-8b7a-b74bfb461ad5"), 200.0, new Guid("3a0eb3ff-e2f1-4345-8d62-a21eb3fa64e4") },
                    { new Guid("a0d4af79-af67-4e0d-a035-c0f3e4c2be3f"), 200.0, new Guid("3a0eb3ff-e2f1-4345-8d62-a21eb3fa64e4") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "message", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("5cddf765-b46e-42c6-a9d5-0e03d84829cf"), new Guid("7e10e828-50e3-45c0-bc7b-4a2ac2ba696c"), 20, true, true, "Game Over", new Guid("77ae2c0d-d600-469a-b6ef-8ec9d1ab0a9e"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("1680f429-bb18-42a6-a6cf-b9d613cc7514"), 0.0, new Guid("2a1f4034-1b4e-47bb-b0d4-73a15dbb25fa"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("6221616d-eafa-45fe-8f2b-ee09fb1f38d3"), 0.0, new Guid("3a0eb3ff-e2f1-4345-8d62-a21eb3fa64e4"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("136f2658-53fe-4f45-b3ef-c1480b43e874"), 2.0, new DateTime(2024, 11, 26, 17, 4, 4, 995, DateTimeKind.Local).AddTicks(3190), "Withdrawal", new Guid("6221616d-eafa-45fe-8f2b-ee09fb1f38d3") },
                    { new Guid("7f4dd09f-41a6-4d44-b107-4ee19dc22feb"), 1.0, new DateTime(2024, 11, 26, 17, 4, 4, 995, DateTimeKind.Local).AddTicks(3214), "Withdrawal", new Guid("1680f429-bb18-42a6-a6cf-b9d613cc7514") },
                    { new Guid("f2460c4c-8129-43e6-a2b0-292f37249e5e"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("6221616d-eafa-45fe-8f2b-ee09fb1f38d3") },
                    { new Guid("f575dae7-d8ce-489a-9278-2b68d71669b9"), 2.0, new DateTime(2024, 11, 26, 17, 4, 4, 995, DateTimeKind.Local).AddTicks(3224), "Withdrawal", new Guid("1680f429-bb18-42a6-a6cf-b9d613cc7514") }
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
