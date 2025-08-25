
using AutoMapper;
using Job.API.Models;
using Microsoft.Azure.Cosmos;

namespace Job.API.Repositories
{
    public class JobItemRepositoryCosmosDB : IJobItemRepository
    {
        
        private readonly IMapper _mapper;
        private readonly ICosmosDBInitialization _dBInitialization;
        private readonly String _cosmosdatabase;
        private readonly String _cosmoscontainer;
        private readonly String _cosmospartitionkey;


        public JobItemRepositoryCosmosDB(IMapper mapper, ICosmosDBInitialization cosmosDBInitialization)
        {
            _mapper = mapper;
            _dBInitialization = cosmosDBInitialization;
            _cosmosdatabase = Environment.GetEnvironmentVariable("COSMOSDB_DATABASE") ?? "JobDatabase";
            _cosmoscontainer = Environment.GetEnvironmentVariable("COSMOSDB_CONTAINER") ?? "Jobs";
            _cosmospartitionkey = Environment.GetEnvironmentVariable("COSMOSDB_PARTITION_KEY") ?? "/id";


        }


        public async Task<IEnumerable<JobItem>> GetJobsAsync()
        {

 
            Container? container = _dBInitialization.Client.GetContainer(_cosmosdatabase, _cosmoscontainer);

            var query = $"SELECT * FROM {_cosmoscontainer}"; // SQL query to get all items
            var queryDefinition = new QueryDefinition(query);
            var queryIterator = container?.GetItemQueryIterator<JobItem>(queryDefinition);

            List<JobItem> results = new List<JobItem>();

            while (queryIterator !=null && queryIterator.HasMoreResults)
            {
                FeedResponse<JobItem> response = await queryIterator.ReadNextAsync();
                results.AddRange(response);
            }

            Console.WriteLine($"Retrieved {results.Count} items from Cosmos DB.");
            return results.ToList<JobItem>();
        }

        public async Task<JobItem?> GetJobByIdAsync(Guid id)
        {

            var client = _dBInitialization.Client;

            Container? container = client.GetContainer(_cosmosdatabase, _cosmoscontainer);
            try
            {
                ItemResponse<JobItem> response = await container.ReadItemAsync<JobItem>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Item not found
                return null;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw;
            }
            
        }

        public async Task<JobItem> CreateJobAsync(JobItem jobItem)
        {
            // Simulate creating a new job item
            jobItem.id = Guid.NewGuid();
            jobItem.CreatedDate = DateTime.UtcNow;
            jobItem.ModifiedOn = DateTime.UtcNow;
            jobItem.Status = "New";
            jobItem.Priority = "Normal";

            Container? container = _dBInitialization.Client.GetContainer(_cosmosdatabase, _cosmoscontainer);
            ItemResponse<JobItem> itemResponse = await container.CreateItemAsync(jobItem, new PartitionKey(jobItem.id.ToString()));
            return itemResponse.Resource;
        }

        public async Task<JobItem> UpdateJobAsync(JobItem jobItem)
        {
            // Simulate updating an existing job item
            jobItem.ModifiedOn = DateTime.UtcNow;

            Container? container=_dBInitialization.Client.GetContainer(_cosmosdatabase, _cosmoscontainer);
            ItemResponse<JobItem> itemResponse = await container.UpsertItemAsync(jobItem, new PartitionKey(jobItem.id.ToString())); 
            return itemResponse.Resource;
        }

        public async Task<bool> DeleteJobAsync(Guid id)
        {
            Container? container = _dBInitialization.Client.GetContainer(_cosmosdatabase, _cosmoscontainer);
            ItemResponse<JobItem> itemResponse = await container.DeleteItemAsync<JobItem>(id.ToString(), new PartitionKey(id.ToString()));
            // Simulate deleting a job item by ID
            // In a real implementation, you would check if the item exists and then delete it
            return await Task.FromResult(true);
        }
    }
}
