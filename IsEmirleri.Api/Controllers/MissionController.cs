using IsEmirleri.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsEmirleri.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService missionService;

        public MissionController(IMissionService missionService)
        {
            this.missionService = missionService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAll([FromRoute(Name="id")] int id)
        {

            return Ok(missionService.GetAll());
        }
    }
}
