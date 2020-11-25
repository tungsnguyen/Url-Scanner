using System.Collections.Generic;

namespace UrlScanner.Services.Interfaces
{
    public interface IScanningService
    {
        List<string> Scan(string input);
    }
}
