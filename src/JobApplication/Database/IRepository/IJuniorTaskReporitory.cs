using System;
using JobApplication.Database.Model;
using System.Threading.Tasks;

namespace JobApplication.Database.IReporistory
{
    public interface IJuniorTaskReporitory
    {
        JuniorBasicTask GetBasicTaskByGuid(Guid guid);
        Task<bool> AddJuniorBasicTask(JuniorBasicTask newTask);
        Task<bool> AddJuniorBasicSolution(JuniorBasicTaskSolution newSolution);
    }
}