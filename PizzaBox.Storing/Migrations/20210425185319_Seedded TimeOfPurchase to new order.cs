using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class SeeddedTimeOfPurchasetoneworder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.AlterColumn<long>(
                name: "SizeEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfPurchase",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "EntityId", "CustomerEntityId", "PizzaEntityId", "StoreEntityId", "TimeOfPurchase" },
                values: new object[] { 20L, 14L, null, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId",
                principalTable: "Sizes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas");

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "EntityId",
                keyValue: 20L);

            migrationBuilder.DropColumn(
                name: "TimeOfPurchase",
                table: "Order");

            migrationBuilder.AlterColumn<long>(
                name: "SizeEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "EntityId", "CustomerEntityId", "PizzaEntityId", "StoreEntityId" },
                values: new object[] { 1L, 0L, null, 0L });

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId",
                principalTable: "Sizes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
