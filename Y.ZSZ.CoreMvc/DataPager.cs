using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.CoreMvc
{
    public class DataPager
    {
        public int TotalSize = 10;
        public string CreatePager(int pageIndex, int pageSize, int dataCount, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='pagination'>");

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }

            int pageCount = (int)Math.Ceiling((float)dataCount / pageSize);

            int start = Math.Max(1, pageIndex - TotalSize / 2); //pageIndex <= centerRadio ? pageIndex : (pageIndex + 1) - centerRadio;
            int end = Math.Min(pageCount, (start - 1) + TotalSize);

            for (int i = start; i < end; i++)
            {
                sb.Append("<li><a href='#'>1</a></li>");
            }


            sb.Append("</ul>");
            return sb.ToString();
        }

    }
}
