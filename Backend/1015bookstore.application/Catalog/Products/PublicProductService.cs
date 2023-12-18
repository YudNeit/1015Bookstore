using _1015bookstore.data.EF;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly _1015DbContext _context;

        public PublicProductService(_1015DbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductViewModel>> GetAll()
        {
            var data = await _context.Products.Select(e => new ProductViewModel
            {
                id = e.id,
                name = e.name,
                price = e.price,
                start_count = e.start_count,
                review_count = e.review_count,
                buy_count = e.buy_count,
                flashsale = e.flashsale,
                like_count = e.like_count,
                waranty = e.waranty,
                quanity = e.quanity,
                view_count = e.view_count,
                description = e.description,
                brand = e.brand,
                madein = e.madein,
                mfgdate = e.mfgdate,
                supplier = e.suppiler,
                author = e.author,
                nop = e.nop,
                yop = e.yop,
            }).ToListAsync();
            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategory on p.id equals pic.product_id
                        select new { p, pic};
            if (request.categoryid.HasValue && request.categoryid.Value > 0)
            {
                query = query.Where(p => request.categoryid == p.pic.category_id);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageindex - 1) * request.pagesize).Take(request.pagesize)
            .Select(x => new ProductViewModel()
            {
                id = x.p.id,
                name = x.p.name,
                price = x.p.price,
                start_count = x.p.start_count,
                review_count = x.p.review_count,
                buy_count = x.p.buy_count,
                flashsale = x.p.flashsale,
                like_count = x.p.like_count,
                waranty = x.p.waranty,
                quanity = x.p.quanity,
                view_count = x.p.view_count,
                description = x.p.description,
                brand = x.p.brand,
                madein = x.p.madein,
                mfgdate = x.p.mfgdate,
                supplier = x.p.suppiler,
                author = x.p.author,
                nop = x.p.nop,
                yop = x.p.yop,
            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                totalrecord = totalRow,
                items = data
            };
            return pagedResult;
        }
    }
}
