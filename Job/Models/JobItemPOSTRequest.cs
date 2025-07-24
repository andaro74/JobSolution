namespace Job.Models
{
    public class JobItemPOSTRequest
    {   
        public string? JobName { get; set; }
        public string? JobDescription { get; set; }
        public string? AssignedTo { get; set; }
        public string? CustomerName { get; set; }   
    }
}
