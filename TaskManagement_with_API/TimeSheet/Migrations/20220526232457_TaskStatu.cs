using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class TaskStatu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    TaskName = table.Column<string>(nullable: true),
                    TaskDesc = table.Column<string>(nullable: true),
                    ScheduledHour = table.Column<int>(nullable: false),
                    ScheduledMin = table.Column<int>(nullable: false),
                    ScheduledTime = table.Column<int>(nullable: false),
                    TimeSpent = table.Column<int>(nullable: false),
                    TaskProcess = table.Column<string>(nullable: true),
                    TaskStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    mail = table.Column<string>(maxLength: 110, nullable: true),
                    password = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
