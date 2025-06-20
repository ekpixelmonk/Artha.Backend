using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artha.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedZerodhaHoldingsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZerodhaHoldings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tradingsymbol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    exchange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    instrument_token = table.Column<int>(type: "int", nullable: true),
                    isin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    t1_quantity = table.Column<int>(type: "int", nullable: true),
                    realised_quantity = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    used_quantity = table.Column<int>(type: "int", nullable: true),
                    authorised_quantity = table.Column<int>(type: "int", nullable: true),
                    opening_quantity = table.Column<int>(type: "int", nullable: true),
                    authorised_date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    average_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    last_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    close_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    pnl = table.Column<float>(type: "real", nullable: true),
                    day_change = table.Column<float>(type: "real", nullable: true),
                    day_change_percentage = table.Column<float>(type: "real", nullable: true),
                    product = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    collateral_quantity = table.Column<int>(type: "int", nullable: true),
                    collateral_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    discrepancy = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZerodhaHoldings", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZerodhaHoldings_tradingsymbol_exchange",
                table: "ZerodhaHoldings",
                columns: new[] { "tradingsymbol", "exchange" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZerodhaHoldings");
        }
    }
}
