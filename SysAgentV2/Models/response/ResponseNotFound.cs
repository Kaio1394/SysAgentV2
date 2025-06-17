using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.response
{
    [ExcludeFromCodeCoverage]
    public class ResponseNotFound
    {
        public InfoError? InfoError { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InfoError
    {
        public string? Error { get; set; }
    }
}
