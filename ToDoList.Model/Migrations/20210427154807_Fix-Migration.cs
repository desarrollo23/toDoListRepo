using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Model.Migrations
{
    public partial class FixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCar_User_UserId",
                table: "ShoppingCar");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingCar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCar_User_UserId",
                table: "ShoppingCar",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCar_User_UserId",
                table: "ShoppingCar");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingCar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCar_User_UserId",
                table: "ShoppingCar",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
