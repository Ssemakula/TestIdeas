using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIdeas.Strings
{
    public static class StringExtensions
    {
        public static (double? lat, double? lon) TryParseCoordinates(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return (null, null);

            var parts = input.Split(',');
            if (parts.Length != 2)
                return (null, null);

            string latPart = parts[0].Trim();
            string lonPart = parts[1].Trim();

            if (double.TryParse(latPart, NumberStyles.Any, CultureInfo.InvariantCulture, out double lat) &&
                double.TryParse(lonPart, NumberStyles.Any, CultureInfo.InvariantCulture, out double lon))
            {
                return (lat, lon);
            }

            return (null, null);
        }
    }
}