namespace SysAgentV2.Models.Infos
{
    public class Disk
    {
        public string Name { get; set; }
        public DictionaryInfoDisk? Info { get; set; }
    }

    public class DictionaryInfoDisk
    {
        public long TotalSpace { get; set; }
        public long UsedSpace { get; set; }
        public long FreeSpace { get; set; }
    }
}
