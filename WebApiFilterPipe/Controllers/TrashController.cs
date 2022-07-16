using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebApiFilterPipe.Contracts;

namespace WebApiFilterPipe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrashController : ControllerBase
    {
        private readonly ILogger<TrashController> _logger;
        private readonly IRequestClient<EmptyTrashBin> client;

        public TrashController(ILogger<TrashController> logger, IRequestClient<EmptyTrashBin> client)
        {
            _logger = logger;
            this.client = client;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromHeader(Name = "origem")] int origem, string binNumber)
        {
            var response = await client.GetResponse<EmptyTrashBinResponse>(new EmptyTrashBin() {  Value = "Teste consumer" });
            return Accepted();
        }
    }
}