using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.viewmodel.Catalog.Reviews;
using _1015bookstore.viewmodel.Comon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly _1015DbContext _context;

        public ReviewService(_1015DbContext context)
        {
            _context = context;
        }

        public async Task<ResponseService> Review_Create(ReviewRequestCreate request)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.id == request.iOrder_id);
            if (order == null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find order with id: {request.iOrder_id}"
                };

            if (order.isreview)
            {
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Review was written with order id: {request.iOrder_id}"
                };
            }


            order.isreview = true;

            foreach (var item in request.lReview_products)
            {
                var review = new Review
                { 
                   user_id = order.user_id,
                   product_id = item.iProduct_id,
                   content = item.sReview_content,
                   starts = item.iReview_start,
                   created_at = DateTime.Now,
                };
                await _context.Reviews.AddAsync(review);

                var product = await _context.Products.FirstOrDefaultAsync(x => x.id == item.iProduct_id);
                product.review_count += 1;
                product.start_count = (product.start_count * (product.review_count - 1) + item.iReview_start) / product.review_count;
            }

            if (await _context.SaveChangesAsync() >0)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = $"Success"
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Can not create review"
            };

        }
        
        public async Task<ResponseService<List<ReviewViewModel>>> Review_GetByProductId(int product_id)
        {

            var product = await _context.Products.FindAsync(product_id);

            if (product == null)
                return new ResponseService<List<ReviewViewModel>>()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a product with id: {product_id}",
                };

            var data = await _context.Reviews.Where(x => x.product_id == product_id).Select( x => new ReviewViewModel
            {
                sUser_username = _context.Users.FirstOrDefault(a => a.Id == x.user_id).UserName,
                iReview_start = x.starts,
                dtReview_date = x.created_at,
                sReview_content = x.content

            }).ToListAsync();

            return new ResponseService<List<ReviewViewModel>>()
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }
    }
}
