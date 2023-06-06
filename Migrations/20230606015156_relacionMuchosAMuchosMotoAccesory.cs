using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace guido_sanz_parcial1.Migrations
{
    /// <inheritdoc />
    public partial class relacionMuchosAMuchosMotoAccesory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotoAccesory",
                columns: table => new
                {
                    AccesoriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    MotosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoAccesory", x => new { x.AccesoriesId, x.MotosId });
                    table.ForeignKey(
                        name: "FK_MotoAccesory_Accesory_AccesoriesId",
                        column: x => x.AccesoriesId,
                        principalTable: "Accesory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotoAccesory_Moto_MotosId",
                        column: x => x.MotosId,
                        principalTable: "Moto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotoAccesory_MotosId",
                table: "MotoAccesory",
                column: "MotosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotoAccesory");

            migrationBuilder.DropTable(
                name: "Accesory");
        }
    }
}
