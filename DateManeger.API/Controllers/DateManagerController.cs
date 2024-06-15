using DateManager.API.Models;
using DateManeger.API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DateManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateManagerController : ControllerBase
    {
        private readonly IDateManagerService _dateManagerService;
        public DateManagerController(IDateManagerService dateManagerService) => _dateManagerService = dateManagerService;
        [HttpPost]
        public IActionResult Post([FromBody]DateManagerPostModel model)
        {
            try
            {
                DateManagerPostModel result = _dateManagerService.ChangeDate(model.DateValue, model.Op, model.Time);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
