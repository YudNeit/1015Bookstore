using _1015bookstore.application.Common;
using _1015bookstore.application.Helper;
using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Carts;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace _1015bookstore.application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly _1015DbContext _context;
        private readonly IStorageService _storageService;
        private readonly IRemoveUnicode _removeUnicode;

        public ManageProductService(_1015DbContext context, IStorageService storageService, IRemoveUnicode removeUnicode)
        {
            _context = context;
            _storageService = storageService;
            _removeUnicode = removeUnicode;
        }

        public async Task AddViewcount(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new _1015Exception($"Cannot find a product with id: {id}");

            product.view_count += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                name = request.name,
                alias = _removeUnicode.Removeunicode(request.name),
                price = request.price,
                start_count = 0,
                review_count = 0,
                buy_count = 0,
                flashsale = false,
                like_count = 0,
                waranty = request.waranty,
                quanity = request.quanity,
                view_count = 0,
                description = request.description,
                brand = request.brand == null ? "" : request.brand,
                madein = request.madein == null ? "" : request.madein,
                mfgdate = request.mfgdate,
                suppiler = request.suppiler == null ? "" : request.suppiler,
                author = request.author == null ? "" : request.author,
                nop = request.nop == null ? "" : request.nop,
                yop = request.yop,
                createdby = "Hệ thống",
                datecreated = DateTime.Now,
                updatedby = "Hệ thống",
                dateupdated = DateTime.Now,
                status = ProductStatus.Normal
            };

            //Save image
            if (request.ThumbnailImage != null)
            {
                product.productimages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        caption = "Thumbnail image",
                        createdate = DateTime.Now,
                        sizeimage = request.ThumbnailImage.Length,
                        imagepath = await this.SaveFile(request.ThumbnailImage),
                        is_default = true,
                        sortorder = 1
                    }
                };
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.id;
        }

        public async Task<int> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) throw new _1015Exception($"Cannot find a product with id: {id}");

            var images = _context.ProductImages.Where(i => i.product_id == id);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.imagepath);
            }

            product.status = ProductStatus.Delete;

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategory on p.id equals pic.product_id
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where p.status != ProductStatus.Delete
                        select new { p, pic, pimg };

            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.p.name.Contains(request.keyword));
            if (request.categoryids.Count > 0)
            {
                query = query.Where(p => request.categoryids.Contains(p.pic.category_id));
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
                pathThumbnailImage = x.pimg.imagepath
            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                totalrecord = totalRow,
                items = data
            };
            return pagedResult;
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var query = from p in _context.Products
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where p.status != ProductStatus.Delete
                        select new { p, pimg };

            var product = await query.FirstOrDefaultAsync(x => x.p.id == id);

            if (product == null) throw new _1015Exception($"Cannot find a product with id: {id}");

            var data =  new ProductViewModel
            {
                id = product.p.id,
                name = product.p.name,
                price = product.p.price,
                start_count = product.p.start_count,
                review_count = product.p.review_count,
                buy_count = product.p.buy_count,
                flashsale = product.p.flashsale,
                like_count = product.p.like_count,
                waranty = product.p.waranty,
                quanity = product.p.quanity,
                view_count = product.p.view_count,
                description = product.p.description,
                brand = product.p.brand,
                madein = product.p.madein,
                mfgdate = product.p.mfgdate,
                supplier = product.p.suppiler,
                author = product.p.author,
                nop = product.p.nop,
                yop = product.p.yop,
                status = product.p.status,
                pathThumbnailImage = product.pimg == null ? null : product.pimg.imagepath,
            };
            return data;
        }

        public async Task<bool> UpdataQuanity(int id, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new _1015Exception($"Cannot find a product with id: {id}");
            if (product.quanity + addedQuantity >= 1)
                product.quanity += addedQuantity;
            else
            {
                product.quanity = 0;
                product.status = ProductStatus.OOS;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.id);

            if (product == null) throw new _1015Exception($"Cannot find a product with id: {request.id}");

            product.name = request.name;
            product.price = request.price;
            product.waranty = request.waranty;
            product.quanity = request.quanity;
            product.description = request.description;
            product.brand = request.brand == null ? "" : request.brand;
            product.madein = request.madein == null ? "" : request.madein;
            product.mfgdate = request.mfgdate;
            product.suppiler = request.suppiler == null ? "" : request.suppiler;
            product.author = request.author == null ? "" : request.author;
            product.nop = request.nop == null ? "" : request.nop;
            product.yop = request.yop;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.is_default == true && i.product_id == request.id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.sizeimage = request.ThumbnailImage.Length;
                    thumbnailImage.imagepath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int id, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new _1015Exception($"Cannot find a product with id: {id}");
            product.price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
