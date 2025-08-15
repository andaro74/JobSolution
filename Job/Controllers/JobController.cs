using Microsoft.AspNetCore.Mvc;

using Job.API.Models;
using Job.API.Interfaces;


namespace Job.API.Controllers
{
    /// <summary>
    /// controller for managing job items.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobItemService _jobItemService;

        /// <summary>
        /// initializes a new instance of the <see cref="JobController"/> class.
        /// </summary>
        /// <param name="jobItemService"></param>
        public JobController(IJobItemService jobItemService)
        {
            _jobItemService = jobItemService;
        }

        /// <summary>
        ///  Gets all job items.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IEnumerable<Models.JobItem>> Get()
        {
            IEnumerable<Models.JobItem> jobItems = await _jobItemService.GetJobs();
            return jobItems;
        }

        /// <summary>
        /// Gets the job item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<Models.JobItem> Get(Guid id)
        {
            Models.JobItem jobItem = await _jobItemService.GetJobById(id);
            return jobItem;
        }

        /// <summary>
        /// Creates a new job item.
        /// </summary>
        /// <param name="jobSubmission"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Post([FromBody] JobSubmission jobSubmission)
        {
            Models.JobItem jobItem= await _jobItemService.CreateJobItem(jobSubmission);

            return CreatedAtAction(nameof(Get), new { id = jobItem.JobId }, jobItem);

        }

        /// <summary>
        /// Updates the job item with the specified identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobSubmission"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Put(Guid id, [FromBody] JobSubmission jobSubmission)
        {
            Models.JobItem jobItem = await _jobItemService.UpdateJobItem(id, jobSubmission);
            return Ok(jobItem);
        }
        
        /// <summary>
        /// Deletes the job item with the specified identifier.
        /// </summary>
        /// <remarks>This operation removes the job item associated with the provided <paramref
        /// name="id"/>.  If the job item does not exist, no action is taken.</remarks>
        /// <param name="id">The unique identifier of the job item to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public void Delete(Guid id)
        {
            _jobItemService.DeleteJobItem(id);
        }


    }
}
