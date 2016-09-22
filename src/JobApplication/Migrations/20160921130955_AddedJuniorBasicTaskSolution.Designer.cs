using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JobApplication.Database;

namespace JobApplication.Migrations
{
    [DbContext(typeof(JobContext))]
    [Migration("20160921130955_AddedJuniorBasicTaskSolution")]
    partial class AddedJuniorBasicTaskSolution
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobApplication.Database.Model.JuniorBasicTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("FizBuzz");

                    b.Property<Guid>("Guid");

                    b.Property<bool>("Solved");

                    b.Property<string>("Sort");

                    b.HasKey("Id");

                    b.ToTable("JuniorBasicTasks");
                });

            modelBuilder.Entity("JobApplication.Database.Model.JuniorBasicTaskSolution", b =>
                {
                    b.Property<int>("JuniorBasicTaskSolutionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("B64CV");

                    b.Property<Guid>("BasicTaskGuid");

                    b.Property<string>("Email");

                    b.Property<bool>("FizzBuzzCorrect");

                    b.Property<DateTime>("SolutionDateTime");

                    b.Property<bool>("SortCorrct");

                    b.Property<string>("SourceCodeRepository");

                    b.Property<int?>("TaskId");

                    b.HasKey("JuniorBasicTaskSolutionID");

                    b.HasIndex("TaskId");

                    b.ToTable("JuniorBasicTaskSolutions");
                });

            modelBuilder.Entity("JobApplication.Database.Model.JuniorBasicTaskSolution", b =>
                {
                    b.HasOne("JobApplication.Database.Model.JuniorBasicTask", "Task")
                        .WithMany("Solutions")
                        .HasForeignKey("TaskId");
                });
        }
    }
}
