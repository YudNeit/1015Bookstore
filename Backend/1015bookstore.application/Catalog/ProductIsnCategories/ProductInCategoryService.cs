using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.utility.Exceptions;
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
        public async Task<int> Create(int product_id, int category_id)
        {
            var relation = await _context.ProductInCategory.FirstOrDefaultAsync(x => x.product_id == product_id && x.category_id == category_id);
            if (relation != null) throw new _1015Exception($"Had a relation with product_id: {product_id} and category_id: {category_id}");
            
            var product = await _context.Products.FindAsync(product_id);

            if (product == null) throw new _1015Exception($"Cannot find a product with id: {product_id}");

            var cate = await _context.Categories.FindAsync(category_id);

            if (cate == null) throw new _1015Exception($"Cannot find a category with id: {category_id}");

            var data = new ProductInCategory
            {
                product_id = product_id,
                category_id = category_id,
            };

            _context.ProductInCategory.Add(data);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int product_id, int category_id)
        {
            var relation = await _context.ProductInCategory.FirstOrDefaultAsync(x => x.product_id == product_id && x.category_id == category_id);
            if (relation == null) throw new _1015Exception($"Cannot find a relation with product_id: {product_id} and category_id: {category_id}");
            _context.ProductInCategory.Remove(relation);
            return await _context.SaveChangesAsync();
        }
    }
}
