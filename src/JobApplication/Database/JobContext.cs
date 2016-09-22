using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using JobApplication.Database.Model;
namespace JobApplication.Database
{
    public class JobContext : DbContext
    {
        #region Fields
        private IConfigurationRoot _config;
        #endregion

        public DbSet<JuniorBasicTask> JuniorBasicTasks { get; set; }
        public DbSet<JuniorBasicTaskSolution> JuniorBasicTaskSolutions { get; set; }


        public JobContext(IConfigurationRoot  config, DbContextOptions options)
            : base(options) 
        {
            _config = config;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            options.UseSqlServer(_config["ConnectionStrings:JobContextConnectionLocalSqlServer"]);
        }

        
    }
}
