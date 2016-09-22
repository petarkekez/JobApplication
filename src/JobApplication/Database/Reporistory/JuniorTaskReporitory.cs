using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplication.Database.IReporistory;
using JobApplication.Database.Model;

namespace JobApplication.Database.Reporistory
{
    public class JuniorTaskReporitory : IJuniorTaskReporitory
    {
        private JobContext _context;

        public JuniorTaskReporitory(JobContext jobContext)
        {
            _context = jobContext;
        }

        public JuniorBasicTask GetBasicTaskByGuid(Guid guid)
        {
            return _context.JuniorBasicTasks.Where(x => x.Guid == guid).SingleOrDefault();
        }

        public async Task<bool> AddJuniorBasicTask(JuniorBasicTask newTask)
        {
            _context.JuniorBasicTasks.Add(newTask);
            if (await _context.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> AddJuniorBasicSolution(JuniorBasicTaskSolution newSolution)
        {
            _context.JuniorBasicTaskSolutions.Add(newSolution);

            if (newSolution.SortCorrct && newSolution.FizzBuzzCorrect)
                newSolution.Task.Solved = true;

            if (await _context.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }
    }
}
