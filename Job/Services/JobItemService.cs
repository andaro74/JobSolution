using Job.Interfaces;
using Job.Models;

namespace Job.Services
{
    public class JobItemService: IJobItemService
    {
        public JobItemService() { }

        public async Task<IEnumerable<Models.Job>> GetJobs()
        {
            // Simulate fetching job items from a database or other storage
            List<Models.Job> listJobItems = new List<Models.Job>
            {
                new Models.Job
                {
                    JobId = Guid.NewGuid(),
                    JobName = "Job 1",
                    JobDescription = "Description for Job 1",
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
                new Models.Job
                {
                    JobId = Guid.NewGuid(),
                    JobName = "Job 2",
                    JobDescription = "Description for Job 2",
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

        public async Task<Models.Job> CreateJobItem(JobSubmission jobItem)
        {
            // Simulate creating a new job item
            Models.Job job = new Models.Job {
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

        public async Task<Models.Job> GetJobById(Guid jobId)
        {
            // Simulate fetching a job item from a database or other storage
            Models.Job jobItem= new Models.Job
            {
                JobId = jobId,
                JobName = "Sample Job",
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


    }
}
