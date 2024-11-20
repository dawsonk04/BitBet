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
                    Value = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
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
                    { new Guid("30500618-4314-4e7a-813d-b9fe560bce26"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("fe9c7925-52f0-476d-ac11-03ce6e0368aa"), new DateTime(2024, 11, 20, 17, 14, 36, 729, DateTimeKind.Local).AddTicks(5720), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("2e47f3ce-b2e1-4eb7-a04a-f6fab1832c75"), new DateTime(2024, 11, 20, 17, 14, 36, 729, DateTimeKind.Local).AddTicks(9150), "Test", "Login Exception", new Guid("fe9c7925-52f0-476d-ac11-03ce6e0368aa") },
                    { new Guid("a85c65c2-85bb-4745-8bd2-7fd70d38c6f9"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("30500618-4314-4e7a-813d-b9fe560bce26") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("336f71ec-964e-4a6e-a431-a5f3dfa7a9ad"), 200.0, new Guid("30500618-4314-4e7a-813d-b9fe560bce26") },
                    { new Guid("8043372f-ba35-474e-8a28-5b30222b95cc"), 200.0, new Guid("30500618-4314-4e7a-813d-b9fe560bce26") }
                });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("a092792e-32f4-4823-88b1-b347d94722a7"), 0.0, new Guid("fe9c7925-52f0-476d-ac11-03ce6e0368aa"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("b7b98366-8a7a-4b99-9365-738f52a023b2"), 0.0, new Guid("30500618-4314-4e7a-813d-b9fe560bce26"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "GameId", "Result" },
                values: new object[,]
                {
                    { new Guid("10a7b372-1570-49ea-94e2-44705c69aea5"), 20.0, new Guid("8043372f-ba35-474e-8a28-5b30222b95cc"), -20.0 },
                    { new Guid("7c1b0a94-957d-410c-82db-21502bcf2b19"), 20.0, new Guid("336f71ec-964e-4a6e-a431-a5f3dfa7a9ad"), 40.0 },
                    { new Guid("805a6d58-4190-4024-ac69-0d15d8bffa93"), 20.0, new Guid("336f71ec-964e-4a6e-a431-a5f3dfa7a9ad"), 40.0 },
                    { new Guid("d2b6d195-9482-4f49-a5c8-7e920d85b16d"), 20.0, new Guid("8043372f-ba35-474e-8a28-5b30222b95cc"), -20.0 }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("7d0a014a-b30e-45f1-92f6-aeba900a7f02"), 1.0, new DateTime(2024, 11, 20, 17, 14, 36, 729, DateTimeKind.Local).AddTicks(7223), "Withdrawal", new Guid("a092792e-32f4-4823-88b1-b347d94722a7") },
                    { new Guid("8381b836-58d3-421b-b92c-49791bab5873"), 2.0, new DateTime(2024, 11, 20, 17, 14, 36, 729, DateTimeKind.Local).AddTicks(7233), "Withdrawal", new Guid("a092792e-32f4-4823-88b1-b347d94722a7") },
                    { new Guid("a88d636d-2d10-4497-954b-718038a71802"), 2.0, new DateTime(2024, 11, 20, 17, 14, 36, 729, DateTimeKind.Local).AddTicks(7208), "Withdrawal", new Guid("b7b98366-8a7a-4b99-9365-738f52a023b2") },
                    { new Guid("c853337c-4f10-4e7a-9b64-6539a521c288"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("b7b98366-8a7a-4b99-9365-738f52a023b2") }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "Suit", "Value" },
                values: new object[,]
                {
                    { new Guid("0a260ae3-b8bd-42d1-a6f6-f027c1666811"), new Guid("10a7b372-1570-49ea-94e2-44705c69aea5"), "King", 1 },
                    { new Guid("16e3e07d-3d3b-42c0-8efc-53026733eda9"), new Guid("d2b6d195-9482-4f49-a5c8-7e920d85b16d"), "King", 1 },
                    { new Guid("2dfc3967-9625-453e-9ed1-2608a8bbaaa8"), new Guid("7c1b0a94-957d-410c-82db-21502bcf2b19"), "King", 1 },
                    { new Guid("9fff61a0-df78-4ece-85ac-802f3740ba1f"), new Guid("805a6d58-4190-4024-ac69-0d15d8bffa93"), "King", 10 },
                    { new Guid("ac038e34-1ba7-4e08-978d-f2fcca925497"), new Guid("7c1b0a94-957d-410c-82db-21502bcf2b19"), "King", 1 },
                    { new Guid("d3ca5be3-2fcd-461e-80d9-1bb6ce7b7c74"), new Guid("d2b6d195-9482-4f49-a5c8-7e920d85b16d"), "King", 1 },
                    { new Guid("db3d0a34-efbe-4c5b-98a9-9d274bf4e8ff"), new Guid("10a7b372-1570-49ea-94e2-44705c69aea5"), "King", 1 },
                    { new Guid("e4b32f9a-5c97-4a4c-8e74-5809d95daae5"), new Guid("805a6d58-4190-4024-ac69-0d15d8bffa93"), "King", 1 }
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
