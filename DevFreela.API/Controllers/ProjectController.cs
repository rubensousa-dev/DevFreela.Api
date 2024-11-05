using DevFreela.API.Model;
using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Services;
using Microsoft.Extensions.Options;


namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly FreelanceTotalCostConfig _config;
        private readonly IConfigServices _configServices;

        public ProjectController
            (IOptions<FreelanceTotalCostConfig> options, 
            IConfigServices configServices)
        {
            _config = options.Value;
            _configServices = configServices;
        }

        // Post api/Projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            if (model.TotalCost < _config.MinValue || model.TotalCost > _config.MaxValue)
            {
                return BadRequest("not valid");
            }
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }
        // get api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            return Ok(_configServices.GetValue());
        }

        // Get api/projects/123
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // for testing
            throw new Exception();
            return Ok();
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            return NoContent();
        }

        //Put api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }        
        //Put api/projects/1234/completed
        [HttpPut("{id}/completed")]
        public IActionResult Completed(int id)
        {
            return NoContent();
        }
        [HttpPut("{id}/comments")]
        public IActionResult Comments(int id, CreateProjectCommentInputModel model)
        {
            return Ok();
        }

        //Delete api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
