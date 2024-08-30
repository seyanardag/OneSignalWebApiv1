using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneSignalWebApiv1.Migrations
{
    /// <inheritdoc />
    public partial class firtsMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeworkTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "date", nullable: false),
                    CREATEDTIME = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "LiveLessons",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STARTDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STUDENTIDS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "date", nullable: false),
                    CREATEDTIME = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveLessons", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "date", nullable: false),
                    CREATEDTIME = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "StudentHomeworkMVs",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHomeworkMVs", x => new { x.StudentId, x.HomeworkId });
                    table.ForeignKey(
                        name: "FK_StudentHomeworkMVs_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentHomeworkMVs_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Homeworks",
                columns: new[] { "GUID", "CREATEDDATE", "CREATEDTIME", "HomeworkTitle" },
                values: new object[,]
                {
                    { new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"), new DateTime(2024, 8, 29, 14, 5, 55, 783, DateTimeKind.Local).AddTicks(6361), new TimeSpan(504557836361), "Tükçe 105-110 sayfalaro yap" },
                    { new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"), new DateTime(2024, 8, 29, 14, 0, 55, 783, DateTimeKind.Local).AddTicks(6354), new TimeSpan(504557836358), "Matematik 5 soru çöz" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "GUID", "CREATEDDATE", "CREATEDTIME", "StudentName" },
                values: new object[,]
                {
                    { new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"), new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(501557836256), "Ali" },
                    { new Guid("954089bb-6666-44dc-928e-d4effc12169a"), new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(501557836270), "Ahmet" },
                    { new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b"), new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(501557836268), "Ayşe" }
                });

            migrationBuilder.InsertData(
                table: "StudentHomeworkMVs",
                columns: new[] { "HomeworkId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"), new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec") },
                    { new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"), new Guid("193c1ee9-f009-475b-8a5b-b83d4ee1ccec") },
                    { new Guid("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"), new Guid("b25858ec-f3e6-4951-ac73-cd3518e3d78b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentHomeworkMVs_HomeworkId",
                table: "StudentHomeworkMVs",
                column: "HomeworkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiveLessons");

            migrationBuilder.DropTable(
                name: "StudentHomeworkMVs");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
