using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplication.ViewModel
{
    public class JuniorBasicTaskViewModel
    {
        #region Properties
        public Guid Guid { get; set; }
        public int[] FizBuzz { get; set; }
        public int[] Sort { get; set; }
        #endregion

        #region Methodes
        public static JuniorBasicTaskViewModel GenerateRandom()
        {
            var task = new ViewModel.JuniorBasicTaskViewModel();

            var randomGenerator = new Random();

            int fizBuzzLength = randomGenerator.Next(100, 1000);
            int sortLength = randomGenerator.Next(100, 1000);

            task.Guid = Guid.NewGuid();
            task.FizBuzz = new int[fizBuzzLength];
            task.Sort = new int[sortLength];

            for (int i = 0; i < fizBuzzLength; i++)
                task.FizBuzz[i] = randomGenerator.Next(1, 1000);

            for (int i = 0; i < sortLength; i++)
                task.Sort[i] = randomGenerator.Next(1, 1000);

            return task;
        }

        #endregion
    }
}
