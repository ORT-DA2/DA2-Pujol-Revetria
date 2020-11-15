using BusinessLogicInterface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/importers")]
    public class ImportController : BookedUYController
    {
        private readonly IImporterLogic importLogic;
        public ImportController(IImporterLogic importLogic)
        {
            this.importLogic = importLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.importLogic.GetNames());
        }

        [HttpGet("/{{name}}")]
        public IActionResult GetParameters([FromRoute]string name)
        {
            return Ok(this.importLogic.GetParameters(name));
        }

        [HttpPost] 
        public IActionResult Post([FromBody] ImporterModel import) 
        {
            this.importLogic.Import(import);
            return Ok();
        }
    }
}
