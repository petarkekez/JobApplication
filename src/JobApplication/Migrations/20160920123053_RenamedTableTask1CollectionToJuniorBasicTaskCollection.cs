using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApplication.Migrations
{
    public partial class RenamedTableTask1CollectionToJuniorBasicTaskCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Task1Colection",
                table: "Task1Colection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JuniorBasicTaskColection",
                table: "Task1Colection",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Task1Colection",
                newName: "JuniorBasicTaskColection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JuniorBasicTaskColection",
                table: "JuniorBasicTaskColection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task1Colection",
                table: "JuniorBasicTaskColection",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "JuniorBasicTaskColection",
                newName: "Task1Colection");
        }
    }
}
