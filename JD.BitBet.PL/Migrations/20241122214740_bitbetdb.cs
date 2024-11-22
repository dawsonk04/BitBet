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
                    { new Guid("0c7a4aea-e477-4f3c-80e2-1d787175c9c4"), 20.0, -20.0, null },
                    { new Guid("799d8e01-b194-4123-b886-bc03eb7ca522"), 20.0, 40.0, null },
                    { new Guid("919847a5-cee2-45a1-9cd6-5ed7a2a1c8c2"), 20.0, 40.0, null },
                    { new Guid("d914188e-9d81-44e2-ad71-45f518e36476"), 20.0, -20.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("c747a3a3-3679-4ea1-a946-ae1ebcdca3da"), new DateTime(2024, 11, 22, 15, 47, 39, 847, DateTimeKind.Local).AddTicks(6396), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("d120265c-95ec-408a-b623-af1866aca64f"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "Rank", "Suit" },
                values: new object[,]
                {
                    { new Guid("5b0dbc8a-4a4f-4a98-8e51-e705d5f7662d"), new Guid("919847a5-cee2-45a1-9cd6-5ed7a2a1c8c2"), 10, "King" },
                    { new Guid("5f0b5ce3-e41d-4214-8a29-b4a83a78dffa"), new Guid("799d8e01-b194-4123-b886-bc03eb7ca522"), 10, "King" },
                    { new Guid("7d08f9bd-516b-4edf-a009-b50cc47f570e"), new Guid("d914188e-9d81-44e2-ad71-45f518e36476"), 10, "King" },
                    { new Guid("88f58e08-bbbb-4557-b02e-218ac7b370c8"), new Guid("0c7a4aea-e477-4f3c-80e2-1d787175c9c4"), 10, "King" },
                    { new Guid("b419fe01-415f-4464-8834-3bb57dff82d0"), new Guid("919847a5-cee2-45a1-9cd6-5ed7a2a1c8c2"), 10, "King" },
                    { new Guid("e00940be-8397-4d4c-9460-f7c9bfe9b327"), new Guid("d914188e-9d81-44e2-ad71-45f518e36476"), 10, "King" },
                    { new Guid("eda6a01e-b8c6-4c5e-8e20-fff36792d4d3"), new Guid("0c7a4aea-e477-4f3c-80e2-1d787175c9c4"), 10, "King" },
                    { new Guid("fbfb425b-7929-4c6f-b347-7a2dc109b012"), new Guid("799d8e01-b194-4123-b886-bc03eb7ca522"), 10, "King" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("49f1a20d-aafb-41a0-8eed-1ee436b91a38"), new DateTime(2024, 11, 22, 15, 47, 39, 847, DateTimeKind.Local).AddTicks(9355), "Test", "Login Exception", new Guid("c747a3a3-3679-4ea1-a946-ae1ebcdca3da") },
                    { new Guid("adf4c5af-e7c5-45a0-b1d0-8a32319e8409"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("d120265c-95ec-408a-b623-af1866aca64f") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("884a2de8-21ec-459a-bbf2-4f6323108117"), 200.0, new Guid("d120265c-95ec-408a-b623-af1866aca64f") },
                    { new Guid("d6e5732f-71bd-411d-a803-00138cd3bdbb"), 200.0, new Guid("d120265c-95ec-408a-b623-af1866aca64f") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("732969e4-24f6-48db-9001-7369e051e583"), new Guid("799d8e01-b194-4123-b886-bc03eb7ca522"), 20, true, true, new Guid("d914188e-9d81-44e2-ad71-45f518e36476"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("06eb2aa2-8451-491a-a996-4920e228d2b6"), 0.0, new Guid("c747a3a3-3679-4ea1-a946-ae1ebcdca3da"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("f033ad07-0656-4f15-81f4-94d7d8058360"), 0.0, new Guid("d120265c-95ec-408a-b623-af1866aca64f"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("2210b5d6-1916-42f0-af11-6d643a4768d9"), 2.0, new DateTime(2024, 11, 22, 15, 47, 39, 847, DateTimeKind.Local).AddTicks(7896), "Withdrawal", new Guid("f033ad07-0656-4f15-81f4-94d7d8058360") },
                    { new Guid("53a8f9f1-55f2-45de-ab44-56f6d1958221"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("f033ad07-0656-4f15-81f4-94d7d8058360") },
                    { new Guid("98ab89b8-4ef3-4af2-8566-6b0aaf87ad5a"), 2.0, new DateTime(2024, 11, 22, 15, 47, 39, 847, DateTimeKind.Local).AddTicks(7923), "Withdrawal", new Guid("06eb2aa2-8451-491a-a996-4920e228d2b6") },
                    { new Guid("da545e89-db66-4ec8-a983-5c85f5998b3c"), 1.0, new DateTime(2024, 11, 22, 15, 47, 39, 847, DateTimeKind.Local).AddTicks(7912), "Withdrawal", new Guid("06eb2aa2-8451-491a-a996-4920e228d2b6") }
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
