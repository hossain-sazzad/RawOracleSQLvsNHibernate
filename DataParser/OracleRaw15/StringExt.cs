using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleRaw15
{
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            value= value.Replace("'", "\\'");
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
