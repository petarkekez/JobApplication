using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace JobApplication.Helpers
{
    public class ValidateSolution
    {
        public static bool ValidateFizzBuzz(string task, string[] solution)
        {
            var converter = new Converter();
            var taskIntArray = converter.ConvertStringToIntArray(task);

            if (solution == null)
                return false;

            if (taskIntArray.Length != solution.Length)
                return false;
            
            string fizzBuzz = "FizzBuzz";
            string fizz = "Fizz";
            string buzz = "Buzz";
            for (int i = 0; i < taskIntArray.Length; i++)
            {
                if (taskIntArray[i] % 3 == 0 && taskIntArray[i] % 5 == 0)
                {
                    if (solution[i] != fizzBuzz)
                        return false;
                }
                else if (taskIntArray[i] % 3 == 0)
                {
                    if (solution[i] != fizz)
                        return false;
                }
                else if (taskIntArray[i] % 5 == 0)
                {
                    if (solution[i] != buzz)
                        return false;
                }
                else
                {
                    if (solution[i] != taskIntArray[i].ToString())
                        return false;
                }
            }
            
            return true;
        }

        public static bool ValidateSort(string task, int[] solutionArray)
        {
            var converter = new Converter();

            var taskIntArray = converter.ConvertStringToIntArray(task);
            var taskSortedArray = taskIntArray.OrderBy(x => x).ToArray();
            

            if (taskIntArray.Length != solutionArray.Length)
                return false;

            for (int i = 0; i < taskIntArray.Length; i++)
                if (taskSortedArray[i] != solutionArray[i])
                    return false;

            return true;
        }
    }
}
