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
                    { new Guid("282d1f13-1f8b-4478-b22e-e2e2f2beb68b"), 20.0, -20.0, null },
                    { new Guid("5185bd44-4b26-4ef6-bb87-6b8603dc44d2"), 20.0, 40.0, null },
                    { new Guid("719d5b36-caad-435f-92c0-dfdfc9beb8cf"), 20.0, -20.0, null },
                    { new Guid("8747a77c-7d1c-4a76-a488-435d2bdf159f"), 20.0, 40.0, null }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("6bc48df7-9306-49cb-980f-8ab44078d991"), new DateTime(2024, 11, 22, 15, 41, 17, 706, DateTimeKind.Local).AddTicks(8948), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("84787ee0-e12a-4192-a3c8-c249ddb5fd68"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "Rank", "Suit" },
                values: new object[,]
                {
                    { new Guid("03e9232a-6201-425e-8b2c-3c416f4a7e4f"), new Guid("5185bd44-4b26-4ef6-bb87-6b8603dc44d2"), 10, "King" },
                    { new Guid("29019589-08aa-447d-997f-2873a6620071"), new Guid("282d1f13-1f8b-4478-b22e-e2e2f2beb68b"), 10, "King" },
                    { new Guid("5c52498d-5126-459b-a50f-e7f0f6be9d61"), new Guid("719d5b36-caad-435f-92c0-dfdfc9beb8cf"), 10, "King" },
                    { new Guid("75fdb517-8b1c-4010-8fd1-72588f726c3d"), new Guid("719d5b36-caad-435f-92c0-dfdfc9beb8cf"), 10, "King" },
                    { new Guid("7cb4a705-81aa-4744-9a96-4fbb1d169613"), new Guid("282d1f13-1f8b-4478-b22e-e2e2f2beb68b"), 10, "King" },
                    { new Guid("962b1733-0faf-473f-99ba-1436d74217b7"), new Guid("8747a77c-7d1c-4a76-a488-435d2bdf159f"), 10, "King" },
                    { new Guid("a86f1ed9-1e74-4002-804d-478e1c474248"), new Guid("8747a77c-7d1c-4a76-a488-435d2bdf159f"), 10, "King" },
                    { new Guid("ecb6f13c-1bdd-4b28-a25a-a38b94ce2775"), new Guid("5185bd44-4b26-4ef6-bb87-6b8603dc44d2"), 10, "King" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("5e63326e-7dd4-4cf6-9776-33016b7ac2ac"), new DateTime(2024, 11, 22, 15, 41, 17, 707, DateTimeKind.Local).AddTicks(2521), "Test", "Login Exception", new Guid("6bc48df7-9306-49cb-980f-8ab44078d991") },
                    { new Guid("fc7ac670-6c91-47d0-95ca-1c94bf9d601b"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("84787ee0-e12a-4192-a3c8-c249ddb5fd68") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("0f035df1-e979-418d-945d-3ca7b74f8208"), 200.0, new Guid("84787ee0-e12a-4192-a3c8-c249ddb5fd68") },
                    { new Guid("ac73baa9-f5ae-462e-b71b-0df6c099344f"), 200.0, new Guid("84787ee0-e12a-4192-a3c8-c249ddb5fd68") }
                });

            migrationBuilder.InsertData(
                table: "tblGameState",
                columns: new[] { "Id", "dealerHandId", "dealerHandVal", "isGameOver", "isPlayerTurn", "playerHandId", "playerHandVal" },
                values: new object[] { new Guid("ef3e83e9-7819-4246-a302-c4c3a6dc28cf"), new Guid("8747a77c-7d1c-4a76-a488-435d2bdf159f"), 20, true, true, new Guid("282d1f13-1f8b-4478-b22e-e2e2f2beb68b"), 20 });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("902f5cbf-00fe-49ca-90aa-bc143de88f7b"), 0.0, new Guid("6bc48df7-9306-49cb-980f-8ab44078d991"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("d728afbd-d963-4b2c-b315-2569088f6026"), 0.0, new Guid("84787ee0-e12a-4192-a3c8-c249ddb5fd68"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("5287f43a-a857-47f3-ad92-805a3e94cc1e"), 2.0, new DateTime(2024, 11, 22, 15, 41, 17, 707, DateTimeKind.Local).AddTicks(773), "Withdrawal", new Guid("d728afbd-d963-4b2c-b315-2569088f6026") },
                    { new Guid("5c48cf79-ed9d-4a42-ae70-b064c019332f"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("d728afbd-d963-4b2c-b315-2569088f6026") },
                    { new Guid("72444c44-0a32-4d38-99f8-2682fc68d415"), 2.0, new DateTime(2024, 11, 22, 15, 41, 17, 707, DateTimeKind.Local).AddTicks(801), "Withdrawal", new Guid("902f5cbf-00fe-49ca-90aa-bc143de88f7b") },
                    { new Guid("e39301df-56d1-4827-b1e7-9a7c84b5eb54"), 1.0, new DateTime(2024, 11, 22, 15, 41, 17, 707, DateTimeKind.Local).AddTicks(790), "Withdrawal", new Guid("902f5cbf-00fe-49ca-90aa-bc143de88f7b") }
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
