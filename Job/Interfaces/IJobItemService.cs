using Job.Models;
using Job.Services;

namespace Job.Interfaces
{
    public interface IJobItemService
    {
        public  Task<Models.Job> GetJobById(Guid jobId);
        public  Task<Models.Job> CreateJobItem(JobSubmission jobItem);
        public  Task<IEnumerable<Models.Job>> GetJobs();

    }
}
