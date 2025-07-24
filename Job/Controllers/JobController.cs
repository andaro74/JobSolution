using Microsoft.AspNetCore.Mvc;
using Job.Services;
using Job.Models;
using Job.Interfaces;


namespace Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobItemService _jobItemService;

        public JobController(IJobItemService jobItemService)
        {
            _jobItemService = jobItemService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Models.Job>> Get()
        {
            IEnumerable<Models.Job> jobItems = await _jobItemService.GetJobs();
            return jobItems;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Models.Job> Get(Guid id)
        {
            Models.Job jobItem = await _jobItemService.GetJobById(id);
            return jobItem;
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Post([FromBody] JobSubmission jobSubmission)
        {
            Models.Job jobItem= await _jobItemService.CreateJobItem(jobSubmission);

            return CreatedAtAction(nameof(Get), new { id = jobItem.JobId }, jobItem);

        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
