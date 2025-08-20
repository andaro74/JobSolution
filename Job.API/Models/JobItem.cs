/// JobItem Model representing a job item.
namespace Job.API.Models
{
    /// <summary>
    /// JobItem Model representing a job item.
    /// </summary>
    public class JobItem
    {
        /// <summary>
        /// Job Identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Job Name.
        /// </summary>
        public string? JobName { get; set; }

        /// <summary>
        /// Job Description.
        /// </summary>
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
