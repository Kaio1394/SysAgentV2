
using System.Text.Json.Serialization;

namespace SysAgentV2.Models
{
    public class Process
    {
        public string Name { get; set; }  
        public int Id { get; set; }

        [JsonIgnore]
        public long UsageMemoryAux { get; set; }
        public string UsageMemory { get; set; }
    }
}
