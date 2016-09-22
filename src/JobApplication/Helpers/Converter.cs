using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplication.Helpers
{
    public class Converter
    {
        #region Methods
        public Database.Model.JuniorBasicTask ModelTask1ToDbTask1(ViewModel.JuniorBasicTaskViewModel task)
        {
            var dbTask1 = new Database.Model.JuniorBasicTask();

            dbTask1.Guid = task.Guid;
            dbTask1.FizBuzz = ConvertIntArrayToString(task.FizBuzz);
            dbTask1.Sort = ConvertIntArrayToString(task.Sort);
            dbTask1.Created = DateTime.Now;

            return dbTask1;
        }

        public ViewModel.JuniorBasicTaskViewModel DbTask1ToModelTask1(Database.Model.JuniorBasicTask task)
        {
            var modelTask1 = new ViewModel.JuniorBasicTaskViewModel();

            modelTask1.Guid = task.Guid;
            modelTask1.FizBuzz = ConvertStringToIntArray(task.FizBuzz);
            modelTask1.Sort = ConvertStringToIntArray(task.Sort);

            return modelTask1;
        }

        public string ConvertIntArrayToString(int[] array)
        {
            var result = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                result.Append(array[i]);
                if (i < array.Length - 1)
                    result.Append(",");
            }

            return result.ToString();
        }

        public int[] ConvertStringToIntArray(string array)
        {
            var stringResult = array.Split(',');
            var result = new int[stringResult.Length];

            for (int i = 0; i < stringResult.Length; i++)
            {
                result[i] = int.Parse(stringResult[i]);
            }

            return result;
        }

        #endregion
    }
}
