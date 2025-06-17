using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.Infos
{
    [ExcludeFromCodeCoverage]
    public class EventView
    {
        public string EntryType { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string TimeGenerated { get; set; }
    }
}
