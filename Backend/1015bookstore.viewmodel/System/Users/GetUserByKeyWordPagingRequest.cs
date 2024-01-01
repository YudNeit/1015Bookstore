using _1015bookstore.viewmodel.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class GetUserByKeyWordPagingRequest : PagingRequestBase
    {
        public string? sKeyword { get; set; }
    }
}
