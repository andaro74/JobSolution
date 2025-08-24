using Microsoft.Azure.Cosmos;

namespace Job.API.Repositories
{
    public interface ICosmosDBInitialization
    {
        CosmosClient Client { get; }

        /// <summary>
        /// Initializes the database and container.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task InitializeAsync();


    }
}
