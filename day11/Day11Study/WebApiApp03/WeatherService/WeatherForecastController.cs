using Microsoft.AspNetCore.Mvc;
using WebApiApp03.Entity;

namespace WebApiApp03.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DbCtx _dbCtx;

        public WeatherForecastController(DbCtx dbCtx)
        {
            _dbCtx = dbCtx;
        }

        [HttpGet("test")]
        public async Task<ActionResult<IEnumerable<IoTDatas>>> Get([FromQuery] int id)
        {
            var data = _dbCtx.IoTDatas.Where(x => x.Id == id).ToList();
            return data;
        }
    }
}


