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
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BetAmount = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false),
                    Result = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblHand_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblHand_GameId",
                        column: x => x.GameId,
                        principalTable: "tblGame",
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

            migrationBuilder.CreateTable(
                name: "tblCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    Suit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
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
                    isGameOver = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk__tblGameState_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGameState_DealerHandId",
                        column: x => x.dealerHandId,
                        principalTable: "tblHand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGameState_PlayerHand",
                        column: x => x.playerHandId,
                        principalTable: "tblHand",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("73958790-a19a-48f6-9ff4-5b2c6b34115a"), new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(2287), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("be50dafe-171b-4c91-ac0a-194403de1c77"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("1172c75a-d9dd-4515-8ac1-9659efaa8b97"), new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(6716), "Test", "Login Exception", new Guid("73958790-a19a-48f6-9ff4-5b2c6b34115a") },
                    { new Guid("d4e1175b-e2db-48c5-9325-1ddb0060dc3b"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("be50dafe-171b-4c91-ac0a-194403de1c77") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("3599c810-222f-44f1-88a4-8a5717f039fc"), 200.0, new Guid("be50dafe-171b-4c91-ac0a-194403de1c77") },
                    { new Guid("6b3ee27d-9fc0-48ed-a0fd-ec1b72ee5c03"), 200.0, new Guid("be50dafe-171b-4c91-ac0a-194403de1c77") }
                });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("f106a3d6-7b57-4c4a-b5ae-9d344a31475d"), 0.0, new Guid("73958790-a19a-48f6-9ff4-5b2c6b34115a"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("fcee1dc0-13b6-4ce3-bd3f-01149118296d"), 0.0, new Guid("be50dafe-171b-4c91-ac0a-194403de1c77"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "GameId", "Result" },
                values: new object[,]
                {
                    { new Guid("4cb54be3-1564-48bd-8b56-861afb1e3cd4"), 20.0, new Guid("3599c810-222f-44f1-88a4-8a5717f039fc"), 40.0 },
                    { new Guid("5f2ea554-16fc-4aad-8cad-45ce2d06fa25"), 20.0, new Guid("3599c810-222f-44f1-88a4-8a5717f039fc"), 40.0 },
                    { new Guid("e5de3280-da6f-4c37-b681-cc10f43e02e5"), 20.0, new Guid("6b3ee27d-9fc0-48ed-a0fd-ec1b72ee5c03"), -20.0 },
                    { new Guid("f29f1db4-b7df-4c8d-b05d-5bf4617aa984"), 20.0, new Guid("6b3ee27d-9fc0-48ed-a0fd-ec1b72ee5c03"), -20.0 }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("058a62a0-f457-416d-9b12-35b4124f474c"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("fcee1dc0-13b6-4ce3-bd3f-01149118296d") },
                    { new Guid("496730a7-fc72-41c9-aa0a-6183e8558884"), 1.0, new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(4240), "Withdrawal", new Guid("f106a3d6-7b57-4c4a-b5ae-9d344a31475d") },
                    { new Guid("b78d1052-b687-45de-a40e-741694a3488e"), 2.0, new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(4251), "Withdrawal", new Guid("f106a3d6-7b57-4c4a-b5ae-9d344a31475d") },
                    { new Guid("f2a524c6-3449-46ce-b6b5-7b9666e5f6c9"), 2.0, new DateTime(2024, 11, 22, 14, 13, 15, 142, DateTimeKind.Local).AddTicks(4204), "Withdrawal", new Guid("fcee1dc0-13b6-4ce3-bd3f-01149118296d") }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "Rank", "Suit" },
                values: new object[,]
                {
                    { new Guid("08eb2ccd-d7f5-4c05-9b74-310806ebcc71"), new Guid("4cb54be3-1564-48bd-8b56-861afb1e3cd4"), 10, "King" },
                    { new Guid("3eef7fc9-01c0-4d7c-9079-98524bc28b12"), new Guid("e5de3280-da6f-4c37-b681-cc10f43e02e5"), 10, "King" },
                    { new Guid("4ece2805-0808-4279-904f-6486188fcb95"), new Guid("5f2ea554-16fc-4aad-8cad-45ce2d06fa25"), 10, "King" },
                    { new Guid("73d97004-ab8b-46c9-83b2-1082f49b0ec7"), new Guid("4cb54be3-1564-48bd-8b56-861afb1e3cd4"), 10, "King" },
                    { new Guid("cab833fe-a603-4db7-970a-887b30c4a8a1"), new Guid("f29f1db4-b7df-4c8d-b05d-5bf4617aa984"), 10, "King" },
                    { new Guid("cdd9b8ce-2f94-4e8f-b840-c488ec9af4b0"), new Guid("e5de3280-da6f-4c37-b681-cc10f43e02e5"), 10, "King" },
                    { new Guid("f7167733-62f9-4f22-ad4a-189ea65e6c5b"), new Guid("5f2ea554-16fc-4aad-8cad-45ce2d06fa25"), 10, "King" },
                    { new Guid("ffb2760d-a0f7-4afe-95a0-ac99a35a77f7"), new Guid("f29f1db4-b7df-4c8d-b05d-5bf4617aa984"), 10, "King" }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("95d78504-43ac-4f05-9e8b-96c83ba44cb8"), new Guid("4cb54be3-1564-48bd-8b56-861afb1e3cd4"), 20, true, true, new Guid("e5de3280-da6f-4c37-b681-cc10f43e02e5"), 20 });

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
                name: "IX_tblHand_GameId",
                table: "tblHand",
                column: "GameId");

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
