using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class SeededPizzadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<long>(
                name: "CrustEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[] { 4L, "Neapolitan", 1.00m });

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId",
                principalTable: "Crust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityId",
                table: "Pizzas");

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityId",
                keyValue: 4L);

            migrationBuilder.AlterColumn<long>(
                name: "CrustEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId",
                principalTable: "Crust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
