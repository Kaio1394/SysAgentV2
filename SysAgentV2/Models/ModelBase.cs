namespace SysAgentV2.Models
{
    public class ModelBase
    {
        public string Uuid { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
