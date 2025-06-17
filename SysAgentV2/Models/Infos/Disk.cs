using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.Infos
{
    [ExcludeFromCodeCoverage]
    public class Disk
    {
        public string Name { get; set; }
        public DictionaryInfoDisk? Info { get; set; }
    }
    [ExcludeFromCodeCoverage]
    public class DictionaryInfoDisk
    {
        public long TotalSpace { get; set; }
        public long UsedSpace { get; set; }
        public long FreeSpace { get; set; }
    }
}
