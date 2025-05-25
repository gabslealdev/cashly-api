using Cashly.Application.UseCases.Categories.Register;
using Cashly.Communication.Requests.RequestRegisterCategoryJson;
using Microsoft.AspNetCore.Mvc;

namespace Cashly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostCategories([FromBody] RegisterCategoryRequest request)
        {
            var useCase = new RegisterCategoryUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
