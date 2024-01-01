using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Comon
{
    public class PagedResultBase
    {
        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        public int totalRecords { get; set; }

        public int pageCount
        {
            get
            {
                var pageCount = (double)totalRecords / pageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
