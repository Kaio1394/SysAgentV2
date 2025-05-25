namespace SysAgentV2.Models.response
{
    public class ResponseNotFound
    {
        public InfoError InfoError { get; set; }
    }
    
    public class InfoError
    {
        public string Error { get; set; }
    }
}
