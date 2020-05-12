using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class WorkOrderTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_AspNetUsers_AssignEmployeeId1",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_AssignEmployeeId1",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "AssignEmployeeId1",
                table: "WorkOrders");

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrderNumber",
                table: "WorkOrders",
                maxLength: 35,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrderDescription",
                table: "WorkOrders",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "WorkOrders",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "AssignEmployeeId",
                table: "WorkOrders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AssignEmployeeId",
                table: "WorkOrders",
                column: "AssignEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_AspNetUsers_AssignEmployeeId",
                table: "WorkOrders",
                column: "AssignEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_AspNetUsers_AssignEmployeeId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_AssignEmployeeId",
                table: "WorkOrders");

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrderNumber",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 35,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrderDescription",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 750,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "WorkOrders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignEmployeeId",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignEmployeeId1",
                table: "WorkOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AssignEmployeeId1",
                table: "WorkOrders",
                column: "AssignEmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_AspNetUsers_AssignEmployeeId1",
                table: "WorkOrders",
                column: "AssignEmployeeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
