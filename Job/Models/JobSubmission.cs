
/// JobSubmission model representing the data required to create or update a job item.
namespace Job.Models
{
    /// <summary>
    /// JobSubmission model representing the data required to create or update a job item.
    /// </summary>
    public class JobSubmission
    {
        /// <summary>
        /// Job name
        /// </summary>
        public string? JobName { get; set; }

        /// <summary>
        /// Job description
        /// </summary>
        public string? JobDescription { get; set; }

        /// <summary>
        /// Assigned to
        /// </summary>
        public string? AssignedTo { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public string? CustomerName { get; set; }   
    }
}
