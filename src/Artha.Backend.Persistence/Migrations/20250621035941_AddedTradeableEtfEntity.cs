using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artha.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedTradeableEtfEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeableEtfs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Exchange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeableEtfs", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradeableEtfs_Symbol_Exchange",
                table: "TradeableEtfs",
                columns: new[] { "Symbol", "Exchange" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeableEtfs");
        }
    }
}
