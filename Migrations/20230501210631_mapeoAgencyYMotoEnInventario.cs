using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace guido_sanz_parcial1.Migrations
{
    /// <inheritdoc />
    public partial class mapeoAgencyYMotoEnInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Moto_MotoId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_MotoId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "MotoId",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Moto",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Inventory",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "Inventory",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_AgencyId",
                table: "Inventory",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_IdMoto",
                table: "Inventory",
                column: "IdMoto");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Agency_AgencyId",
                table: "Inventory",
                column: "AgencyId",
                principalTable: "Agency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Moto_IdMoto",
                table: "Inventory",
                column: "IdMoto",
                principalTable: "Moto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Agency_AgencyId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Moto_IdMoto",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_AgencyId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_IdMoto",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Moto",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Inventory",
                newName: "quantity");

            migrationBuilder.AddColumn<int>(
                name: "MotoId",
                table: "Inventory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_MotoId",
                table: "Inventory",
                column: "MotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Moto_MotoId",
                table: "Inventory",
                column: "MotoId",
                principalTable: "Moto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
