using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JD.BitBet.PL.Migrations
{
    /// <inheritdoc />
    public partial class BitBetdb : Migration
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
                        name: "FK_tblHand_UserId",
                        column: x => x.GameId,
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
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "CreateDate", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("043502dc-a4ef-4aca-ac7e-d94cf40389a9"), new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(2412), "jstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f"), new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(2304), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("240e5ea8-ecec-4560-8b9b-668e228ae1c0"), new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(7116), "Test", "Login Exception", new Guid("043502dc-a4ef-4aca-ac7e-d94cf40389a9") },
                    { new Guid("b1ac1fe1-1638-4f8c-aae1-58d1376abed4"), new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(7085), "Test", "Login Exception", new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("2645dccf-8374-42dd-a9c7-8e8210983395"), 200.0, new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f") },
                    { new Guid("36de6af2-fdb1-4513-baa9-aaf35e4cca62"), 200.0, new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f") }
                });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("85c1dc16-16b1-4808-9cb8-d8e66afc98a3"), 0.0, new Guid("043502dc-a4ef-4aca-ac7e-d94cf40389a9"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("a76f6f4c-64f7-492e-9be6-f6facbac5d1a"), 0.0, new Guid("b407ab52-0312-4aa3-9e80-07741a2d603f"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "GameId", "Result" },
                values: new object[,]
                {
                    { new Guid("ab52786c-ee16-4f56-9526-e27ba9e64fda"), 20.0, new Guid("2645dccf-8374-42dd-a9c7-8e8210983395"), -20.0 },
                    { new Guid("f924a577-b305-4a5b-abb0-f5fdf4ce3b9e"), 20.0, new Guid("36de6af2-fdb1-4513-baa9-aaf35e4cca62"), 40.0 }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("4281543e-57fb-4193-a87f-bafd7c6fe6d8"), 2.0, new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(4480), "Withdrawal", new Guid("a76f6f4c-64f7-492e-9be6-f6facbac5d1a") },
                    { new Guid("4e653c8a-0c31-434d-add2-f4e69d19ebda"), 1.0, new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(4463), "Withdrawal", new Guid("a76f6f4c-64f7-492e-9be6-f6facbac5d1a") },
                    { new Guid("815ef812-c47b-405d-83a1-1cbd119fd9c1"), 1.0, new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(4491), "Withdrawal", new Guid("85c1dc16-16b1-4808-9cb8-d8e66afc98a3") },
                    { new Guid("81e91b41-b934-4de0-aec9-cc9518e73b15"), 2.0, new DateTime(2024, 9, 26, 16, 51, 20, 101, DateTimeKind.Local).AddTicks(4502), "Withdrawal", new Guid("85c1dc16-16b1-4808-9cb8-d8e66afc98a3") }
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
