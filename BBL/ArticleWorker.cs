using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public static class ArticleWorker
    {
        public static string ReduceText(string text, int size)
        {
            return text.Substring(0, size < text.Length ? size : text.Length) + (text.Length > size ? "..." : "");
        }
    }
}
