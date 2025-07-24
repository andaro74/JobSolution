namespace Job.Models
{
    public class JobItemCreateRequest
    {   
        public string? JobName { get; set; }
        public string? JobDescription { get; set; }
        public string? AssignedTo { get; set; }
        public string? CustomerName { get; set; }   
    }
}
