using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobApplication.Migrations
{
    public partial class AddedJuniorBasicTaskSolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JuniorBasicTaskSolutions",
                columns: table => new
                {
                    JuniorBasicTaskSolutionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    B64CV = table.Column<string>(nullable: true),
                    BasicTaskGuid = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FizzBuzzCorrect = table.Column<bool>(nullable: false),
                    SolutionDateTime = table.Column<DateTime>(nullable: false),
                    SortCorrct = table.Column<bool>(nullable: false),
                    SourceCodeRepository = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuniorBasicTaskSolutions", x => x.JuniorBasicTaskSolutionID);
                    table.ForeignKey(
                        name: "FK_JuniorBasicTaskSolutions_JuniorBasicTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "JuniorBasicTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<bool>(
                name: "Solved",
                table: "JuniorBasicTasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_JuniorBasicTaskSolutions_TaskId",
                table: "JuniorBasicTaskSolutions",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solved",
                table: "JuniorBasicTasks");

            migrationBuilder.DropTable(
                name: "JuniorBasicTaskSolutions");
        }
    }
}
