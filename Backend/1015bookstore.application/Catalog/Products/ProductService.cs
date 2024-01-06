using _1015bookstore.application.Common;
using _1015bookstore.application.Helper;
using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Carts;
using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace _1015bookstore.application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly _1015DbContext _context;
        private readonly IStorageService _storageService;
        private readonly IRemoveUnicode _removeUnicode;

        public ProductService(_1015DbContext context, IStorageService storageService, IRemoveUnicode removeUnicode)
        {
            _context = context;
            _storageService = storageService;
            _removeUnicode = removeUnicode;
        }

        public async Task<ResponseService<ProductViewModel>> Product_Create(ProductCreateRequest request, Guid? creator_id)
        {
            string creator_username;
            if (creator_id == null)
            {
                creator_username = "Hệ thống";
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == creator_id);
                if (user == null)
                    return new ResponseService<ProductViewModel>
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = $"Can not find user with id: {creator_id}"
                    };
                else
                    creator_username = user.UserName;
            }

            var product = new Product()
            {
                name = request.sProduct_name,
                alias = _removeUnicode.Removeunicode(request.sProduct_name),
                price = request.vProduct_price,
                start_count = 0,
                review_count = 0,
                buy_count = 0,
                flashsale = false,
                like_count = 0,
                waranty = request.iProduct_waranty,
                quanity = 0,
                view_count = 0,
                description = request.sProduct_description,
                brand = request.sProduct_brand,
                madein = request.sProduct_madein,
                mfgdate = request.dtProduct_mfgdate,
                suppiler = request.sProduct_supplier,
                author = request.sProduct_author,
                nop = request.sProduct_nop,
                yop = request.iProduct_yop,
                createdby = creator_username,
                datecreated = DateTime.Now,
                updatedby = creator_username,
                dateupdated = DateTime.Now,
                status = ProductStatus.OOS
            };

            
            ProductImage productImage = null;

            //Save image
            if (request.sImage_pathThumbnail != null)
            {
                
                productImage = new ProductImage()
                {
                    caption = "Thumbnail image",
                    createdate = DateTime.Now,
                    sizeimage = request.sImage_pathThumbnail.Length,
                    imagepath = await this.SaveFile(request.sImage_pathThumbnail),
                    is_default = true,
                    sortorder = 1
                };

                product.productimages = new List<ProductImage>()
                {
                    productImage
                };
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return new ResponseService<ProductViewModel>
            {
                CodeStatus = 201,
                Status = true,
                Message = "Success",
                Data = new ProductViewModel
                {
                    iProduct_id = product.id,
                    sProduct_name = product.name,
                    vProduct_price = product.price,
                    dProduct_start_count = product.start_count,
                    iProduct_review_count = product.review_count,
                    iProduct_buy_count = product.buy_count,
                    bProduct_flashsale = product.flashsale,
                    iProduct_like_count = product.like_count,
                    iProduct_waranty = product.waranty,
                    iProduct_quantity = product.quanity,
                    iProduct_view_count = product.view_count,
                    sProduct_description = product.description,
                    sProduct_brand = product.brand,
                    sProduct_madein = product.madein,
                    dtProduct_mfgdate = product.mfgdate,
                    sProduct_supplier = product.suppiler,
                    sProduct_author = product.author,
                    sProduct_nop = product.nop,
                    iProduct_yop = product.yop,
                    stProduct_status = product.status,
                    sImage_pathThumbnail = productImage == null ? null : productImage.imagepath,
                },
            };
        
        }

        public async Task<ResponseService<List<CategoryViewModel>>> Product_GetCategory(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return new ResponseService<List<CategoryViewModel>>()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a product with id: {id}",
                };
            var a = _context.ProductInCategory.Where(x => x.product_id == id).Select(x=>x.category_id).ToList();

            var categories = await _context.Categories.Where(x => a.Contains(x.id) && x.status == CategoryStatus.Normal && x.show == CategoryShow.Taskbar).Select(x => new CategoryViewModel { 
                iCate_id = x.id,
                sCate_name = x.name,
                iCate_parent_id = x.categoryparentid,
                stCate_show = x.show,
                stCate_status = x.status,
            }).ToListAsync();
            return new ResponseService<List<CategoryViewModel>>()
            {
                CodeStatus= 200,
                Status = true,
                Message = "Success",
                Data = categories
            };
        }    

        public async Task<ResponseService> Product_Delete(int id, Guid? updater_id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) throw new _1015Exception($"Cannot find a product with id: {id}");

            string updater_username;
            if (updater_id == null)
            {
                updater_username = "Hệ thống";
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updater_id);
                if (user == null)
                    return new ResponseService
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = $"Can not find user with id: {updater_id}"
                    };
                else
                    updater_username = user.UserName;
            }

            product.dateupdated = DateTime.Now;
            product.updatedby = updater_username;

            product.status = ProductStatus.Delete;

            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = "Success",
                };
            }
            return new ResponseService
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Cannot update a promotional code with id: {id}",
            };
        }

        public async Task<ResponseService> Product_Update(ProductUpdateRequest request, Guid? updater_id)
        {
            var product = await _context.Products.FindAsync(request.iProduct_id);

            if (product == null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a product with id: {request.iProduct_id}",
                };

            product.name = request.sProduct_name;
            product.price = request.vProduct_price;
            product.waranty = request.iProduct_waranty;
            product.description = request.sProduct_description;
            product.brand = request.sProduct_brand;
            product.madein = request.sProduct_madein;
            product.mfgdate = request.dtProduct_mfgdate;
            product.suppiler = request.sProduct_supplier;
            product.author = request.sProduct_author;
            product.nop = request.sProduct_nop;
            product.yop = request.iProduct_yop;
            product.status = request.stProduct_status;

            //Save image
            if (request.sImage_pathThumbnail != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.is_default == true && i.product_id == request.iProduct_id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.sizeimage = request.sImage_pathThumbnail.Length;
                    thumbnailImage.imagepath = await this.SaveFile(request.sImage_pathThumbnail);
                    _context.ProductImages.Update(thumbnailImage);
                }
                else
                {
                    ProductImage productImage = new ProductImage()
                    {
                        caption = "Thumbnail image",
                        createdate = DateTime.Now,
                        sizeimage = request.sImage_pathThumbnail.Length,
                        imagepath = await this.SaveFile(request.sImage_pathThumbnail),
                        is_default = true,
                        sortorder = 1
                    };
                    product.productimages = new List<ProductImage>()
                        {
                            productImage
                        };
                }    
            }

            string updater_username;
            if (updater_id == null)
            {
                updater_username = "Hệ thống";
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updater_id);
                if (user == null)
                    return new ResponseService
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = $"Can not find user with id: {updater_id}"
                    };
                else
                    updater_username = user.UserName;
            }

            product.dateupdated = DateTime.Now;
            product.updatedby = updater_username;

            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = $"Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Cannot update a product with id: {request.iProduct_id}",
            };
        }

        public async Task<ResponseService> Product_UpdateQuantity(int id, int addedQuantity, decimal price, Guid? updater_id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a product with id: {id}",
                };
            
            if (addedQuantity <=0)
            {
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Vui lòng nhập số lượng lớn hơn 0",
                };
            }

            if (product.status == ProductStatus.OOS)
            {
                product.status = ProductStatus.Normal;
            }

            product.quanity += addedQuantity;

            string updater_username;
            if (updater_id == null)
            {
                updater_username = "Hệ thống";
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updater_id);
                if (user == null)
                    return new ResponseService
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = $"Can not find user with id: {updater_id}"
                    };
                else
                    updater_username = user.UserName;
            }

            product.dateupdated = DateTime.Now;
            product.updatedby = updater_username;

            var report = new ReportData { 
                product_id = product.id,
                price = price,
                amount = addedQuantity,
                status = true,
                time = DateTime.Now,
            };
            await _context.ReportDatas.AddAsync(report);

            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = $"Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Cannot update a product with id: {id}",
            };
        }

        public async Task<ResponseService> Product_UpdatePrice(int id, decimal newPrice, Guid? updater_id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a product with id: {id}",
                };
            product.price = newPrice;

            string updater_username;
            if (updater_id == null)
            {
                updater_username = "Hệ thống";
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updater_id);
                if (user == null)
                    return new ResponseService
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = $"Can not find user with id: {updater_id}"
                    };
                else
                    updater_username = user.UserName;
            }

            product.dateupdated = DateTime.Now;
            product.updatedby = updater_username;

            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = $"Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Cannot update a product with id: {id}",
            };
        }
        
        public async Task<ResponseService> Product_AddViewcount(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a product with id: {id}",
                };

            product.view_count += 1;

            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = $"Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Cannot update a product with id: {id}",
            };
        }

        public async Task<ResponseService<ProductViewModel>> Product_GetById(int id)
        {
            var query = from p in _context.Products
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        select new { p, pimg };

            var product = await query.FirstOrDefaultAsync(x => x.p.id == id);

            if (product == null)
                return new ResponseService<ProductViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a product with id: {id}",
                };

            var data = new ProductViewModel
            {
                iProduct_id = product.p.id,
                sProduct_name = product.p.name,
                vProduct_price = product.p.price,
                dProduct_start_count = product.p.start_count,
                iProduct_review_count = product.p.review_count,
                iProduct_buy_count = product.p.buy_count,
                bProduct_flashsale = product.p.flashsale,
                iProduct_like_count = product.p.like_count,
                iProduct_waranty = product.p.waranty,
                iProduct_quantity = product.p.quanity,
                iProduct_view_count = product.p.view_count,
                sProduct_description = product.p.description,
                sProduct_brand = product.p.brand,
                sProduct_madein = product.p.madein,
                dtProduct_mfgdate = product.p.mfgdate,
                sProduct_supplier = product.p.suppiler,
                sProduct_author = product.p.author,
                sProduct_nop = product.p.nop,
                iProduct_yop = product.p.yop,
                stProduct_status = product.p.status,
                sImage_pathThumbnail = product.pimg == null ? null : product.pimg.imagepath,
            };

            return new ResponseService<ProductViewModel>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data,
            };
        }


        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsyncFE_user(file.OpenReadStream(), fileName);
            await _storageService.SaveFileAsyncFE_admin(file.OpenReadStream(), fileName);
            return fileName;
        }


        public async Task<PagedResult<ProductViewModel>> Product_GetProductByKeyWordPagingPublic(GetProductByKeyWordPagingRequest request)
        {
            var query = from p in _context.Products
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where p.status != ProductStatus.Delete
                        select new { p, pimg };

            if (!string.IsNullOrEmpty(request.sKeyword))
                query = query.Where(x => x.p.alias.Contains(_removeUnicode.Removeunicode(request.sKeyword)));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageindex - 1) * request.pagesize).Take(request.pagesize)
            .Select(x => new ProductViewModel()
            {
                iProduct_id = x.p.id,
                sProduct_name = x.p.name,
                vProduct_price = x.p.price,
                dProduct_start_count = x.p.start_count,
                iProduct_review_count = x.p.review_count,
                iProduct_buy_count = x.p.buy_count,
                bProduct_flashsale = x.p.flashsale,
                iProduct_like_count = x.p.like_count,
                iProduct_waranty = x.p.waranty,
                iProduct_quantity = x.p.quanity,
                iProduct_view_count = x.p.view_count,
                sProduct_description = x.p.description,
                sProduct_brand = x.p.brand,
                sProduct_madein = x.p.madein,
                dtProduct_mfgdate = x.p.mfgdate,
                sProduct_supplier = x.p.suppiler,
                sProduct_author = x.p.author,
                sProduct_nop = x.p.nop,
                iProduct_yop = x.p.yop,
                stProduct_status = x.p.status,
                sImage_pathThumbnail = x.pimg.imagepath,
            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                totalRecords = totalRow,
                pageIndex = request.pageindex,
                pageSize = request.pagesize,
                items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<ProductViewModel>> Product_GetProductByCategoryPagingPublic(GetProductByCategoryPagingRequest request)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategory on p.id equals pic.product_id
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where p.status != ProductStatus.Delete
                        select new { p, pic, pimg };

            if (request.lCate_ids.Count > 0)
            {
                query = query.Where(p => request.lCate_ids.Contains(p.pic.category_id));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageindex - 1) * request.pagesize).Take(request.pagesize)
            .Select(x => new ProductViewModel()
            {
                iProduct_id = x.p.id,
                sProduct_name = x.p.name,
                vProduct_price = x.p.price,
                dProduct_start_count = x.p.start_count,
                iProduct_review_count = x.p.review_count,
                iProduct_buy_count = x.p.buy_count,
                bProduct_flashsale = x.p.flashsale,
                iProduct_like_count = x.p.like_count,
                iProduct_waranty = x.p.waranty,
                iProduct_quantity = x.p.quanity,
                iProduct_view_count = x.p.view_count,
                sProduct_description = x.p.description,
                sProduct_brand = x.p.brand,
                sProduct_madein = x.p.madein,
                dtProduct_mfgdate = x.p.mfgdate,
                sProduct_supplier = x.p.suppiler,
                sProduct_author = x.p.author,
                sProduct_nop = x.p.nop,
                iProduct_yop = x.p.yop,
                stProduct_status = x.p.status,
                sImage_pathThumbnail = x.pimg.imagepath,
            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                totalRecords = totalRow,
                pageIndex = request.pageindex,
                pageSize = request.pagesize,
                items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<ProductViewModel>> Product_GetProductByKeyWordPagingAdmin(GetProductByKeyWordPagingRequest request)
        {
            var query = from p in _context.Products
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        select new { p, pimg };

            if (!string.IsNullOrEmpty(request.sKeyword))
                query = query.Where(x => x.p.alias.Contains(_removeUnicode.Removeunicode(request.sKeyword)));

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageindex - 1) * request.pagesize).Take(request.pagesize)
            .Select(x => new ProductViewModel()
            {
                iProduct_id = x.p.id,
                sProduct_name = x.p.name,
                vProduct_price = x.p.price,
                dProduct_start_count = x.p.start_count,
                iProduct_review_count = x.p.review_count,
                iProduct_buy_count = x.p.buy_count,
                bProduct_flashsale = x.p.flashsale,
                iProduct_like_count = x.p.like_count,
                iProduct_waranty = x.p.waranty,
                iProduct_quantity = x.p.quanity,
                iProduct_view_count = x.p.view_count,
                sProduct_description = x.p.description,
                sProduct_brand = x.p.brand,
                sProduct_madein = x.p.madein,
                dtProduct_mfgdate = x.p.mfgdate,
                sProduct_supplier = x.p.suppiler,
                sProduct_author = x.p.author,
                sProduct_nop = x.p.nop,
                iProduct_yop = x.p.yop,
                stProduct_status = x.p.status,
                sImage_pathThumbnail = x.pimg.imagepath,
            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                totalRecords = totalRow,
                pageIndex = request.pageindex,
                pageSize = request.pagesize,
                items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<ProductViewModel>> Product_GetProductByCategoryPagingAdmin(GetProductByCategoryPagingRequest request)
        {
            var query = from p in _context.Products
                        join pic in _context.ProductInCategory on p.id equals pic.product_id
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        select new { p, pic, pimg };

            if (request.lCate_ids.Count > 0)
            {
                query = query.Where(p => request.lCate_ids.Contains(p.pic.category_id));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageindex - 1) * request.pagesize).Take(request.pagesize)
            .Select(x => new ProductViewModel()
            {
                iProduct_id = x.p.id,
                sProduct_name = x.p.name,
                vProduct_price = x.p.price,
                dProduct_start_count = x.p.start_count,
                iProduct_review_count = x.p.review_count,
                iProduct_buy_count = x.p.buy_count,
                bProduct_flashsale = x.p.flashsale,
                iProduct_like_count = x.p.like_count,
                iProduct_waranty = x.p.waranty,
                iProduct_quantity = x.p.quanity,
                iProduct_view_count = x.p.view_count,
                sProduct_description = x.p.description,
                sProduct_brand = x.p.brand,
                sProduct_madein = x.p.madein,
                dtProduct_mfgdate = x.p.mfgdate,
                sProduct_supplier = x.p.suppiler,
                sProduct_author = x.p.author,
                sProduct_nop = x.p.nop,
                iProduct_yop = x.p.yop,
                stProduct_status = x.p.status,
                sImage_pathThumbnail = x.pimg.imagepath,
            }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                totalRecords = totalRow,
                pageIndex = request.pageindex,
                pageSize = request.pagesize,
                items = data
            };
            return pagedResult;
        }

        public async Task<ResponseService<List<ProductViewModel>>> Product_GetProductNotInCate(int cate_id)
        {
            var cate = await _context.Categories.FindAsync(cate_id);

            if (cate == null)
                return new ResponseService<List<ProductViewModel>>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a categoy with id: {cate_id}"
                };

            var product_ids = await _context.ProductInCategory.Where(x => x.category_id == cate_id).Select(x => x.product_id).ToListAsync();
            var query = from p in _context.Products
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where p.status == ProductStatus.Normal && !product_ids.Contains(p.id)
                        select new { p, pimg };
            var data = await query.Select(x => new ProductViewModel()
            {
                iProduct_id = x.p.id,
                sProduct_name = x.p.name,
                vProduct_price = x.p.price,
                dProduct_start_count = x.p.start_count,
                iProduct_review_count = x.p.review_count,
                iProduct_buy_count = x.p.buy_count,
                bProduct_flashsale = x.p.flashsale,
                iProduct_like_count = x.p.like_count,
                iProduct_waranty = x.p.waranty,
                iProduct_quantity = x.p.quanity,
                iProduct_view_count = x.p.view_count,
                sProduct_description = x.p.description,
                sProduct_brand = x.p.brand,
                sProduct_madein = x.p.madein,
                dtProduct_mfgdate = x.p.mfgdate,
                sProduct_supplier = x.p.suppiler,
                sProduct_author = x.p.author,
                sProduct_nop = x.p.nop,
                iProduct_yop = x.p.yop,
                stProduct_status = x.p.status,
                sImage_pathThumbnail = x.pimg.imagepath,
            }).ToListAsync();
            return new ResponseService<List<ProductViewModel>>
            {
                CodeStatus = 200,
                Message = "Success",
                Status = true,
                Data = data
            };
        }
        public async Task<ResponseService<List<ProductViewModel>>> Product_GetAllPublic()
        {
            var query = from p in _context.Products
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where p.status == ProductStatus.Normal
                        select new { p, pimg };
            var data = await query.Select(x => new ProductViewModel()
            {
                iProduct_id = x.p.id,
                sProduct_name = x.p.name,
                vProduct_price = x.p.price,
                dProduct_start_count = x.p.start_count,
                iProduct_review_count = x.p.review_count,
                iProduct_buy_count = x.p.buy_count,
                bProduct_flashsale = x.p.flashsale,
                iProduct_like_count = x.p.like_count,
                iProduct_waranty = x.p.waranty,
                iProduct_quantity = x.p.quanity,
                iProduct_view_count = x.p.view_count,
                sProduct_description = x.p.description,
                sProduct_brand = x.p.brand,
                sProduct_madein = x.p.madein,
                dtProduct_mfgdate = x.p.mfgdate,
                sProduct_supplier = x.p.suppiler,
                sProduct_author = x.p.author,
                sProduct_nop = x.p.nop,
                iProduct_yop = x.p.yop,
                stProduct_status = x.p.status,
                sImage_pathThumbnail = x.pimg.imagepath,
            }).ToListAsync();
            return new ResponseService<List<ProductViewModel>>
            {
                CodeStatus = 200,
                Message = "Success",
                Status = true,
                Data = data
            };

        }
        public async Task<ResponseService<List<ProductViewModel>>> Product_GetAllAdmin()
        {
            var query = from p in _context.Products
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        select new { p, pimg };

            var data = await query.Select(x => new ProductViewModel()
            {
                iProduct_id = x.p.id,
                sProduct_name = x.p.name,
                vProduct_price = x.p.price,
                dProduct_start_count = x.p.start_count,
                iProduct_review_count = x.p.review_count,
                iProduct_buy_count = x.p.buy_count,
                bProduct_flashsale = x.p.flashsale,
                iProduct_like_count = x.p.like_count,
                iProduct_waranty = x.p.waranty,
                iProduct_quantity = x.p.quanity,
                iProduct_view_count = x.p.view_count,
                sProduct_description = x.p.description,
                sProduct_brand = x.p.brand,
                sProduct_madein = x.p.madein,
                dtProduct_mfgdate = x.p.mfgdate,
                sProduct_supplier = x.p.suppiler,
                sProduct_author = x.p.author,
                sProduct_nop = x.p.nop,
                iProduct_yop = x.p.yop,
                stProduct_status = x.p.status,
                sImage_pathThumbnail = x.pimg.imagepath,
            }).ToListAsync();
            return new ResponseService<List<ProductViewModel>>
            {
                CodeStatus = 200,
                Message = "Success",
                Status = true,
                Data = data
            };
        }
        public async Task<ResponseService<List<ProductViewModel>>> Product_GetProductByKeywordAllPublic(string? sKeyword)
        {
            var query = from p in _context.Products
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        select new { p, pimg };

            if (!string.IsNullOrEmpty(sKeyword))
                query = query.Where(x => x.p.alias.Contains(_removeUnicode.Removeunicode(sKeyword)));
            
            var data = await query.Select(x => new ProductViewModel()
            {
                iProduct_id = x.p.id,
                sProduct_name = x.p.name,
                vProduct_price = x.p.price,
                dProduct_start_count = x.p.start_count,
                iProduct_review_count = x.p.review_count,
                iProduct_buy_count = x.p.buy_count,
                bProduct_flashsale = x.p.flashsale,
                iProduct_like_count = x.p.like_count,
                iProduct_waranty = x.p.waranty,
                iProduct_quantity = x.p.quanity,
                iProduct_view_count = x.p.view_count,
                sProduct_description = x.p.description,
                sProduct_brand = x.p.brand,
                sProduct_madein = x.p.madein,
                dtProduct_mfgdate = x.p.mfgdate,
                sProduct_supplier = x.p.suppiler,
                sProduct_author = x.p.author,
                sProduct_nop = x.p.nop,
                iProduct_yop = x.p.yop,
                stProduct_status = x.p.status,
                sImage_pathThumbnail = x.pimg.imagepath,
            }).ToListAsync();
            return new ResponseService<List<ProductViewModel>>
            {
                CodeStatus = 200,
                Message = "Success",
                Status = true,
                Data = data
            };
        }    
    }
}
