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
                    { new Guid("71f6abb1-90e5-44ab-b405-575b4c4dd10a"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("f4f7e9d5-d674-4cca-9485-3e5eaa2c8904"), new DateTime(2024, 11, 20, 17, 16, 50, 163, DateTimeKind.Local).AddTicks(8426), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("5dab015a-1db6-4d7e-ac97-63a381879251"), new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Login Exception", new Guid("71f6abb1-90e5-44ab-b405-575b4c4dd10a") },
                    { new Guid("a3d940be-9406-40e7-804f-7c416af48ab8"), new DateTime(2024, 11, 20, 17, 16, 50, 164, DateTimeKind.Local).AddTicks(1927), "Test", "Login Exception", new Guid("f4f7e9d5-d674-4cca-9485-3e5eaa2c8904") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("055a707f-f1a0-4892-b92d-b93be49beccc"), 200.0, new Guid("71f6abb1-90e5-44ab-b405-575b4c4dd10a") },
                    { new Guid("53a79816-2c7d-445f-91a1-a4bdc36291d3"), 200.0, new Guid("71f6abb1-90e5-44ab-b405-575b4c4dd10a") }
                });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("24c75c5b-e43b-4ab7-bde8-235f0b3a3f6f"), 0.0, new Guid("f4f7e9d5-d674-4cca-9485-3e5eaa2c8904"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("6e8f8d71-fb93-4dab-95d6-48ba7860fe90"), 0.0, new Guid("71f6abb1-90e5-44ab-b405-575b4c4dd10a"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "GameId", "Result" },
                values: new object[,]
                {
                    { new Guid("8f2b6662-7a74-475e-8b56-0a6c7eee3d04"), 20.0, new Guid("055a707f-f1a0-4892-b92d-b93be49beccc"), -20.0 },
                    { new Guid("b204e286-064d-470d-a113-188a1ec4b664"), 20.0, new Guid("53a79816-2c7d-445f-91a1-a4bdc36291d3"), 40.0 },
                    { new Guid("b3d9d49a-4573-4ff1-a56e-27f260816fcd"), 20.0, new Guid("055a707f-f1a0-4892-b92d-b93be49beccc"), -20.0 },
                    { new Guid("c12c3591-ede7-47cc-a329-659f3547e217"), 20.0, new Guid("53a79816-2c7d-445f-91a1-a4bdc36291d3"), 40.0 }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("10508944-3342-45c1-b5e1-809971855501"), 2.0, new DateTime(2024, 11, 20, 17, 16, 50, 163, DateTimeKind.Local).AddTicks(9920), "Withdrawal", new Guid("6e8f8d71-fb93-4dab-95d6-48ba7860fe90") },
                    { new Guid("649da6e3-7b73-49c6-96d9-a801e01ac766"), 1.0, new DateTime(2024, 11, 20, 17, 16, 50, 163, DateTimeKind.Local).AddTicks(9936), "Withdrawal", new Guid("24c75c5b-e43b-4ab7-bde8-235f0b3a3f6f") },
                    { new Guid("bb295811-fff5-422a-818f-2b68340f5550"), 2.0, new DateTime(2024, 11, 20, 17, 16, 50, 163, DateTimeKind.Local).AddTicks(9946), "Withdrawal", new Guid("24c75c5b-e43b-4ab7-bde8-235f0b3a3f6f") },
                    { new Guid("e54deddb-422d-41ba-bf87-b2e81cdcb67d"), 1.0, new DateTime(1990, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal", new Guid("6e8f8d71-fb93-4dab-95d6-48ba7860fe90") }
                });

            migrationBuilder.InsertData(
                table: "tblCard",
                columns: new[] { "Id", "HandId", "Suit", "Value" },
                values: new object[,]
                {
                    { new Guid("49abc5f4-6562-44d1-be61-16b29aa08a3f"), new Guid("b204e286-064d-470d-a113-188a1ec4b664"), "King", 1 },
                    { new Guid("98456ab0-4b09-4455-9141-2069a401ca2d"), new Guid("c12c3591-ede7-47cc-a329-659f3547e217"), "King", 1 },
                    { new Guid("aa2fea72-945d-4e5e-a929-e572c0a32c64"), new Guid("8f2b6662-7a74-475e-8b56-0a6c7eee3d04"), "King", 1 },
                    { new Guid("ab5f6c44-2c47-4ff5-907c-f637e16f77d1"), new Guid("b3d9d49a-4573-4ff1-a56e-27f260816fcd"), "King", 1 },
                    { new Guid("b0211641-af21-47fe-b400-1070e8d26249"), new Guid("b204e286-064d-470d-a113-188a1ec4b664"), "King", 10 },
                    { new Guid("b05506fc-98d6-4612-b4cc-e05799e52ba3"), new Guid("b3d9d49a-4573-4ff1-a56e-27f260816fcd"), "King", 1 },
                    { new Guid("b41e8021-9fba-4ed6-b813-fbaabc3aa851"), new Guid("8f2b6662-7a74-475e-8b56-0a6c7eee3d04"), "King", 1 },
                    { new Guid("e6f0bb9a-5f7f-485e-8a8a-cab01a191add"), new Guid("c12c3591-ede7-47cc-a329-659f3547e217"), "King", 1 }
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
