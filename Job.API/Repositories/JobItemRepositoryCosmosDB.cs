
using AutoMapper;
using Job.API.Models;
using Microsoft.Azure.Cosmos;

namespace Job.API.Repositories
{
    public class JobItemRepositoryCosmosDB : IJobItemRepository
    {
        
        private readonly IMapper _mapper;
        private readonly ICosmosDBInitialization _dBInitialization;
        

        public  JobItemRepositoryCosmosDB(IMapper mapper, ICosmosDBInitialization cosmosDBInitialization)
        {
            _mapper = mapper;
            _dBInitialization = cosmosDBInitialization;

        }


        public async Task<IEnumerable<JobItem>> GetJobsAsync()
        {
            //Initialize Cosmos DB (create database and container if they do not exist)
            await _dBInitialization.InitializeAsync();

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


            var client = _dBInitialization.Client;
            var cosmosdatabase = Environment.GetEnvironmentVariable("COSMOSDB_DATABASE") ?? "JobDatabase";
            var cosmoscontainer = Environment.GetEnvironmentVariable("COSMOSDB_CONTAINER") ?? "Jobs";
            var cosmospartitionkey = Environment.GetEnvironmentVariable("COSMOSDB_PARTITION_KEY") ?? "/id";

            Container? container = client.GetContainer(cosmosdatabase, cosmoscontainer);


            var query = $"SELECT * FROM {cosmoscontainer}"; // SQL query to get all items
            var queryDefinition = new QueryDefinition(query);
            var queryIterator = container?.GetItemQueryIterator<dynamic>(queryDefinition);

            List<dynamic> results = new List<dynamic>();

            while (queryIterator !=null && queryIterator.HasMoreResults)
            {
                FeedResponse<dynamic> response = await queryIterator.ReadNextAsync();
                results.AddRange(response);
            }

            Console.WriteLine($"Retrieved {results.Count} items from Cosmos DB.");

           

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
