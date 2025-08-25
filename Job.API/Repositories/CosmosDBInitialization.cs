using Microsoft.Azure.Cosmos;
using static System.Net.WebRequestMethods;

namespace Job.API.Repositories
{
    public class CosmosDBInitialization : ICosmosDBInitialization
    {
        private CosmosClient? _client;
        private String? _cosmosdatabase;
        private String? _cosmoscontainer;
        private String? _cosmospartitionkey;
        private String? _accountEndpoint;
        private String? _authKeyOrResourceToken;

        public CosmosClient Client => _client ?? throw new InvalidOperationException("CosmosClient is not initialized. Call InitializeAsync() first.");

        public CosmosDBInitialization()
        {
            _cosmosdatabase = Environment.GetEnvironmentVariable("COSMOSDB_DATABASE") ?? "JobDatabase";
            _cosmoscontainer = Environment.GetEnvironmentVariable("COSMOSDB_CONTAINER") ?? "Jobs";
            _cosmospartitionkey = Environment.GetEnvironmentVariable("COSMOSDB_PARTITION_KEY") ?? "/id";
            _accountEndpoint = Environment.GetEnvironmentVariable("COSMOSDB_ENDPOINT") ?? "https://cosmosdb:8081/";
            _authKeyOrResourceToken = Environment.GetEnvironmentVariable("COSMOSDB_KEY") ?? "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        }

        public async Task InitializeAsync()
        {
            try
            {
                CosmosClientOptions options = new()
                {
                    HttpClientFactory = () => new HttpClient(new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    }),
                    ConnectionMode = ConnectionMode.Gateway,
                };

                _client = new(
                    accountEndpoint: _accountEndpoint,
                    authKeyOrResourceToken: _authKeyOrResourceToken, options
                );

                var dbResponse = await _client.CreateDatabaseIfNotExistsAsync(id: _cosmosdatabase, throughput: 400);

                await dbResponse.Database.CreateContainerIfNotExistsAsync(
                    _cosmoscontainer,
                    _cosmospartitionkey
                    );
                
            }
            catch (CosmosException ex) 
            {
                Console.WriteLine($"Error ex: {ex.InnerException} ");
                
            }
            
            Console.WriteLine("CosmosDB Emulator is ready and loaded with Job.");
        }
    }
}
