using Job.Services;

namespace Job.Interfaces
{
    public interface IJobItemService
    {
        public  Task<JobItem> GetJobById(Guid jobId);
        public  Task<JobItem> CreateJobItem(JobCreateItem jobItem);
        public  Task<IEnumerable<JobItem>> GetJobs();

    }
}
