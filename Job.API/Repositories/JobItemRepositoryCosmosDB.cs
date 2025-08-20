
using AutoMapper;
using Job.API.Models;
using Microsoft.Azure.Cosmos;

namespace Job.API.Repositories
{
    public class JobItemRepositoryCosmosDB : IJobItemRepository
    {
        private readonly CosmosClient _client;
        private readonly IMapper _mapper;

        public JobItemRepositoryCosmosDB(IMapper mapper)
        {
            _mapper = mapper;
            var options = new CosmosClientOptions
            {
                HttpClientFactory = () => new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                }),
                ConnectionMode = ConnectionMode.Gateway,



            };
            var accountEndpoint = Environment.GetEnvironmentVariable("COSMOSDB_ENDPOINT") ?? "http://localhost:8081";
            var authKeyOrResourceToken = Environment.GetEnvironmentVariable("COSMOSDB_KEY") ?? "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

            _client = new CosmosClient(
                accountEndpoint: accountEndpoint,
                authKeyOrResourceToken: authKeyOrResourceToken, options);
        
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

            Console.WriteLine($"Getting Cosmosdatabase Jobs");
            var cosmosdatabase = _client.GetDatabase("Jobs"); // Ensure the table exists
            if (cosmosdatabase == null)
            {
                Console.WriteLine($"Creating Cosmosdatabase");
                cosmosdatabase = await _client.CreateDatabaseIfNotExistsAsync("Jobs");
                Console.WriteLine($"Created Cosmosdatabase");
            }
            Console.WriteLine($"Cosmosdatabase: {cosmosdatabase.Id}");


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
