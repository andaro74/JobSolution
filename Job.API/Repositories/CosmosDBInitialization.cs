using Microsoft.Azure.Cosmos;
using static System.Net.WebRequestMethods;

namespace Job.API.Repositories
{
    public class CosmosDBInitialization : ICosmosDBInitialization
    {
        private  CosmosClient? _client;

        public CosmosClient Client => _client ?? throw new InvalidOperationException("CosmosClient is not initialized. Call InitializeAsync() first.");

        public CosmosDBInitialization()
        {
            
            /*
            var accountEndpoint = Environment.GetEnvironmentVariable("COSMOSDB_ENDPOINT");
            var authKeyOrResourceToken = Environment.GetEnvironmentVariable("COSMOSDB_KEY");


            CosmosClientOptions options = new()
            {
                HttpClientFactory = () => new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                }),
                ConnectionMode = ConnectionMode.Gateway,
            };

            _client = new CosmosClient(
                accountEndpoint: accountEndpoint,
                authKeyOrResourceToken: authKeyOrResourceToken,
                options
             );*/
        }

        public async Task InitializeAsync()
        {
   
            var cosmosdatabase = Environment.GetEnvironmentVariable("COSMOSDB_DATABASE") ?? "JobDatabase";
            var cosmoscontainer = Environment.GetEnvironmentVariable("COSMOSDB_CONTAINER") ?? "Jobs";
            var cosmospartitionkey = Environment.GetEnvironmentVariable("COSMOSDB_PARTITION_KEY") ?? "/id";
            try
            {
                
                var accountEndpoint = Environment.GetEnvironmentVariable("COSMOSDB_ENDPOINT");
                var authKeyOrResourceToken = Environment.GetEnvironmentVariable("COSMOSDB_KEY");

                
                CosmosClientOptions options = new()
                {
                    HttpClientFactory = () => new HttpClient(new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    }),
                    ConnectionMode = ConnectionMode.Gateway,
                };

                _client = new(
                    accountEndpoint: accountEndpoint,
                    authKeyOrResourceToken: authKeyOrResourceToken, options
                );

                var dbResponse = await _client.CreateDatabaseIfNotExistsAsync(id: cosmosdatabase, throughput: 400);

                await dbResponse.Database.CreateContainerIfNotExistsAsync(
                    cosmoscontainer,
                    cosmospartitionkey
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
