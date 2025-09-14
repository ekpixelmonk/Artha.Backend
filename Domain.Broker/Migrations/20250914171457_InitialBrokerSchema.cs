using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Broker.Migrations
{
    /// <inheritdoc />
    public partial class InitialBrokerSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZerodhaConfigs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APIKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PublicToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZerodhaConfigs", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZerodhaConfigs");
        }
    }
}
