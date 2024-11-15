using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JD.BitBet.PL.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationbitbetdb : Migration
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
                    { new Guid("00918b19-007f-428b-bc6e-f2e87c3db17a"), new DateTime(2024, 11, 15, 15, 48, 45, 142, DateTimeKind.Local).AddTicks(7998), "knudtdaw0000@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" },
                    { new Guid("dc0cbb4e-0295-42f0-8ffd-b192ac8c2eec"), new DateTime(2024, 11, 15, 15, 48, 45, 142, DateTimeKind.Local).AddTicks(8110), "jbstrange2@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=" }
                });

            migrationBuilder.InsertData(
                table: "tblErrorLog",
                columns: new[] { "Id", "ErrorDateTime", "ErrorMessage", "ErrorType", "UserId" },
                values: new object[,]
                {
                    { new Guid("2cb95b00-1f85-4ffc-bd56-f920572c95e9"), new DateTime(2024, 11, 15, 15, 48, 45, 143, DateTimeKind.Local).AddTicks(1722), "Test", "Login Exception", new Guid("dc0cbb4e-0295-42f0-8ffd-b192ac8c2eec") },
                    { new Guid("f6af8d3d-d064-4943-b156-28c10dd4692c"), new DateTime(2024, 11, 15, 15, 48, 45, 143, DateTimeKind.Local).AddTicks(1707), "Test", "Login Exception", new Guid("00918b19-007f-428b-bc6e-f2e87c3db17a") }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "GameResult", "UserId" },
                values: new object[,]
                {
                    { new Guid("0e12d4be-f291-481c-b5d1-1c8147ca4dc2"), 200.0, new Guid("00918b19-007f-428b-bc6e-f2e87c3db17a") },
                    { new Guid("4145c5c1-aab1-4a74-9517-683c0e496e9a"), 200.0, new Guid("00918b19-007f-428b-bc6e-f2e87c3db17a") }
                });

            migrationBuilder.InsertData(
                table: "tblWallet",
                columns: new[] { "Id", "Balance", "UserId", "WalletAddress" },
                values: new object[,]
                {
                    { new Guid("42249b6d-c658-41d3-a0a3-7ded8940ac84"), 0.0, new Guid("dc0cbb4e-0295-42f0-8ffd-b192ac8c2eec"), "0xE2dC61497FDD26F9eaYaBoi5373f22df" },
                    { new Guid("f141bbd2-52f1-47b8-b378-26cb3f5f5fae"), 0.0, new Guid("00918b19-007f-428b-bc6e-f2e87c3db17a"), "0xE2dC61497FDD26F9ea285172A41F0b25373f22df" }
                });

            migrationBuilder.InsertData(
                table: "tblHand",
                columns: new[] { "Id", "BetAmount", "GameId", "Result" },
                values: new object[,]
                {
                    { new Guid("2993f826-3ab7-4320-a11e-3bf20b7f226d"), 20.0, new Guid("0e12d4be-f291-481c-b5d1-1c8147ca4dc2"), -20.0 },
                    { new Guid("f068d930-2aa3-40fd-9fab-cd2cc12781a0"), 20.0, new Guid("4145c5c1-aab1-4a74-9517-683c0e496e9a"), 40.0 }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "TransactionDate", "TransactionType", "WalletId" },
                values: new object[,]
                {
                    { new Guid("2d86f55c-d9f4-4ad1-9994-03d4aee121d1"), 1.0, new DateTime(2024, 11, 15, 15, 48, 45, 142, DateTimeKind.Local).AddTicks(9923), "Withdrawal", new Guid("42249b6d-c658-41d3-a0a3-7ded8940ac84") },
                    { new Guid("517a31a4-c83b-4fb8-bc1a-e9a2f6540f39"), 1.0, new DateTime(2024, 11, 15, 15, 48, 45, 142, DateTimeKind.Local).AddTicks(9896), "Withdrawal", new Guid("f141bbd2-52f1-47b8-b378-26cb3f5f5fae") },
                    { new Guid("d42c83f5-7a66-4f9b-addd-d50404be817b"), 2.0, new DateTime(2024, 11, 15, 15, 48, 45, 142, DateTimeKind.Local).AddTicks(9912), "Withdrawal", new Guid("f141bbd2-52f1-47b8-b378-26cb3f5f5fae") },
                    { new Guid("f8dc8753-d2c0-49db-9494-acb36a0dc671"), 2.0, new DateTime(2024, 11, 15, 15, 48, 45, 142, DateTimeKind.Local).AddTicks(9933), "Withdrawal", new Guid("42249b6d-c658-41d3-a0a3-7ded8940ac84") }
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
