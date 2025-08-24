
//using Amazon.DynamoDBv2;
//using Amazon.DynamoDBv2.DataModel;


using Job.API.Maps;
using Job.API.Repositories;
using Job.API.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;


namespace Job.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Logging.AddConsole();

            // Add DynamoDB services
            //builder.Services.AddAWSService<IAmazonDynamoDB>();
            //builder.Services.AddTransient<IDynamoDBContext, DynamoDBContext>();

            //Add AutoMapper Configuration
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingJob>();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSingleton<CosmosDBInitialization>();
            builder.Services.AddSingleton<ICosmosDBInitialization, CosmosDBInitialization>();
            builder.Services.AddTransient<IJobItemService, JobItemService>();
            
            builder.Services.AddTransient<IJobItemRepository, JobItemRepositoryCosmosDB>();

            var app = builder.Build();
            
            using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<ICosmosDBInitialization>();
                await initializer.InitializeAsync();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
