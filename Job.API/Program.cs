
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Job.API.Interfaces;
using Job.API.Maps;
using Job.API.Services;
using Microsoft.Extensions.Configuration;


namespace Job.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Logging.AddConsole();

            // Add DynamoDB services
            builder.Services.AddAWSService<IAmazonDynamoDB>();
            builder.Services.AddTransient<IDynamoDBContext, DynamoDBContext>();

            //Add AutoMapper Configuration
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingJob>();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IJobItemService, JobItemService>();

            var app = builder.Build();

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
