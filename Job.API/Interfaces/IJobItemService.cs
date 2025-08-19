using Job.API.DTOs;

/// Interface that provides methods for managing job items including creation, retrieval, updating, and deletion.
namespace Job.API.Interfaces
{
    /// <summary>
    /// Interface for job item service
    /// </summary>
    public interface IJobItemService
    {
        /// <summary>
        /// gets the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public Task<JobItemDTO> GetJobById(Guid Id);
        /// <summary>
        /// Creates a new job item.
        /// </summary>
        /// <param name="jobItem"></param>
        /// <returns></returns>
        public Task<JobItemDTO> CreateJobItem(JobItemRequestDTO jobItemRequest);
        /// <summary>
        /// gets all job items.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<JobItemDTO>> GetJobs();
        /// <summary>
        /// updates the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="jobItem"></param>
        /// <returns></returns>
        public Task<JobItemDTO> UpdateJobItem(Guid Id, JobItemRequestDTO jobItemRequest);
        /// <summary>
        /// deletes the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        public void DeleteJobItem(Guid Id);

    }
}
