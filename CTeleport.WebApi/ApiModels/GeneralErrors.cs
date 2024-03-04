namespace CTeleport.WebApi.Models
{
    /// <summary>
    /// Public Error
    /// </summary>
    public class GeneralErrors
    {
        /// <summary>
        /// Uniq identificatof or error
        /// </summary>
        public Guid Id => Guid.NewGuid();

        /// <summary>
        /// Datetime when error raised
        /// </summary>
        public DateTimeOffset Datetime => DateTimeOffset.Now;

        /// <summary>
        /// List of errors
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
    }
}
