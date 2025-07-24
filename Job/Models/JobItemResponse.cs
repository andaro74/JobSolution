namespace Job.Models
{
    public class JobItemResponse
    {   public Guid JobId { get; set; }
        public string? JobName { get; set; }
        public string? JobDescription { get; set; }
        public string? AssignedTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedBy { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public string? CustomerName { get; set; }   
    }
}
