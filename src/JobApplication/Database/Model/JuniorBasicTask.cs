using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobApplication.Database.Model
{
    public class JuniorBasicTask
    {
        #region Constructors
        public JuniorBasicTask()
        {
        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FizBuzz { get; set; }
        public string Sort { get; set; }
        public DateTime Created { get; set; }
        public bool Solved { get; set; } = false;
        public List<JuniorBasicTaskSolution> Solutions { get; set; }
        #endregion
    }
}
