using Cashly.Application.UseCases.Goals;
using Cashly.Communication.Requests.Goal;
using Microsoft.AspNetCore.Mvc;

namespace Cashly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostGoals([FromBody] RegisterGoalRequest request)
        {
            var useCase = new RegisterGoalUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
