using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAllStudents()
        {
            string[] allstudents = new string[] { "Abrar", "Nowrid","Mitu", "Ahsan", "James","Rodger","Steve","Bond"};

            return Ok(allstudents);
        }

    }
}
