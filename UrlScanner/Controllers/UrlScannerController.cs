using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlScanner.Services.Interfaces;

namespace UrlScanner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlScannerController : ControllerBase
    {
        private readonly IScanningService scanningService;

        public UrlScannerController(IScanningService scanningService)
        {
            this.scanningService = scanningService;
        }

        [HttpPost]
        [Route("scan")]
        [Produces("application/json")]
        public async Task<List<string>> ScanAsync()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            string givenInput = await reader.ReadToEndAsync();
            var result = scanningService.Scan(givenInput);

            return result;
        }

        [HttpGet]
        public string Test()
        {
            return "This is an WebApi for URL scanner";
        }
    }
}
