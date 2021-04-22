using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class Seededorderdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customers_CustomerEntityId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Customers");

            migrationBuilder.AddColumn<long>(
                name: "OrderEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerEntityId",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "EntityId", "CustomerEntityId", "PizzaEntityId", "StoreEntityId" },
                values: new object[] { 1L, 1L, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityId",
                table: "Pizzas",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customers_CustomerEntityId",
                table: "Order",
                column: "CustomerEntityId",
                principalTable: "Customers",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Order_OrderEntityId",
                table: "Pizzas",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customers_CustomerEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Order_OrderEntityId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderEntityId",
                table: "Pizzas");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerEntityId",
                table: "Order",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customers_CustomerEntityId",
                table: "Order",
                column: "CustomerEntityId",
                principalTable: "Customers",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
