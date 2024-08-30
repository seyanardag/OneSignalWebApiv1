using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneSignalWebApiv1.Migrations
{
    /// <inheritdoc />
    public partial class customScheduleEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomSchedules",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "date", nullable: false),
                    CREATEDTIME = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomSchedules", x => x.GUID);
                });

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 14, 42, 56, 783, DateTimeKind.Local).AddTicks(717), new TimeSpan(526767830717) });

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 14, 37, 56, 783, DateTimeKind.Local).AddTicks(709), new TimeSpan(526767830713) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(523767830609) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(523767830631) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(523767830620) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomSchedules");

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 29, 14, 5, 55, 783, DateTimeKind.Local).AddTicks(6361), new TimeSpan(504557836361) });

            migrationBuilder.UpdateData(
                table: "Homeworks",
                keyColumn: "GUID",
                keyValue: new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 29, 14, 0, 55, 783, DateTimeKind.Local).AddTicks(6354), new TimeSpan(504557836358) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(501557836256) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("954089bb-6666-44dc-928e-d4effc12169a"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(501557836270) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "GUID",
                keyValue: new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"),
                columns: new[] { "CREATEDDATE", "CREATEDTIME" },
                values: new object[] { new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(501557836268) });
        }
    }
}
