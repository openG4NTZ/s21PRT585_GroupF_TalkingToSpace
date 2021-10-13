using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class photosEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 15, 9, 45, 66, DateTimeKind.Utc).AddTicks(2562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 83, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 15, 9, 45, 85, DateTimeKind.Utc).AddTicks(7630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 97, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 15, 9, 45, 84, DateTimeKind.Utc).AddTicks(5174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 96, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Photo_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo_Detail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Photo_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 83, DateTimeKind.Utc).AddTicks(2327),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 15, 9, 45, 66, DateTimeKind.Utc).AddTicks(2562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 97, DateTimeKind.Utc).AddTicks(5978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 15, 9, 45, 85, DateTimeKind.Utc).AddTicks(7630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 96, DateTimeKind.Utc).AddTicks(5179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 15, 9, 45, 84, DateTimeKind.Utc).AddTicks(5174));
        }
    }
}
