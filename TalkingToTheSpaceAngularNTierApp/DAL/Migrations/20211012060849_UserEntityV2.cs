using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UserEntityV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_password",
                table: "user",
                newName: "user_token");

            migrationBuilder.AlterColumn<long>(
                name: "user_point",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 904, DateTimeKind.Utc).AddTicks(8149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 440, DateTimeKind.Utc).AddTicks(3708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 924, DateTimeKind.Utc).AddTicks(3346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 453, DateTimeKind.Utc).AddTicks(6205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 921, DateTimeKind.Utc).AddTicks(2548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 451, DateTimeKind.Utc).AddTicks(8434));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_token",
                table: "user",
                newName: "user_password");

            migrationBuilder.AlterColumn<long>(
                name: "user_point",
                table: "user",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 440, DateTimeKind.Utc).AddTicks(3708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 904, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 453, DateTimeKind.Utc).AddTicks(6205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 924, DateTimeKind.Utc).AddTicks(3346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 5, 11, 38, 48, 451, DateTimeKind.Utc).AddTicks(8434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 6, 8, 48, 921, DateTimeKind.Utc).AddTicks(2548));
        }
    }
}
