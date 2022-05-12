using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class qwe1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_TypeOfRooms_TypeOfRoomId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusRooms_TypeOfStatuses_TypeOfStatusId",
                table: "StatusRooms");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "StatusRooms");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfStatusId",
                table: "StatusRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfRoomId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_TypeOfRooms_TypeOfRoomId",
                table: "Rooms",
                column: "TypeOfRoomId",
                principalTable: "TypeOfRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusRooms_TypeOfStatuses_TypeOfStatusId",
                table: "StatusRooms",
                column: "TypeOfStatusId",
                principalTable: "TypeOfStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_TypeOfRooms_TypeOfRoomId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusRooms_TypeOfStatuses_TypeOfStatusId",
                table: "StatusRooms");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfStatusId",
                table: "StatusRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "StatusRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfRoomId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_TypeOfRooms_TypeOfRoomId",
                table: "Rooms",
                column: "TypeOfRoomId",
                principalTable: "TypeOfRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusRooms_TypeOfStatuses_TypeOfStatusId",
                table: "StatusRooms",
                column: "TypeOfStatusId",
                principalTable: "TypeOfStatuses",
                principalColumn: "Id");
        }
    }
}
