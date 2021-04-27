using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class addedcrustsasaDBset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[] { 80L, "Thin", 1.00m });

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[] { 81L, "Stuffed", 1.00m });

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[] { 82L, "Original", 1.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityId",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityId",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityId",
                keyValue: 82L);
        }
    }
}
