using _1015bookstore.viewmodel.Catalog.Reviews;
using _1015bookstore.viewmodel.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Reviews
{
    public interface IReviewService
    {
        Task<ResponseService> Review_Create(ReviewRequestCreate request);
        Task<ResponseService<List<ReviewViewModel>>> Review_GetByProductId(int product_id);
    }
}
