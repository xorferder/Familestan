namespace Familestan.Core.Entities
{
    public class Log : BaseEntity
    {
        public long? LogUserId { get; set; }
        public User? LogUser { get; set; }
        public string? LogAction { get; set; } = string.Empty;
        public string? LogDescription { get; set; } = string.Empty;
        public string? LogIPAddress { get; set; } = string.Empty;
    }
}