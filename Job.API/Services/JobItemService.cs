using Job.API.Models;
using Job.API.DTOs;

using AutoMapper;
using Job.API.Repositories;

/// Service that provides methods for managing job items.
namespace Job.API.Services
{
    /// <summary>
    /// Implements the job item service.
    /// </summary>
    public class JobItemService: IJobItemService
    {

        private readonly IMapper _mapper;
        private readonly IJobItemRepository _repository;

        public JobItemService(IMapper mapper, IJobItemRepository repository) {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        ///  Gets all job items.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<JobItemDTO>> GetJobs()
        {
          
           var listJobItems = await _repository.GetJobsAsync();
           var jobItemsDTOList = _mapper.Map<IEnumerable<JobItem>, IEnumerable<JobItemDTO>>(listJobItems);

            return jobItemsDTOList;
        }

        /// <summary>
        ///  Creates a new job item.
        /// </summary>
        /// <param name="jobItem"></param>
        /// <returns></returns>
        public async Task<JobItemDTO> CreateJobItem(JobItemRequestDTO jobItemRequest)
        {
            // Simulate creating a new job item
            JobItem jobItem = new JobItem {
               
                JobName = jobItemRequest.JobName,
                JobDescription = jobItemRequest.JobDescription,
                AssignedTo = jobItemRequest.AssignedTo,
                CompletedDate = null,
                DueDate = DateTime.UtcNow.AddDays(7),
                ModifiedBy = "Current Creator",
                CreatedBy = "Current Creator",
                CustomerName = jobItemRequest.CustomerName
            };
            var jobItemResult = await _repository.CreateJobAsync(jobItem);
            var jobItemDTO = _mapper.Map<JobItem, JobItemDTO>(jobItemResult);
            return jobItemDTO;
        }

        /// <summary>
        ///  Gets the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<JobItemDTO?> GetJobById(Guid Id)
        {

            var jobItem = await _repository.GetJobByIdAsync(Id);
            var jobItemDTO = _mapper.Map<JobItem?, JobItemDTO?>(jobItem);
            return jobItemDTO;
        }


        /// <summary>
        /// Updates the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="jobItem"></param>
        /// <returns></returns>
        public async Task<JobItemDTO> UpdateJobItem(Guid Id, JobItemRequestDTO jobItemRequest)
        {
            // Simulate updating a job item
            JobItem jobItem = new JobItem
            {
                id = Guid.NewGuid(), // In a real scenario, this would be the ID of the job being updated
                JobName = jobItemRequest.JobName,
                JobDescription = jobItemRequest.JobDescription,
                AssignedTo = jobItemRequest.AssignedTo,
                CreatedDate = DateTime.UtcNow.AddDays(-10), // Original creation date
                CompletedDate = null,
                DueDate = DateTime.UtcNow.AddDays(7),
                ModifiedOn = DateTime.UtcNow,
                ModifiedBy = "Current Modifier",
                CreatedBy = "Original Creator",
                Status = "Updated",
                Priority = "Medium",
                CustomerName = jobItemRequest.CustomerName
            };
            await Task.Delay(100); // Simulate async operation
            var jobItemDTO = _mapper.Map<JobItem, JobItemDTO>(jobItem);
            return jobItemDTO;
        }

        /// <summary>
        /// Deletes the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        public async Task DeleteJobItem(Guid Id)
        {
            await _repository.DeleteJobAsync(Id);
            return;
        }


    }
}
