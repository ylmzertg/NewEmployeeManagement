using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class approveColoumnNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Approved",
                table: "EmployeeLeaveRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Approved",
                table: "EmployeeLeaveRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
