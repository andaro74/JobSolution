namespace Job.Services
{
    public interface IJobItemService
    {
        public JobItem GetJobItem(Guid jobId);
        public JobItem CreateJobItem(JobCreateItem jobItem);
        public IEnumerable<JobItem> GetJobs();

    }
}
