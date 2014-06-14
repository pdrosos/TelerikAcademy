namespace ParseUrl
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ParseUrl
    {
        /// <summary>
        /// Write a program that parses an URL address given in the format:
        /// [protocol]://[server]/[resource]
		/// and extracts from it the [protocol], [server] and [resource] elements.
        /// </summary>
        public static void Main(string[] args)
        {
            string url = "http://www.devbg.org/forum/index.php?asd=fgh#top";

            Dictionary<string, string> parsedUrl = ParseUrlAdress(url);

            Console.WriteLine("URL: " + url);
            Console.WriteLine("Protocol: " + parsedUrl["scheme"]);
            Console.WriteLine("Server: " + parsedUrl["server"]);
            Console.WriteLine("Resource: " + parsedUrl["path"] + parsedUrl["queryWithQuestion"] + parsedUrl["fragmentWithSharp"]);
        }

        public static Dictionary<string, string> ParseUrlAdress(string url)
        {
            Dictionary<string, string> parsedUrl = new Dictionary<string, string>();

            string regexPattern = @"^((?<scheme>[^:/\?#]+)://)?"
                + @"(?<server>[^/\?#]*)(?<path>[^\?#]*)?" 
                + @"(?<query1>\?(?<query>[^#]*))?"
                + @"(?<fragment1>#(?<fragment>.*))?";

            Regex regex = new Regex(regexPattern, RegexOptions.ExplicitCapture);
            Match match = regex.Match(url);

            if (match.Success)
            {
                parsedUrl.Add("scheme", match.Groups["scheme"].Value);
                parsedUrl.Add("server", match.Groups["server"].Value);
                parsedUrl.Add("path", match.Groups["path"].Value);
                parsedUrl.Add("query", match.Groups["query"].Value);
                parsedUrl.Add("queryWithQuestion", match.Groups["query1"].Value);
                parsedUrl.Add("fragment", match.Groups["fragment"].Value);
                parsedUrl.Add("fragmentWithSharp", match.Groups["fragment1"].Value);
            }

            return parsedUrl;
        }
    }
}
