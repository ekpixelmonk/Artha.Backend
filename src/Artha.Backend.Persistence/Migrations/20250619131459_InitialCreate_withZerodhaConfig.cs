using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artha.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_withZerodhaConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZerodhaConfig",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    APIKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PublicToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZerodhaConfig", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZerodhaConfig_ID",
                table: "ZerodhaConfig",
                column: "ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZerodhaConfig");
        }
    }
}
