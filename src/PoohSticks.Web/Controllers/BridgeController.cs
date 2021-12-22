using Microsoft.AspNetCore.Mvc;
using PoohSticks.Web.DTO;

namespace PoohSticks.Web.Controllers
{
    public class BridgeController : ControllerBase
    {
        private readonly ILogger<BridgeController> logger;

        public BridgeController(ILogger<BridgeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult CreateBridge(CreateBridgeDto dto)
        {
            return Ok();
        }
    }
}
