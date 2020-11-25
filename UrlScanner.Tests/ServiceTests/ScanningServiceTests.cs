using FluentAssertions;
using UrlScanner.Services;
using UrlScanner.Services.Interfaces;
using Xunit;

namespace UrlScanner.Tests.ServiceTests
{
    public class ScanningServiceTests
    {
        private readonly IScanningService scanningService;

        public ScanningServiceTests()
        {
            scanningService = new ScanningService();
        }

        [Fact]
        public void Scan_EmptyString_ReturnsEmpty()
        {
            scanningService.Scan("").Count.Should().Be(0);
        }

        [Fact]
        public void Scan_Contains6Urls_Returns6Urls()
        {
            var result = scanningService.Scan(@"Visit photo hosting sites such as www.flickr.com, 500px.com, www.freeimagehosting.net and
            https://postimage.io, and upload these two image files, picture.dog.png and picture.cat.jpeg,
            there.After that share their links at https://www.facebook.com/ and http://🍕.ws");
            result.Count.Should().Be(6);
        }

        [Fact]
        public void Scan_ContainsDuplicatedUrls_ReturnsOnlyOne()
        {
            var result = scanningService.Scan(@"Visit google.com and http://google.com");
            result.Count.Should().Be(1);
        }
    }
}
