using Cashly.Application.UseCases.Transactions.Register;
using Cashly.Communication.Requests.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace Cashly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase 
    {
        [HttpPost]
        public IActionResult PostTransaction([FromBody] RegisterTransactionRequest request)
        {
            var useCase = new RegisterTransactionUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
