using CheckPerson.DTOs.Person;
using CheckPerson.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckPerson.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CheckPersonController : ControllerBase
    {
        private readonly ICheckPersonService _checkPersonService;

        public CheckPersonController(ICheckPersonService checkPersonService)
        {
            _checkPersonService = checkPersonService;
        }

        [HttpPost]
        [Route("check-person")]
        public async Task<IActionResult> CheckPerson(CheckPersonDto checkPersonDto)
        {
            var result = await _checkPersonService.CheckPersonAsync(checkPersonDto);

            if (!result.Success)
                return NotFound();

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("person/{name}")]
        public async Task<IActionResult> GetPerson(string name)
        {
            var result = await _checkPersonService.GetPersonAsync(name);

            if (!result.Success)
                return NotFound();

            return Ok(result.Data);
        }
    }
}
