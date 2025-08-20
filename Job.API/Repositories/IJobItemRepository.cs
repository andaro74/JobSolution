using Job.API.Models;

namespace Job.API.Repositories
{
    public interface IJobItemRepository
    {
        public Task<IEnumerable<JobItem>> GetJobsAsync();

        public Task<JobItem?> GetJobByIdAsync(Guid id);

        public Task<JobItem> CreateJobAsync(JobItem jobItem);

        public Task<JobItem> UpdateJobAsync(JobItem jobItem);

        public Task<bool> DeleteJobAsync(Guid id);
    }
}
