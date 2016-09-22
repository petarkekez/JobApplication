using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JobApplicationTest.UnitTest.Helpers
{
    public class SolutionValidateTest
    {
        [Fact]
        public void ValidFizzbuzz()
        {
            //var sut = JobApplication.Helpers.ValidateSolution();

            var fizzBuzTask = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20";
            var fizzBuzzSolution = new string[] { "1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz","16","17","Fizz","19","Buzz" };

            var result = JobApplication.Helpers.ValidateSolution.ValidateFizzBuzz(fizzBuzTask, fizzBuzzSolution);

            Assert.True(result);
        }

        [Theory]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20", new string[] { "1", "2", "Fizz" })]
        [InlineData("1,2,3,4,5,6,7,8,9,10", new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz" })]
        [InlineData("1,1,1", new string[] { "1", "2", "Fizz" })]
        public void InvalidFizzbuzz(string fizzBuzTask, string[] fizzBuzzSolution)
        {
            var result = JobApplication.Helpers.ValidateSolution.ValidateFizzBuzz(fizzBuzTask, fizzBuzzSolution);

            Assert.False(result);
        }

        [Fact]
        public void ValidSort()
        {
            var sortTask = "5,2,4,10,1,3,7,6,9,8";
            var sortSolution = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = JobApplication.Helpers.ValidateSolution.ValidateSort(sortTask, sortSolution);
            Assert.True(result);
        }

        [Theory]
        [InlineData("5,4,3,2,1", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [InlineData("10,9,8,7,6,5,4,3,2,1", new int[] { 1, 2, 3, 4, 5 })]
        [InlineData("5,4,3,2,1", new int[] { 1, 2, 3, 4, 4 })]
        public void InvalidSort(string sortTask, int[] sortSolution)
        {

            var result = JobApplication.Helpers.ValidateSolution.ValidateSort(sortTask, sortSolution);
            Assert.False(result);
        }
    }
}
