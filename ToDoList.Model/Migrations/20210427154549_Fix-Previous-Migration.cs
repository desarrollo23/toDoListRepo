using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Model.Migrations
{
    public partial class FixPreviousMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCar_ShoppingCar_ShoppingCarId",
                table: "ItemCar");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "ShoppingCar");

            migrationBuilder.DropColumn(
                name: "IdShoppingCar",
                table: "ItemCar");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCarId",
                table: "ItemCar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCar_ShoppingCar_ShoppingCarId",
                table: "ItemCar",
                column: "ShoppingCarId",
                principalTable: "ShoppingCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCar_ShoppingCar_ShoppingCarId",
                table: "ItemCar");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "ShoppingCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCarId",
                table: "ItemCar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdShoppingCar",
                table: "ItemCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCar_ShoppingCar_ShoppingCarId",
                table: "ItemCar",
                column: "ShoppingCarId",
                principalTable: "ShoppingCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
