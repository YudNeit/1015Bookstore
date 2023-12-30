using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Comon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.ProductIsnCategories
{
    public class ProductInCategoryService : IProductInCategoryService
    {
        private readonly _1015DbContext _context;

        public ProductInCategoryService(_1015DbContext context) 
        {
            _context = context;
        }
        public async Task<ResponseService> Create(int iProduct_id, int iCate_id)
        {
            var relation = await _context.ProductInCategory.FirstOrDefaultAsync(x => x.product_id == iProduct_id && x.category_id == iCate_id);
            if (relation != null)
                return new ResponseService { 
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Had a relation with product_id: {iProduct_id} and category_id: {iCate_id}"
                };
            
            var product = await _context.Products.FindAsync(iProduct_id);

            if (product == null)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a product with id: {iProduct_id}"
                };
          

            var cate = await _context.Categories.FindAsync(iCate_id);

            if (cate == null)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a category with id: {iCate_id}"
                };
           

            var data = new ProductInCategory
            {
                product_id = iProduct_id,
                category_id = iCate_id,
            };

            _context.ProductInCategory.Add(data);
            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = "Success"
                };
            }
            return new ResponseService
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Can not create relation with product_id: {iProduct_id} and category_id: {iCate_id}"
            };
        }

        public async Task<ResponseService> Delete(int iProduct_id, int iCate_id)
        {
            var relation = await _context.ProductInCategory.FirstOrDefaultAsync(x => x.product_id == iProduct_id && x.category_id == iCate_id);
            if (relation == null)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a relation with product_id: {iProduct_id} and category_id: {iCate_id}"
                };
            _context.ProductInCategory.Remove(relation);
            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = "Success"
                };
            }
            return new ResponseService
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Can not create relation with product_id: {iProduct_id} and category_id: {iCate_id}"
            };
        }
    }
}
