using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DbManagment.Migrations
{
    /// <inheritdoc />
    public partial class CardTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardTemplateID",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CardTemplates",
                columns: table => new
                {
                    CardTemplateID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardTemplateName = table.Column<string>(type: "text", nullable: false),
                    CardTemplateContent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTemplates", x => x.CardTemplateID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTemplateID",
                table: "Cards",
                column: "CardTemplateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTemplates_CardTemplateID",
                table: "Cards",
                column: "CardTemplateID",
                principalTable: "CardTemplates",
                principalColumn: "CardTemplateID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTemplates_CardTemplateID",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "CardTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CardTemplateID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardTemplateID",
                table: "Cards");
        }
    }
}
