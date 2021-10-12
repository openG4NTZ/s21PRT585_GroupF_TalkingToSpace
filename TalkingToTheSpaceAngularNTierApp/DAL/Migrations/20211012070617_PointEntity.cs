using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class PointEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 639, DateTimeKind.Utc).AddTicks(1034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 818, DateTimeKind.Utc).AddTicks(5583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 655, DateTimeKind.Utc).AddTicks(8821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 831, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 654, DateTimeKind.Utc).AddTicks(5291),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 829, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.CreateTable(
                name: "point",
                columns: table => new
                {
                    point_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    point_amount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "0"),
                    User_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_point", x => x.point_id);
                    table.ForeignKey(
                        name: "FK_point_user_User_ID",
                        column: x => x.User_ID,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_point_User_ID",
                table: "point",
                column: "User_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "point");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 818, DateTimeKind.Utc).AddTicks(5583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 639, DateTimeKind.Utc).AddTicks(1034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 831, DateTimeKind.Utc).AddTicks(5850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 655, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 829, DateTimeKind.Utc).AddTicks(4617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 654, DateTimeKind.Utc).AddTicks(5291));
        }
    }
}
