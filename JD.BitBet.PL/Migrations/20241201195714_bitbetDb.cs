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
                name: "tblGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameResult = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false)
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
                name: "tblGametblUser",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGametblUser", x => new { x.GamesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_tblGametblUser_tblGame_GamesId",
                        column: x => x.GamesId,
                        principalTable: "tblGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblGametblUser_tblUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "GameResult" },
                values: new object[,]
                {
                    { new Guid("42523dbb-7f3b-43b9-a166-0c0f1608f695"), 200.0 },
                    { new Guid("43e9efc2-0ae4-4c7d-8491-352f1baf275f"), 200.0 }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "Result", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("37eb5ccd-e8fa-4b79-832b-6d97152a0238"), 20.0, 40.0, null },
                    { new Guid("6f1a41d3-50db-40e5-b40c-349c5ba1c67e"), 20.0, 40.0, null },
                    { new Guid("7b1b1bdf-08c8-41b2-af81-bd17f10e35c1"), 20.0, -20.0, null },
                    { new Guid("e401f0aa-5810-45d2-b6f5-cd8e82e9bb75"), 20.0, -20.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("253d7856-c86c-44fa-8910-541799ba4460"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("394285e3-000d-4aea-b7f0-d044090f593c"), new DateTime(2024, 12, 1, 13, 57, 13, 747, DateTimeKind.Local).AddTicks(8840), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "rank", "suit" },
                values: new object[,]
                {
                    { new Guid("7c428167-4d85-4766-9ee3-3801a7dfd29d"), new Guid("7b1b1bdf-08c8-41b2-af81-bd17f10e35c1"), "Ten", "Diamonds" },
                    { new Guid("851e7c5f-acd3-46c2-aa4e-f16a8abff0f4"), new Guid("7b1b1bdf-08c8-41b2-af81-bd17f10e35c1"), "Ten", "Diamonds" },
                    { new Guid("8cbd91ac-0288-41bd-bf5f-ccf3c574ec64"), new Guid("37eb5ccd-e8fa-4b79-832b-6d97152a0238"), "Ten", "Diamonds" },
                    { new Guid("a3207202-9deb-4d7a-816d-faffe71448fa"), new Guid("6f1a41d3-50db-40e5-b40c-349c5ba1c67e"), "Ten", "Diamonds" },
                    { new Guid("c279034b-2146-4eea-82b2-a12877e1cc88"), new Guid("37eb5ccd-e8fa-4b79-832b-6d97152a0238"), "Ten", "Diamonds" },
                    { new Guid("cacb2a0d-b7eb-4255-9ae6-3dcb88874b6b"), new Guid("6f1a41d3-50db-40e5-b40c-349c5ba1c67e"), "Ten", "Diamonds" },
                    { new Guid("d1bb5b7d-e415-403f-bc90-d6b0aa184155"), new Guid("e401f0aa-5810-45d2-b6f5-cd8e82e9bb75"), "Ten", "Diamonds" },
                    { new Guid("d47431a6-4680-4479-8641-9810aab7a2e0"), new Guid("e401f0aa-5810-45d2-b6f5-cd8e82e9bb75"), "Ten", "Diamonds" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d49535e-ed75-424c-ac99-63408d47a0ea"), new DateTime(2024, 12, 1, 13, 57, 13, 748, DateTimeKind.Local).AddTicks(4824), "Test", "Login Exception", new Guid("394285e3-000d-4aea-b7f0-d044090f593c") },
                    { new Guid("5d7aa5c6-17d7-4084-9a53-2a3606407236"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("253d7856-c86c-44fa-8910-541799ba4460") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "GameId", "UserId", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "message", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("a211c8ae-73de-4076-b9d0-f8825e08bec4"), new Guid("42523dbb-7f3b-43b9-a166-0c0f1608f695"), new Guid("253d7856-c86c-44fa-8910-541799ba4460"), new Guid("6f1a41d3-50db-40e5-b40c-349c5ba1c67e"), 20, true, true, "Game Over", new Guid("7b1b1bdf-08c8-41b2-af81-bd17f10e35c1"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("89e2708f-4732-412f-ab9c-7d0ce1df7e4a"), 0.0, new Guid("394285e3-000d-4aea-b7f0-d044090f593c"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("9a89ba31-de00-425b-a405-e63d63d76541"), 0.0, new Guid("253d7856-c86c-44fa-8910-541799ba4460"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("43742bb0-d097-4bd1-b4dd-33909ab85a07"), 2.0, new DateTime(2024, 12, 1, 13, 57, 13, 748, DateTimeKind.Local).AddTicks(3180), "Withdrawal", new Guid("9a89ba31-de00-425b-a405-e63d63d76541") },
                    { new Guid("a24f36af-b4bf-48e6-8a26-b8fc2d62f3aa"), 2.0, new DateTime(2024, 12, 1, 13, 57, 13, 748, DateTimeKind.Local).AddTicks(3226), "Withdrawal", new Guid("89e2708f-4732-412f-ab9c-7d0ce1df7e4a") },
                    { new Guid("ac95b2bb-6454-4490-9d9f-ca1b23a5e6c4"), 1.0, new DateTime(2024, 12, 1, 13, 57, 13, 748, DateTimeKind.Local).AddTicks(3215), "Withdrawal", new Guid("89e2708f-4732-412f-ab9c-7d0ce1df7e4a") },
                    { new Guid("daaff4bc-ae01-41d5-8cee-a2c19fea0963"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("9a89ba31-de00-425b-a405-e63d63d76541") }
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
                name: "IX_tblGametblUser_UsersId",
                table: "tblGametblUser",
                column: "UsersId");

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
                name: "tblGametblUser");

            migrationBuilder.DropTable(
                name: "tblTransaction");

            migrationBuilder.DropTable(
                name: "tblHand");

            migrationBuilder.DropTable(
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblWallet");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
