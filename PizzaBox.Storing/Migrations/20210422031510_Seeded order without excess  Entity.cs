using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class SeededorderwithoutexcessEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_AStoreEntityId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_AStoreEntityId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AStoreEntityId",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "EntityId",
                keyValue: 1L,
                columns: new[] { "CustomerEntityId", "StoreEntityId" },
                values: new object[] { 0L, 0L });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreEntityId",
                table: "Order",
                column: "StoreEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_StoreEntityId",
                table: "Order",
                column: "StoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_StoreEntityId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StoreEntityId",
                table: "Order");

            migrationBuilder.AddColumn<long>(
                name: "AStoreEntityId",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "EntityId",
                keyValue: 1L,
                columns: new[] { "CustomerEntityId", "StoreEntityId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AStoreEntityId",
                table: "Order",
                column: "AStoreEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_AStoreEntityId",
                table: "Order",
                column: "AStoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
