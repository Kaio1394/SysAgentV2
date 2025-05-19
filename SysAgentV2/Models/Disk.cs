namespace SysAgentV2.Models
{
    public class Disk
    {
        public string Name { get; set; }
        public DictioaryInfoDisk? Info {get; set;}
    }

    public class DictioaryInfoDisk
    {
        public long TotalSpace { get; set; }
        public long UsedSpace { get; set; }
        public long FreeSpace { get; set; }
    }
}
