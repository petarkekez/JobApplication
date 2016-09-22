using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobApplication.Database.IReporistory;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JobApplication.Controllers
{
    [Route("api/[controller]")]
    public class JuniorController : Controller
    {
        private ILogger<JuniorController> _logger;
        private IJuniorTaskReporitory _repository;

        public JuniorController(IJuniorTaskReporitory juniorRepository, ILogger<JuniorController> logger)
        {
            _repository = juniorRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = new ViewModel.JuniorBasicTaskSolutionViewModel();

                response.B64CV = "bla";
                response.Email = "bla2";
                response.Guid = new Guid("4a6579cc-15cc-4cad-bcb1-ae19c64ca360");

                var bla = Newtonsoft.Json.JsonConvert.SerializeObject(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get error: {ex}");

                return BadRequest("Bad request");
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> BasicTask()
        {
            try
            {
                _logger.LogDebug("Basic task called");

                var task = ViewModel.JuniorBasicTaskViewModel.GenerateRandom();
                var converter = new Helpers.Converter();

                var taskDb = converter.ModelTask1ToDbTask1(task);

                if (await _repository.AddJuniorBasicTask(taskDb))
                    return Ok(task);
                else
                    return BadRequest("There was a problem with creating new basic task!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get BasicTask error: {ex}");

                return BadRequest("Bad request");
            }
        }

        [HttpGet("[action]")]
        public IActionResult SampleBasicTask()
        {
            try
            {
                var converter = new Helpers.Converter();
                
                var sampleTaskDb = _repository.GetBasicTaskByGuid(new Guid("11111111-1111-1111-1111-111111111111"));

                return Ok(converter.DbTask1ToModelTask1(sampleTaskDb));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get sample basic task error: {ex}");

                return BadRequest("Bad request");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> BasicTaskSolution([FromBody] ViewModel.JuniorBasicTaskSolutionViewModel taskSolution)
        {
            try
            {
                _logger.LogDebug( $"Post BasicTaskSolution Model: {taskSolution}" );

                if (!ModelState.IsValid)
                {
                    return BadRequest("Model is not valid");
                }

                var reponse = new ViewModel.SolutionResponseViewModel();
                
                var taskDb = _repository.GetBasicTaskByGuid(taskSolution.Guid);

                if (taskDb == null)
                {
                    reponse.Message = "Task(guid) not found";
                    return BadRequest(reponse);
                }

                bool solutionCorrct = true;
                var solutionDb = new JobApplication.Database.Model.JuniorBasicTaskSolution();
                bool isFizzBuzzCorrect = Helpers.ValidateSolution.ValidateFizzBuzz(taskDb.FizBuzz, taskSolution.FizBuzz);
                bool isSortCorrect = Helpers.ValidateSolution.ValidateSort(taskDb.Sort, taskSolution.Sort);

                solutionDb.FizzBuzzCorrect = isFizzBuzzCorrect;
                solutionDb.SortCorrct = isSortCorrect;
                solutionDb.Email = taskSolution.Email;
                solutionDb.B64CV = taskSolution.B64CV;
                solutionDb.BasicTaskGuid = taskSolution.Guid;
                solutionDb.SolutionDateTime = DateTime.Now;
                solutionDb.SourceCodeRepository = taskSolution.SourceCodeRepository;
                solutionDb.Task = taskDb;

                var isSolutionSaved = await _repository.AddJuniorBasicSolution(solutionDb);
                if (isSolutionSaved == false)
                {
                    reponse.Message += "ERROR: problem with saving your solution. ";
                    _logger.LogError("BasicTaskSolution - Problem with saving JuniorBasicTaskSolution - taskSolution: " + taskSolution);
                }

                if (isFizzBuzzCorrect)
                {
                    reponse.Message += "FizzBuzz is correct! ";
                }
                else
                {
                    reponse.Message += "FizzBuzz is not correct! ";
                    solutionCorrct = false;
                }


                if (isSortCorrect)
                {
                    reponse.Message += "Sort is correct! ";
                }
                else
                {
                    reponse.Message += "Sort is not correct! ";
                    solutionCorrct = false;
                }
                
                if (solutionCorrct)
                    reponse.Message += "Task solution is correct. We will be in contact!";

                if (solutionCorrct)
                    return Ok(reponse);
                else
                    return BadRequest(reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Post BasicTaskSolution error: {ex}");

                return BadRequest("Bad request. Check formating");
            }
        }
    }
}
