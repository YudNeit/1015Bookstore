using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.viewmodel.Comon;
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
        public async Task<ResponseService<CategoryViewModel>> Cate_Create(CategoryCreateRequest request, Guid ?creator_id)
        {
            string creator_username;
            if (creator_id == null) {
                creator_username = "Hệ thống";
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == creator_id);
                if (user == null)
                    return new ResponseService<CategoryViewModel>
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = $"Can not find user with id: {creator_id}"
                    };
                else 
                    creator_username = user.UserName;
            }    

            var cate = new Category
            {
                name = request.sCate_name,
                categoryparentid = request.iCate_parent_id == null ? 0 : request.iCate_parent_id,
                createdby = creator_username,
                datecreated = DateTime.Now,
                updatedby = creator_username,
                dateupdated = DateTime.Now,
                status = CategoryStatus.Normal,
                show = CategoryShow.None,
            };
            _context.Categories.Add(cate);
            await _context.SaveChangesAsync();
            return new ResponseService<CategoryViewModel> { 
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = new CategoryViewModel
                {
                    iCate_id = cate.id,
                    sCate_name = cate.name,
                    iCate_parent_id = cate.categoryparentid,
                    stCate_status = cate.status,
                    stCate_show = cate.show,
                },
            };
        }

        public async Task<ResponseService> Cate_Delete(int id, Guid? updater_id)
        {
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

            var cate = await _context.Categories.FindAsync(id);

            if (cate == null)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a categoy with id: {id}"
                };

            cate.status = CategoryStatus.Delete;
            cate.dateupdated = DateTime.Now;
            cate.updatedby = updater_username;

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
                Message = $"Cannot delete a category with id: {id}",
            };
        }

        public async Task<ResponseService> Cate_ChangeParent(int id, int parent_id, Guid? updater_id)
        {
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

            var cate = await _context.Categories.FindAsync(id);

            if (cate == null)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a categoy with id: {id}"
                };

            cate.categoryparentid = parent_id;
            cate.dateupdated = DateTime.Now;
            cate.updatedby = updater_username;

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
                Message = $"Cannot change parent id a category with id: {id}",
            };
        }

        public async Task<ResponseService<List<CategoryParentAndChildViewModel>>> Cate_GetAll()
        {
            var data = await _context.Categories.Where(x => x.categoryparentid == 0).Select(e => new CategoryParentAndChildViewModel
            {
                iCate_id = e.id,
                sCate_name = e.name,
                iCate_parent_id = e.categoryparentid,
                stCate_status = e.status,
                stCate_show = e.show,
                lCate_childs = _context.Categories.Where(x => x.categoryparentid == e.id).Select(x => new CategoryViewModel { 
                    iCate_id = x.id,
                    sCate_name = x.name,
                    iCate_parent_id = x.categoryparentid,
                    stCate_status = x.status,
                    stCate_show = x.show,
                }).ToList(),
            }).ToListAsync();
            return new ResponseService<List<CategoryParentAndChildViewModel>> {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }

        public async Task<ResponseService> Cate_Update(CategoryUpdateRequest request, Guid? updater_id)
        {
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

            var cate = await _context.Categories.FindAsync(request.iCate_id);

            if (cate == null)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Cannot find a categoy with id: {request.iCate_id}"
                };

            cate.name = request.sCate_name;
            cate.categoryparentid = request.iCate_parent_id;
            cate.dateupdated = DateTime.Now;
            cate.updatedby = updater_username;

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
                Message = $"Cannot update a category with id: {request.iCate_id}",
            };

        }
    
        public async Task<ResponseService<List<CategoryViewModel>>> Cate_GetParent()
        {
            var data = await _context.Categories.Where(x => x.categoryparentid == 0).Select(e => new CategoryViewModel
            {
                iCate_id = e.id,
                sCate_name = e.name,
                iCate_parent_id = e.categoryparentid,
                stCate_status = e.status,
                stCate_show = e.show,
            }).ToListAsync();
            return new ResponseService<List<CategoryViewModel>>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }
        public async Task<ResponseService<List<CategoryParentAndChildViewModel>>> Cate_GetTaskbar()
        {
            var data = await _context.Categories.Where(x => x.categoryparentid == 0 && x.show == CategoryShow.Taskbar).Select(e => new CategoryParentAndChildViewModel
            {
                iCate_id = e.id,
                sCate_name = e.name,
                iCate_parent_id = e.categoryparentid,
                stCate_status = e.status,
                stCate_show = e.show,
                lCate_childs = _context.Categories.Where(x => x.categoryparentid == e.id && x.show == CategoryShow.Taskbar).Select(x => new CategoryViewModel
                {
                    iCate_id = x.id,
                    sCate_name = x.name,
                    iCate_parent_id = x.categoryparentid,
                    stCate_status = x.status,
                    stCate_show = x.show,
                }).ToList(),
            }).ToListAsync();
            return new ResponseService<List<CategoryParentAndChildViewModel>>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }
    }
}
