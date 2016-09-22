using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApplication.Migrations
{
    public partial class TableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JuniorBasicTaskColection",
                table: "JuniorBasicTaskColection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JuniorBasicTasks",
                table: "JuniorBasicTaskColection",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "JuniorBasicTaskColection",
                newName: "JuniorBasicTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JuniorBasicTasks",
                table: "JuniorBasicTasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JuniorBasicTaskColection",
                table: "JuniorBasicTasks",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "JuniorBasicTasks",
                newName: "JuniorBasicTaskColection");
        }
    }
}
