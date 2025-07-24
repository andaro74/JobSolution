using Microsoft.AspNetCore.Mvc;
using Job.Services;
using Job.Models;
using Job.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<List<JobItemResponse>> Get()
        {
            IEnumerable<JobItem> jobs = await _jobItemService.GetJobs();

            List<JobItemResponse> jobItemResponses = new List<JobItemResponse>();
            foreach (JobItem jobItem in jobs) { 
            
                JobItemResponse jobItemResponse = new JobItemResponse();
                jobItemResponse.JobId = jobItem.JobId;
                jobItemResponse.JobName = jobItem.JobName;
                jobItemResponse.JobDescription = jobItem.JobDescription;
                jobItemResponses.Add(jobItemResponse);
            
            }
            return jobItemResponses;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<JobItemResponse> Get(Guid id)
        {
            JobItem jobItem = await _jobItemService.GetJobById(id);

            JobItemResponse jobItemResponse = new JobItemResponse();
            jobItemResponse.JobId = jobItem.JobId;
            return jobItemResponse;
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Post([FromBody] JobItemCreateRequest jobItem)
        {
            JobCreateItem jobCreateItem = new JobCreateItem();
            jobCreateItem.JobName = jobItem.JobName;
            jobCreateItem.JobDescription = jobItem.JobDescription;
            jobCreateItem.CustomerName = jobItem.CustomerName;
            jobCreateItem.AssignedTo = jobItem.AssignedTo;
            var item= await _jobItemService.CreateJobItem(jobCreateItem);

            JobItemResponse jobItemResponse = new JobItemResponse();
            jobItemResponse.JobId = item.JobId;
            jobItemResponse.JobName = item.JobName;
            jobItemResponse.JobDescription = item.JobDescription;
            jobItemResponse.AssignedTo = item.AssignedTo;
            jobItemResponse.CustomerName = item.CustomerName;

            return CreatedAtAction(nameof(Get), new { id = jobItemResponse.JobId }, jobItemResponse);

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
