using System.Text.Json.Serialization;

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
        /// 
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        /// <summary>
        /// Job Name.
        /// </summary>
        [JsonPropertyName("jobname")]
        public string? JobName { get; set; }

        /// <summary>
        /// Job Description.
        /// </summary>
        [JsonPropertyName("jobdescription")]
        public string? JobDescription { get; set; }

        [JsonPropertyName("assignedto")]
        public string? AssignedTo { get; set; }

        [JsonPropertyName("createddate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("completeddate")]
        public DateTime? CompletedDate { get; set; }

        [JsonPropertyName("duedate")]
        public DateTime? DueDate { get; set; }

        [JsonPropertyName("modifiedon")]
        public DateTime? ModifiedOn { get; set; }

        [JsonPropertyName("modifiedby")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("createdby")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("priority")]
        public string? Priority { get; set; }

        [JsonPropertyName("customername")]
        public string? CustomerName { get; set; }
    }
}
