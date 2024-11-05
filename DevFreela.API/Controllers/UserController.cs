using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        // post api/users
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        // profile picture
        [HttpPut ("{id}/ profile-picture")]
        public IActionResult ProfilePicture(IFormFile file) {
            var description = $"{file.FileName} and {file.Length}";
            return Ok(description);
        }
    }
}
