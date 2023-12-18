using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly _1015DbContext _context;

        public CategoryService(_1015DbContext context) 
        {
            _context = context;
        }
        public async Task<int> Create(CategoryCreateRequest request)
        {
            var cate = new Category
            {
                name = request.name,
                categoryparentid = request.parent_id,
                createdby = "Hệ thống",
                datecreated = DateTime.Now,
                updatedby = "Hệ thống",
                dateupdated = DateTime.Now,
                status = CategoryStatus.Normal
            };
            _context.Categories.Add(cate);
            await _context.SaveChangesAsync();
            return cate.id;
        }

        public async Task<int> Delete(int id)
        {
            var cate = await _context.Categories.FindAsync(id);

            if (cate == null) throw new _1015Exception($"Cannot find a categoy with id: {id}");

            cate.status = CategoryStatus.Delete;

            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var data = await _context.Categories.Select(e => new CategoryViewModel
            {
                id = e.id,
                name = e.name,
                parent_id = e.categoryparentid,
                status = e.status,
            }).ToListAsync();
            return data;
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            var cate = await _context.Categories.FindAsync(id);

            if (cate == null) throw new _1015Exception($"Cannot find a categoy with id: {id}");

            var data = new CategoryViewModel
            {
                id = cate.id,
                name = cate.name,
                parent_id = cate.categoryparentid,
                status = cate.status,
            };
            return data;
        }

        public async Task<List<CategoryParentAndChildViewModel>> GetParentAndChildAll()
        {
            var data = await _context.Categories.Select(e => new CategoryParentAndChildViewModel
            {
                id = e.id,
                name = e.name,
                parent_id = e.categoryparentid,
                status = e.status,
                childCategories = _context.Categories.Where(x => x.categoryparentid == e.id).Select(x => new CategoryViewModel { 
                    id = x.id,
                    name = x.name,
                    parent_id = x.categoryparentid,
                    status = x.status,
                }).ToList(),
            }).ToListAsync();
            return data;
        }

        public async Task<CategoryParentAndChildViewModel> GetParentAndChildById(int id)
        {
            var cate = await _context.Categories.FindAsync(id);

            if (cate == null) throw new _1015Exception($"Cannot find a categoy with id: {id}");

            var data = new CategoryParentAndChildViewModel
            {
                id = cate.id,
                name = cate.name,
                parent_id = cate.categoryparentid,
                status = cate.status,
                childCategories = await _context.Categories.Where(x => x.categoryparentid == id).Select(x => new CategoryViewModel
                {
                    id = x.id,
                    name = x.name,
                    parent_id = x.categoryparentid,
                    status = x.status,
                }).ToListAsync(),
            };
            return data;
        }

        public async Task<int> Update(CategoryUpdateRequest request)
        {
            var cate = await _context.Categories.FindAsync(request.id);

            if (cate == null) throw new _1015Exception($"Cannot find a categoy with id: {request.id}");

            cate.name = request.name;
            cate.categoryparentid = request.parent_id;

            return await _context.SaveChangesAsync();

        }
    }
}
