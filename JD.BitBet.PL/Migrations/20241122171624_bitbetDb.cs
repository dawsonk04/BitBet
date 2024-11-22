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

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("5564f879-8288-4823-97a1-37fe5b39d9f1"), new DateTime(2024, 11, 22, 11, 16, 23, 881, DateTimeKind.Local).AddTicks(322), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("aa1b2f7e-666c-43bd-80ac-a197822a5f94"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("4740a33e-c01e-4a6f-bf19-d60a2b44a343"), new DateTime(2024, 11, 22, 11, 16, 23, 881, DateTimeKind.Local).AddTicks(9004), "Test", "Login Exception", new Guid("5564f879-8288-4823-97a1-37fe5b39d9f1") },
                    { new Guid("865c54a1-6aa0-47c6-afcc-6dc6571ce17c"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("aa1b2f7e-666c-43bd-80ac-a197822a5f94") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("84d42ebb-dd5b-490c-b48b-d60355dda0af"), 200.0, new Guid("aa1b2f7e-666c-43bd-80ac-a197822a5f94") },
                    { new Guid("f4099c07-c10b-4b2c-a9e1-c7b93aefb3a7"), 200.0, new Guid("aa1b2f7e-666c-43bd-80ac-a197822a5f94") }
                });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("e9a48182-efe2-4800-9071-fcf548e46aee"), 0.0, new Guid("aa1b2f7e-666c-43bd-80ac-a197822a5f94"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" },
                    { new Guid("ec04b51c-ea62-4295-a3fc-cf5744e39456"), 0.0, new Guid("5564f879-8288-4823-97a1-37fe5b39d9f1"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "GameId", "Result" },
                values: new object[,]
                {
                    { new Guid("53fe86d7-9294-4ba7-ab26-74be36a4a95e"), 20.0, new Guid("84d42ebb-dd5b-490c-b48b-d60355dda0af"), 40.0 },
                    { new Guid("7135bf50-642d-4367-a863-0bc7e324484b"), 20.0, new Guid("f4099c07-c10b-4b2c-a9e1-c7b93aefb3a7"), -20.0 },
                    { new Guid("9adb68ce-8bd7-469c-9e09-af7e1f46fe6b"), 20.0, new Guid("f4099c07-c10b-4b2c-a9e1-c7b93aefb3a7"), -20.0 },
                    { new Guid("dc65e7f0-b4ea-4e38-a487-c73fb842678f"), 20.0, new Guid("84d42ebb-dd5b-490c-b48b-d60355dda0af"), 40.0 }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("121759be-acc9-4274-a651-47a5e0d8be27"), 1.0, new DateTime(2024, 11, 22, 11, 16, 23, 881, DateTimeKind.Local).AddTicks(6502), "Withdrawal", new Guid("ec04b51c-ea62-4295-a3fc-cf5744e39456") },
                    { new Guid("827f51fd-b0c5-4862-bfff-b6c9bc905216"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("e9a48182-efe2-4800-9071-fcf548e46aee") },
                    { new Guid("9bcd1e4b-d648-46a5-8ecd-7d296daa5a69"), 2.0, new DateTime(2024, 11, 22, 11, 16, 23, 881, DateTimeKind.Local).AddTicks(6469), "Withdrawal", new Guid("e9a48182-efe2-4800-9071-fcf548e46aee") },
                    { new Guid("e88ed73c-bf87-4b2f-8562-3d4edfd1bb66"), 2.0, new DateTime(2024, 11, 22, 11, 16, 23, 881, DateTimeKind.Local).AddTicks(6512), "Withdrawal", new Guid("ec04b51c-ea62-4295-a3fc-cf5744e39456") }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "Rank", "Suit" },
                values: new object[,]
                {
                    { new Guid("0fd1c024-849a-4653-b466-6700ac38b562"), new Guid("53fe86d7-9294-4ba7-ab26-74be36a4a95e"), 10, "King" },
                    { new Guid("276604c5-f9d7-4165-b83e-99718c919d26"), new Guid("9adb68ce-8bd7-469c-9e09-af7e1f46fe6b"), 1, "King" },
                    { new Guid("2babb764-8455-4b54-8dab-7a2ed8746b31"), new Guid("9adb68ce-8bd7-469c-9e09-af7e1f46fe6b"), 1, "King" },
                    { new Guid("65641182-c7a8-4e84-af58-b1684634f24a"), new Guid("dc65e7f0-b4ea-4e38-a487-c73fb842678f"), 1, "King" },
                    { new Guid("8f411241-4bfd-48db-ac84-05ec5cd2e7ec"), new Guid("53fe86d7-9294-4ba7-ab26-74be36a4a95e"), 1, "King" },
                    { new Guid("bc5c8feb-4f53-4d2c-bd28-b48355dd46e7"), new Guid("7135bf50-642d-4367-a863-0bc7e324484b"), 1, "King" },
                    { new Guid("c44036c5-8200-45e4-9997-5886fd457ae7"), new Guid("7135bf50-642d-4367-a863-0bc7e324484b"), 1, "King" },
                    { new Guid("f83dae3e-795c-4ee4-8fb9-75905e59f6fe"), new Guid("dc65e7f0-b4ea-4e38-a487-c73fb842678f"), 1, "King" }
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
