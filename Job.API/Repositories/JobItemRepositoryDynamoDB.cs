using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using AutoMapper;
using Job.API.Models;

namespace Job.API.Repositories
{
    public class JobItemRepositoryDynamoDB : IJobItemRepository
    {


        private readonly AmazonDynamoDBClient _client;
        private readonly IMapper _mapper;

        public JobItemRepositoryDynamoDB(IMapper mapper)
        {
            _mapper = mapper;
            var config = new AmazonDynamoDBConfig
            {
                ServiceURL = Environment.GetEnvironmentVariable("DYNAMODB_ENDPOINT") ?? "http://localhost:8000"
            };
            _client = new AmazonDynamoDBClient(config);
        }


        public async Task<IEnumerable<JobItem>> GetJobsAsync()
        {
            // Simulate fetching job items from a database or other storage
            List<JobItem> listJobItems = new List<JobItem>
            {
                new JobItem
                {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
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

            var listTableResponse = await _client.ListTablesAsync(); // Ensure the table exists
            Console.WriteLine($"Number of Tables in DynamoDB: {listTableResponse.TableNames.Count}");


            return await Task.FromResult(listJobItems);
        }

        public async Task<JobItem?> GetJobByIdAsync(Guid id)
        {
            // Simulate fetching a job item by ID
            var jobItem = new JobItem
            {
                Id = id,
                JobName = "Sample Job",
                JobDescription = "This is a sample job description.",
                AssignedTo = "John Doe",
                CreatedDate = DateTime.UtcNow,
                CompletedDate = null,
                DueDate = DateTime.UtcNow.AddDays(7),
                ModifiedOn = DateTime.UtcNow,
                ModifiedBy = "Jane Doe",
                CreatedBy = "Jane Doe",
                Status = "Open",
                Priority = "Normal",
                CustomerName = "Customer X"
            };
            return await Task.FromResult(jobItem);
        }

        public async Task<JobItem> CreateJobAsync(JobItem jobItem)
        {
            // Simulate creating a new job item
            jobItem.Id = Guid.NewGuid();
            jobItem.CreatedDate = DateTime.UtcNow;
            jobItem.ModifiedOn = DateTime.UtcNow;
            jobItem.Status = "New";
            jobItem.Priority = "Normal";
            return await Task.FromResult(jobItem);
        }

        public async Task<JobItem> UpdateJobAsync(JobItem jobItem)
        {
            // Simulate updating an existing job item
            jobItem.ModifiedOn = DateTime.UtcNow;
            return await Task.FromResult(jobItem);
        }

        public async Task<bool> DeleteJobAsync(Guid id)
        {
            // Simulate deleting a job item by ID
            // In a real implementation, you would check if the item exists and then delete it
            return await Task.FromResult(true);
        }
    }
}
