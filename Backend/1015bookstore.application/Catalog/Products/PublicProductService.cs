using _1015bookstore.data.EF;
using _1015bookstore.data.Enums;
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
            var query = from p in _context.Products
                        join pic in _context.ProductInCategory on p.id equals pic.product_id
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where p.status != ProductStatus.Delete
                        select new { p, pic, pimg };

            var data = await query.Select(e => new ProductViewModel
            {
                id = e.p.id,
                name = e.p.name,
                price = e.p.price,
                start_count = e.p.start_count,
                review_count = e.p.review_count,
                buy_count = e.p.buy_count,
                flashsale = e.p.flashsale,
                like_count = e.p.like_count,
                waranty = e.p.waranty,
                quanity = e.p.quanity,
                view_count = e.p.view_count,
                description = e.p.description,
                brand = e.p.brand,
                madein = e.p.madein,
                mfgdate = e.p.mfgdate,
                supplier = e.p.suppiler,
                author = e.p.author,
                nop = e.p.nop,
                yop = e.p.yop,
                status = e.p.status,
                pathThumbnailImage = e.pimg.imagepath
            }).ToListAsync();
            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategory on p.id equals pic.product_id
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where p.status != ProductStatus.Delete
                        select new { p, pic, pimg };

            if (request.category_ids.Count > 0)
            {
                query = query.Where(p => request.category_ids.Contains(p.pic.category_id));
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
                status = x.p.status,
                pathThumbnailImage = x.pimg.imagepath,
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
