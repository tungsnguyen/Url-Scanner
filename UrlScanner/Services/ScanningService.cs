using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UrlScanner.Services.Interfaces;

namespace UrlScanner.Services
{
    public class ScanningService : IScanningService
    {
        private const string URL_PATTERN = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/|www.)?((\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]
            |\ud83e[\ud000-\udfff])|[a-z0-9])+\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";

        public List<string> Scan(string input)
        {
            var urls = new List<string>();
            var links = input.Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string value in links)
            {
                if (Regex.IsMatch(value, URL_PATTERN))
                {
                    string url = value;

                    if (!url.StartsWith("http") && !url.StartsWith("https"))
                    {
                        url = "http://" + url;
                    }

                    if (!urls.Contains(url))
                    {
                        urls.Add(url);
                    }
                }
            }

            return urls;
        }
    }
}
