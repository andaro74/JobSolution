namespace Job.API.DTOs
{
    public class JobItemRequestDTO
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
