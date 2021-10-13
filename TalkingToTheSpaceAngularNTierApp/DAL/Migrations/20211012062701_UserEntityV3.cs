using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UserEntityV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_point",
                table: "user");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 818, DateTimeKind.Utc).AddTicks(5583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 904, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 831, DateTimeKind.Utc).AddTicks(5850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 924, DateTimeKind.Utc).AddTicks(3346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 829, DateTimeKind.Utc).AddTicks(4617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 921, DateTimeKind.Utc).AddTicks(2548));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 904, DateTimeKind.Utc).AddTicks(8149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 818, DateTimeKind.Utc).AddTicks(5583));

            migrationBuilder.AddColumn<long>(
                name: "user_point",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 924, DateTimeKind.Utc).AddTicks(3346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 831, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 921, DateTimeKind.Utc).AddTicks(2548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 27, 0, 829, DateTimeKind.Utc).AddTicks(4617));
        }
    }
}
