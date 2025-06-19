using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artha.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedZerodhaTradeableInstrumentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZerodhaTradeableInstruments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instrument_token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    exchange_token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tradingsymbol = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    last_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    expiry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    strike = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    tick_size = table.Column<float>(type: "real", nullable: true),
                    lot_size = table.Column<int>(type: "int", nullable: true),
                    instrument_type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    segment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    exchange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZerodhaTradeableInstruments", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZerodhaTradeableInstruments_exchange_tradingsymbol",
                table: "ZerodhaTradeableInstruments",
                columns: new[] { "exchange", "tradingsymbol" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZerodhaTradeableInstruments");
        }
    }
}
