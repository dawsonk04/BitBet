using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JD.BitBet.PL.Migrations
{
    /// <inheritdoc />
    public partial class BitBetDb : Migration
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
                    { new Guid("207d65b5-5405-486c-a51c-bb9ba1676976"), new DateTime(2024, 11, 3, 11, 32, 27, 3, DateTimeKind.Local).AddTicks(5049), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("21c5970f-31aa-4137-9468-9abc00d6fb5e"), new DateTime(2024, 11, 3, 11, 32, 27, 3, DateTimeKind.Local).AddTicks(4977), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("15c7f635-390b-480e-badf-a0b530229fac"), new DateTime(2024, 11, 3, 11, 32, 27, 3, DateTimeKind.Local).AddTicks(8552), "Test", "Login Exception", new Guid("207d65b5-5405-486c-a51c-bb9ba1676976") },
                    { new Guid("5d7095a8-10e8-4cb2-a193-67d644cf894a"), new DateTime(2024, 11, 3, 11, 32, 27, 3, DateTimeKind.Local).AddTicks(8534), "Test", "Login Exception", new Guid("21c5970f-31aa-4137-9468-9abc00d6fb5e") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("a6bd0303-7674-4c12-a848-f1a0ba44a849"), 200.0, new Guid("21c5970f-31aa-4137-9468-9abc00d6fb5e") },
                    { new Guid("ba62583f-a903-40e3-aa29-3328b311d056"), 200.0, new Guid("21c5970f-31aa-4137-9468-9abc00d6fb5e") }
                });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("38635c5b-d8e7-4e72-8294-525afc799689"), 0.0, new Guid("21c5970f-31aa-4137-9468-9abc00d6fb5e"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" },
                    { new Guid("7ea0caea-d46d-41bb-a39a-bd4580761c68"), 0.0, new Guid("207d65b5-5405-486c-a51c-bb9ba1676976"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "GameId", "Result" },
                values: new object[,]
                {
                    { new Guid("aac2c75b-c63a-4388-878c-0d167feaefb3"), 20.0, new Guid("a6bd0303-7674-4c12-a848-f1a0ba44a849"), 40.0 },
                    { new Guid("feba23eb-b62a-4c31-a875-edc755797f12"), 20.0, new Guid("ba62583f-a903-40e3-aa29-3328b311d056"), -20.0 }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("44094019-46ec-42f8-9398-0890d5f75efa"), 2.0, new DateTime(2024, 11, 3, 11, 32, 27, 3, DateTimeKind.Local).AddTicks(6593), "Withdrawal", new Guid("7ea0caea-d46d-41bb-a39a-bd4580761c68") },
                    { new Guid("692a266c-b3a6-43f3-9982-b1cf9d53ff91"), 1.0, new DateTime(2024, 11, 3, 11, 32, 27, 3, DateTimeKind.Local).AddTicks(6583), "Withdrawal", new Guid("7ea0caea-d46d-41bb-a39a-bd4580761c68") },
                    { new Guid("a5d235d4-5937-44f0-ae1b-59e6f8ee54ec"), 2.0, new DateTime(2024, 11, 3, 11, 32, 27, 3, DateTimeKind.Local).AddTicks(6572), "Withdrawal", new Guid("38635c5b-d8e7-4e72-8294-525afc799689") },
                    { new Guid("f587eedb-497e-4ee3-8ead-e7025f3eaa4d"), 1.0, new DateTime(2024, 11, 3, 11, 32, 27, 3, DateTimeKind.Local).AddTicks(6555), "Withdrawal", new Guid("38635c5b-d8e7-4e72-8294-525afc799689") }
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
