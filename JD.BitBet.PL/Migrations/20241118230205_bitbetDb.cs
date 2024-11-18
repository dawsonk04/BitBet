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

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("8cb82cd3-b09f-4680-9580-0224284b0df8"), new DateTime(2024, 11, 18, 17, 2, 5, 227, DateTimeKind.Local).AddTicks(3567), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("cf768201-1dad-4ddd-8607-4e45c3e65d36"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("11ed4d3a-d554-4920-9191-a0d464313435"), new DateTime(2024, 11, 18, 17, 2, 5, 227, DateTimeKind.Local).AddTicks(7533), "Test", "Login Exception", new Guid("8cb82cd3-b09f-4680-9580-0224284b0df8") },
                    { new Guid("2e0ef565-5b9f-4500-b868-f1a95e4f40d1"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("cf768201-1dad-4ddd-8607-4e45c3e65d36") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("3bb9209d-5f39-41ed-ba67-9dc14305126b"), 200.0, new Guid("cf768201-1dad-4ddd-8607-4e45c3e65d36") },
                    { new Guid("4625e170-935c-477d-aeed-b3027aaa7174"), 200.0, new Guid("cf768201-1dad-4ddd-8607-4e45c3e65d36") }
                });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("c73a13b2-6fce-4307-8bd6-cb400a51b7f3"), 0.0, new Guid("cf768201-1dad-4ddd-8607-4e45c3e65d36"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" },
                    { new Guid("f861c304-b854-4362-af4a-9e568766cff5"), 0.0, new Guid("8cb82cd3-b09f-4680-9580-0224284b0df8"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "GameId", "Result" },
                values: new object[,]
                {
                    { new Guid("14d520a7-a4d5-4ba8-9096-d5d6a132bb06"), 20.0, new Guid("3bb9209d-5f39-41ed-ba67-9dc14305126b"), -20.0 },
                    { new Guid("59645000-6cc0-436e-80e5-b69a08b599e9"), 20.0, new Guid("4625e170-935c-477d-aeed-b3027aaa7174"), 40.0 }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("18e00d02-fc96-4130-95d1-3cc129853e44"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("c73a13b2-6fce-4307-8bd6-cb400a51b7f3") },
                    { new Guid("2ff6bd04-ef88-4192-87ac-960b2c84c72f"), 2.0, new DateTime(2024, 11, 18, 17, 2, 5, 227, DateTimeKind.Local).AddTicks(5174), "Withdrawal", new Guid("c73a13b2-6fce-4307-8bd6-cb400a51b7f3") },
                    { new Guid("8187ce63-debe-47e0-bff6-f044aef4f57d"), 2.0, new DateTime(2024, 11, 18, 17, 2, 5, 227, DateTimeKind.Local).AddTicks(5213), "Withdrawal", new Guid("f861c304-b854-4362-af4a-9e568766cff5") },
                    { new Guid("8199a516-ed48-400f-aebe-90f9159fe126"), 1.0, new DateTime(2024, 11, 18, 17, 2, 5, 227, DateTimeKind.Local).AddTicks(5202), "Withdrawal", new Guid("f861c304-b854-4362-af4a-9e568766cff5") }
                });

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
                name: "tblErrorLog");

            migrationBuilder.DropTable(
                name: "tblHand");

            migrationBuilder.DropTable(
                name: "tblTransaction");

            migrationBuilder.DropTable(
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblWallet");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
