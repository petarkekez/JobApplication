using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplication.Database.Model
{
    public class JuniorBasicTaskSolution
    {
        [Key]
        public int JuniorBasicTaskSolutionID { get; set; }
        public Guid BasicTaskGuid { get; set; }
        public bool FizzBuzzCorrect { get; set; }
        public bool SortCorrct { get; set; }
        public DateTime SolutionDateTime { get; set; }
        public string Email { get; set; }
        public string B64CV { get; set; }
        public string SourceCodeRepository { get; set; }
        public JuniorBasicTask Task { get; set; }
    }
}
