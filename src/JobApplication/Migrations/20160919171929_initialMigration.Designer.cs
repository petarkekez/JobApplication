using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JobApplication.Database;

namespace JobApplication.Migrations
{
    [DbContext(typeof(JobContext))]
    [Migration("20160919171929_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobApplication.Database.Task1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("FizBuzz");

                    b.Property<Guid>("Guid");

                    b.Property<string>("Sort");

                    b.HasKey("Id");

                    b.ToTable("Task1Colection");
                });
        }
    }
}
