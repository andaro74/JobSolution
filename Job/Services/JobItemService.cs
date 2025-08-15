using Job.API.Interfaces;
using Job.API.Models;

/// Service that provides methods for managing job items.
namespace Job.API.Services
{
    /// <summary>
    /// Implements the job item service.
    /// </summary>
    public class JobItemService: IJobItemService
    {
        public JobItemService() { }

        /// <summary>
        ///  Gets all job items.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<JobItem>> GetJobs()
        {
            // Simulate fetching job items from a database or other storage
            List<JobItem> listJobItems = new List<JobItem>
            {
                new Models.JobItem
                {
                    JobId = Guid.NewGuid(),
                    JobName = "JobItem 1",
                    JobDescription = "Description for JobItem 1",
                    AssignedTo = "Alice",
                    CreatedDate = DateTime.UtcNow,
                    CompletedDate = null,
                    DueDate = DateTime.UtcNow.AddDays(5),
                    ModifiedOn = DateTime.UtcNow,
                    ModifiedBy = "Bob",
                    CreatedBy = "Bob",
                    Status = "Open",
                    Priority = "High",
                    CustomerName = "Customer A"
                },
                new JobItem
                {
                    JobId = Guid.NewGuid(),
                    JobName = "JobItem 2",
                    JobDescription = "Description for JobItem 2",
                    AssignedTo = "Charlie",
                    CreatedDate = DateTime.UtcNow,
                    CompletedDate = null,
                    DueDate = DateTime.UtcNow.AddDays(3),
                    ModifiedOn = DateTime.UtcNow,
                    ModifiedBy = "Dave",
                    CreatedBy = "Dave",
                    Status = "In Progress",
                    Priority = "Medium",
                    CustomerName = "Customer B"
                }
            };

            await Task.Delay(100); // Simulate async operation
            return listJobItems;
        }

        /// <summary>
        ///  Creates a new job item.
        /// </summary>
        /// <param name="jobItem"></param>
        /// <returns></returns>
        public async Task<Models.JobItem> CreateJobItem(JobSubmission jobItem)
        {
            // Simulate creating a new job item
            JobItem job = new JobItem {
                JobId = Guid.NewGuid(),
                JobName = jobItem.JobName,
                JobDescription = jobItem.JobDescription,
                AssignedTo = jobItem.AssignedTo,
                CreatedDate = DateTime.UtcNow,
                CompletedDate = null,
                DueDate = DateTime.UtcNow.AddDays(7),
                ModifiedOn = DateTime.UtcNow,
                ModifiedBy = "Current Creator",
                CreatedBy = "Current Creator",
                Status = "New",
                Priority = "Medium",
                CustomerName = jobItem.CustomerName
            };
            await Task.Delay(100); // Simulate async operation
            return job;
        }

        /// <summary>
        ///  Gets the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<JobItem> GetJobById(Guid jobId)
        {
            // Simulate fetching a job item from a database or other storage
            JobItem jobItem= new JobItem
            {
                JobId = jobId,
                JobName = "Sample JobItem",
                JobDescription = "This is a sample job description.",
                AssignedTo = "John Doe",
                CreatedDate = DateTime.UtcNow,
                CompletedDate = null,
                DueDate = DateTime.UtcNow.AddDays(7),
                ModifiedOn = DateTime.UtcNow,
                ModifiedBy = "Jane Doe",
                CreatedBy = "Jane Doe",
                Status = "In Progress",
                Priority = "High",
                CustomerName = "Acme Corp"
            };
            await Task.Delay(100); // Simulate async operation
            return jobItem;
        }


        /// <summary>
        /// Updates the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="jobItem"></param>
        /// <returns></returns>
        public async Task<JobItem> UpdateJobItem(Guid jobId, JobSubmission jobItem)
        {
            // Simulate updating a job item
            JobItem job = new JobItem
            {
                JobId = Guid.NewGuid(), // In a real scenario, this would be the ID of the job being updated
                JobName = jobItem.JobName,
                JobDescription = jobItem.JobDescription,
                AssignedTo = jobItem.AssignedTo,
                CreatedDate = DateTime.UtcNow.AddDays(-10), // Original creation date
                CompletedDate = null,
                DueDate = DateTime.UtcNow.AddDays(7),
                ModifiedOn = DateTime.UtcNow,
                ModifiedBy = "Current Modifier",
                CreatedBy = "Original Creator",
                Status = "Updated",
                Priority = "Medium",
                CustomerName = jobItem.CustomerName
            };
            await Task.Delay(100); // Simulate async operation
            return job;
        }

        /// <summary>
        /// Deletes the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        public void DeleteJobItem(Guid jobId)
        {
            return;
        }


    }
}
