using Cashly.Communication.RequestRegisterCategoryJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cashly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostCategories([FromBody] RequestRegisterCategoryJson request)
        {
            return Created();
        }
    }
}
