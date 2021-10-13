using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class activitiesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 83, DateTimeKind.Utc).AddTicks(2327),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 639, DateTimeKind.Utc).AddTicks(1034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 97, DateTimeKind.Utc).AddTicks(5978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 655, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 96, DateTimeKind.Utc).AddTicks(5179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 654, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.CreateTable(
                name: "Activitiess",
                columns: table => new
                {
                    Activity_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity_Creation_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity_Detail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activitiess", x => x.Activity_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activitiess");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_creation_date",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 639, DateTimeKind.Utc).AddTicks(1034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 83, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "reply_creation_date",
                table: "reply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 655, DateTimeKind.Utc).AddTicks(8821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 97, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "message_creation_date",
                table: "message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 7, 6, 17, 654, DateTimeKind.Utc).AddTicks(5291),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 12, 45, 13, 96, DateTimeKind.Utc).AddTicks(5179));
        }
    }
}
