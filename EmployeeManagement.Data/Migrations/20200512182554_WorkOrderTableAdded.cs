using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class WorkOrderTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    WorkOrderDescription = table.Column<string>(nullable: true),
                    WorkOrderStatus = table.Column<int>(nullable: false),
                    WorkOrderPoint = table.Column<double>(nullable: false),
                    WorkOrderNumber = table.Column<string>(nullable: true),
                    AssignEmployeeId = table.Column<int>(nullable: false),
                    AssignEmployeeId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_AspNetUsers_AssignEmployeeId1",
                        column: x => x.AssignEmployeeId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AssignEmployeeId1",
                table: "WorkOrders",
                column: "AssignEmployeeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrders");
        }
    }
}
