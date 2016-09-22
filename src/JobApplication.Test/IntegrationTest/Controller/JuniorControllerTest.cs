using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using JobApplication.Controllers;
using JobApplication.Database.IReporistory;
using JobApplication.Database.Reporistory;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using JobApplication;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using Newtonsoft.Json;

namespace JobApplicationTest.IntegrationTest.Controller
{
    public class JuniorControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public JuniorControllerTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestGetBasicTask()
        {
            var response = await _client.GetAsync("/api/junior/BasicTask");

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestGetSampleBasicTask()
        {
            var response = await _client.GetAsync("/api/junior/SampleBasicTask");

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task PostValidSampleBasicTaskSolution()
        {
            var taskSolution = new JobApplication.ViewModel.JuniorBasicTaskSolutionViewModel();
            taskSolution.Guid = new Guid("11111111-1111-1111-1111-111111111111");
            taskSolution.FizBuzz = new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz" };
            taskSolution.Sort = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            taskSolution.Email = "mail@mail.com";
            taskSolution.B64CV = "bla";
            taskSolution.SourceCodeRepository = "https://github.com/githubtraining/hellogitworld.git";

            var jsonInString = JsonConvert.SerializeObject(taskSolution);
            var response = await _client.PostAsync("/api/junior/BasicTaskSolution", new StringContent(jsonInString, Encoding.UTF8,"application/json"));

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task PostInvalidFizzBuzzSampleBasicTaskSolution()
        {
            var taskSolution = new JobApplication.ViewModel.JuniorBasicTaskSolutionViewModel();
            taskSolution.Guid = new Guid("11111111-1111-1111-1111-111111111111");
            taskSolution.FizBuzz = new string[] { "1", "2", "Fizz"};
            taskSolution.Sort = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            taskSolution.Email = "mail@mail.com";
            taskSolution.B64CV = "bla";
            taskSolution.SourceCodeRepository = "https://github.com/githubtraining/hellogitworld.git";

            var jsonInString = JsonConvert.SerializeObject(taskSolution);
            var response = await _client.PostAsync("/api/junior/BasicTaskSolution", new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task TestJunioBasicTaskSolution()
        {
            //Get JuniorBasicTask
            var basicTaskResponse = await _client.GetAsync("/api/junior/BasicTask");

            Assert.True(basicTaskResponse.IsSuccessStatusCode);

            //Get JuniorBasicTask object
            var basicTaskResponseString = await basicTaskResponse.Content.ReadAsStringAsync();
            var basicTask = JsonConvert.DeserializeObject<JobApplication.ViewModel.JuniorBasicTaskViewModel>(basicTaskResponseString);

            //Solve task
            var solution = new JobApplication.ViewModel.JuniorBasicTaskSolutionViewModel();
            solution.Guid = basicTask.Guid;
            solution.SourceCodeRepository = "test";
            solution.Email = "mail@mail.com";
            solution.B64CV = "test";
            solution.FizBuzz = new string[basicTask.FizBuzz.Length];

            string fizzBuzz = "FizzBuzz";
            string fizz = "Fizz";
            string buzz = "Buzz";
            for (int i = 0; i < basicTask.FizBuzz.Length; i++)
            {
                if (basicTask.FizBuzz[i] % 3 == 0 && basicTask.FizBuzz[i] % 5 == 0)
                    solution.FizBuzz[i] = fizzBuzz;
                else if (basicTask.FizBuzz[i] % 3 == 0)
                    solution.FizBuzz[i] = fizz;
                else if (basicTask.FizBuzz[i] % 5 == 0)
                    solution.FizBuzz[i] = buzz;
                else
                    solution.FizBuzz[i] = basicTask.FizBuzz[i].ToString();
            }

            solution.Sort = basicTask.Sort.OrderBy(x => x).ToArray();

            //Post solution
            var solutionString = JsonConvert.SerializeObject(solution);
            var response = await _client.PostAsync("/api/junior/BasicTaskSolution", new StringContent(solutionString, Encoding.UTF8, "application/json"));

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
