using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreBank3169_0.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardInfoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryYear = table.Column<int>(type: "int", nullable: false),
                    ExpiryMonth = table.Column<int>(type: "int", nullable: false),
                    CardLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInfoes", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "CardInfoes",
                columns: new[] { "ID", "Balance", "CVC", "CardLimit", "CardNumber", "CardUserName", "CreatedDate", "DeletedDate", "ExpiryMonth", "ExpiryYear", "ModifiedDate", "Status" },
                values: new object[] { 1, 10000m, "222", 10000m, "1111 1111 1111 1111", "Test verisidir", new DateTime(2023, 12, 23, 13, 16, 9, 886, DateTimeKind.Utc).AddTicks(5060), null, 12, 2024, null, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardInfoes");
        }
    }
}
