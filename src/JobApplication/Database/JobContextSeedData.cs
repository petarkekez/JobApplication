using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplication.Database.Model;

namespace JobApplication.Database
{
    public class JobContextSeedData
    {
        private JobContext _context;

        public JobContextSeedData(JobContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.JuniorBasicTasks.Any())
            {
                var sampleTask1 = new JuniorBasicTask();
                sampleTask1.Created = DateTime.Now;
                sampleTask1.FizBuzz = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20";
                sampleTask1.Sort = "5,2,4,10,1,3,7,6,9,8";
                sampleTask1.Guid = new Guid("11111111-1111-1111-1111-111111111111");

                _context.JuniorBasicTasks.Add(sampleTask1);

                await _context.SaveChangesAsync();
            }
        }
    }
}
