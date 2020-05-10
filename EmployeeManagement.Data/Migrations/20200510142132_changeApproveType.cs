using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class changeApproveType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AlterColumn<int>(
                name: "Approved",
                table: "EmployeeLeaveRequests",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "EmployeeLeaveRequests",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
