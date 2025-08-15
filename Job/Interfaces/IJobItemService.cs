using Job.Models;

/// Interface that provides methods for managing job items.
namespace Job.Interfaces
{
    /// <summary>
    /// Interface for job item service.
    /// </summary>
    public interface IJobItemService
    {
        /// <summary>
        /// gets the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public Task<JobItem> GetJobById(Guid jobId);
        /// <summary>
        /// Creates a new job item.
        /// </summary>
        /// <param name="jobItem"></param>
        /// <returns></returns>
        public Task<JobItem> CreateJobItem(JobSubmission jobItem);
        /// <summary>
        /// gets all job items.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<JobItem>> GetJobs();
        /// <summary>
        /// updates the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="jobItem"></param>
        /// <returns></returns>
        public Task<JobItem> UpdateJobItem(Guid jobId, JobSubmission jobItem);
        /// <summary>
        /// deletes the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        public void DeleteJobItem(Guid jobId);

    }
}
