using Cashly.Application.UseCases.Users.Register;
using Cashly.Communication.Requests.User;
using Microsoft.AspNetCore.Mvc;


namespace Cashly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        [HttpPost]
        public IActionResult PostUser([FromBody]RegisterUserRequest request)
        {
            var useCase = new RegisterUserUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
