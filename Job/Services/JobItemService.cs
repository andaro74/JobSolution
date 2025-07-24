namespace Job.Services
{
    public class JobItemService: IJobItemService
    {
        public JobItemService() { }

        public IEnumerable<JobItem> GetJobs()
        {
            // Simulate fetching job items from a database or other storage
            return new List<JobItem>
            {
                new JobItem
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
                new JobItem
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
        }

        public JobItem CreateJobItem(JobCreateItem jobItem)
        {
            // Simulate creating a new job item
            return new JobItem
            {
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
        }

        public JobItem GetJobItem(Guid jobId)
        {
            // Simulate fetching a job item from a database or other storage
            return new JobItem
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
        }


    }
}
