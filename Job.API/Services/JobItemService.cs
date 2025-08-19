using Job.API.Interfaces;
using Job.API.Models;
using Job.API.DTOs;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using AutoMapper;

/// Service that provides methods for managing job items.
namespace Job.API.Services
{
    /// <summary>
    /// Implements the job item service.
    /// </summary>
    public class JobItemService: IJobItemService
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly IMapper _mapper;

        public JobItemService(IMapper mapper) {
            _mapper = mapper;
            var config = new AmazonDynamoDBConfig
            {
                ServiceURL = Environment.GetEnvironmentVariable("DYNAMODB_ENDPOINT") ?? "http://localhost:8000"
            };
            _client = new AmazonDynamoDBClient(config);
        }

        /// <summary>
        ///  Gets all job items.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<JobItemDTO>> GetJobs()
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
            var listTableResponse = await _client.ListTablesAsync(); // Ensure the table exists
            Console.WriteLine($"Number of Tables in DynamoDB: {listTableResponse.TableNames.Count}");
            
            var jobItemsDTOList=_mapper.Map<IEnumerable<JobItem>, IEnumerable<JobItemDTO>>(listJobItems);

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
                JobId = Guid.NewGuid(),
                JobName = jobItemRequest.JobName,
                JobDescription = jobItemRequest.JobDescription,
                AssignedTo = jobItemRequest.AssignedTo,
                CreatedDate = DateTime.UtcNow,
                CompletedDate = null,
                DueDate = DateTime.UtcNow.AddDays(7),
                ModifiedOn = DateTime.UtcNow,
                ModifiedBy = "Current Creator",
                CreatedBy = "Current Creator",
                Status = "New",
                Priority = "Medium",
                CustomerName = jobItemRequest.CustomerName
            };
            await Task.Delay(100); // Simulate async operation
            var jobItemDTO = _mapper.Map<JobItem, JobItemDTO>(jobItem);
            return jobItemDTO;
        }

        /// <summary>
        ///  Gets the job item with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<JobItemDTO> GetJobById(Guid Id)
        {
            // Simulate fetching a job item from a database or other storage
            JobItem jobItem= new JobItem
            {
                JobId = Id,
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
            var jobItemDTO = _mapper.Map<JobItem, JobItemDTO>(jobItem);
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
                JobId = Guid.NewGuid(), // In a real scenario, this would be the ID of the job being updated
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
        public void DeleteJobItem(Guid Id)
        {
            return;
        }


    }
}
