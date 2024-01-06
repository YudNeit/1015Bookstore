using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
using _1015bookstore.viewmodel.Comon;
using Microsoft.EntityFrameworkCore;

namespace _1015bookstore.application.Catalog.PromotionalCodes
{
    public class PromotionalCodeService : IPromotionalCodeService
    {
        private readonly _1015DbContext _context;

        public PromotionalCodeService(_1015DbContext context)
        {
            _context = context;
        }
        public async Task<ResponseService<PromotionalCodeViewModel>> PromotionalCode_Create(PromotionalCodeCreateRequest request, Guid? creator_id)
        {
            var promotionalCode = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == request.sPromotionalCode_code);
            if (promotionalCode != null)
            {
                return new ResponseService<PromotionalCodeViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Code {request.sPromotionalCode_name} is existed"
                };
            }

            string creator_username;
            if (creator_id == null)
            {
                creator_username = "Hệ thống";
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == creator_id);
                if (user == null)
                    return new ResponseService<PromotionalCodeViewModel>
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = $"Can not find user with id: {creator_id}"
                    };
                else
                    creator_username = user.UserName;
            }

            var code = new PromotionalCode
            {
                code = request.sPromotionalCode_code,
                name = request.sPromotionalCode_name,
                description = request.sPromotionalCode_description,
                discount_rate = request.iPromotionalCode_discount_rate,
                amount = request.iPromotionalCode_amount,
                fromdate = request.dtPromotionalCode_fromdate,
                todate = request.dtPromotionalCode_todate,

                createdby = creator_username,
                datecreated = DateTime.Now,
                updatedby = creator_username,
                dateupdated = DateTime.Now,
                status = PromotionalCodeStatus.Active,
            };
            await _context.PromotionCodes.AddAsync(code);
            await _context.SaveChangesAsync();
            return new ResponseService<PromotionalCodeViewModel>
            {
                CodeStatus = 201,
                Status = true,
                Message = "Success",
                Data = new PromotionalCodeViewModel
                {
                    iPromotionalCode_id = code.id,
                    sPromotionalCode_code = code.code,
                    sPromotionalCode_name = code.name,
                    sPromotionalCode_description = code.description,
                    iPromotionalCode_discount_rate = code.discount_rate,
                    iPromotionalCode_amount = code.amount,
                    dtPromotionalCode_fromdate = code.fromdate,
                    dtPromotionalCode_todate = code.todate,
                    stPromotionalCode_status = code.status,
                }
            };
        }

        public async Task<ResponseService<List<PromotionalCodeViewModel>>> PromotionalCode_GetAll()
        {
            var data = await _context.PromotionCodes.Select(x => new PromotionalCodeViewModel
            {
                iPromotionalCode_id = x.id,
                sPromotionalCode_code = x.code,
                sPromotionalCode_name = x.name,
                sPromotionalCode_description = x.description,
                iPromotionalCode_discount_rate = x.discount_rate,
                iPromotionalCode_amount = x.amount,
                dtPromotionalCode_fromdate = x.fromdate,
                dtPromotionalCode_todate = x.todate,
                stPromotionalCode_status = x.status,
            }).ToListAsync();
            return new ResponseService<List<PromotionalCodeViewModel>> {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }

        public async Task<ResponseService> PromotionalCode_Delete(int id, Guid? updater_id)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.id == id);
            if (code == null)
            {
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find promotional code with id: {id}"
                };
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

            code.status = PromotionalCodeStatus.InActive;
            code.dateupdated = DateTime.Now;
            code.updatedby = updater_username;

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
                Message = $"Cannot delete a promotional code with id: {id}",
            };
           
        }

        public async Task<ResponseService> PromotionalCode_UpdataAmount(int id, Guid? updater_id, int addedamount)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.id == id);
            if (code == null)
            {
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find promotional code with id: {id}"
                };
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

            if (code.amount + addedamount >= 1)
                code.amount += addedamount;
            else
            {
                code.amount = 0;
                code.status = PromotionalCodeStatus.OOS;
            }

            code.dateupdated = DateTime.Now;
            code.updatedby = updater_username;

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

        public async Task<ResponseService> PromotionalCode_UpdataToDate(int id, Guid? updater_id, DateTime todate)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.id == id);
            if (code == null)
            {
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find promotional code with id: {id}"
                };
            }

            if (code.fromdate > todate)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Todate is less than Fromdate"
                };
            else
            {
                code.todate = todate;
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

            code.dateupdated = DateTime.Now;
            code.updatedby = updater_username;

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

        public async Task<ResponseService> PromotionalCode_Update(PromotionalCodeUpdateRequest request, Guid? updater_id)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.id == request.iPromotionalCode_id);
            if (code == null)
            {
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find promotional code with id: {request.iPromotionalCode_id}"
                };
            }

            var promotionalCode = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == request.sPromotionalCode_code);
            if (!((promotionalCode == null) || (promotionalCode != null && promotionalCode.code == code.code)))
            {
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Code {request.sPromotionalCode_code} is existed"
                };
            }    

            code.name = request.sPromotionalCode_name;
            code.description = request.sPromotionalCode_description;
            code.code = request.sPromotionalCode_code;
            code.discount_rate = request.iPromotionalCode_discount_rate;
            code.amount = request.iPromotionalCode_amount;
            code.fromdate = request.dtPromotionalCode_fromdate;
            code.todate = request.dtPromotionalCode_todate;
            code.status = request.stPromotionalCode_status;

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

            code.dateupdated = DateTime.Now;
            code.updatedby = updater_username;

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
                Message = $"Cannot update a promotional code with id: {request.iPromotionalCode_id}",
            };

        }

        public async Task<ResponseService<PromotionalCodeViewModel>> PromotionalCode_CheckCode(string stringcode, Guid user_id)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == stringcode);
            if (code == null)
            {
                return new ResponseService<PromotionalCodeViewModel> { 
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find promotional code with code: {stringcode}",
                };
            }
            if (DateTime.Now < code.fromdate)
            {
                return new ResponseService<PromotionalCodeViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Can not use code because the release date hasn't arrived yet",
                };
            }
            if (DateTime.Now > code.todate)
            {
                return new ResponseService<PromotionalCodeViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Can not use code because it has expired",
                };  
            }
            if (code.status == PromotionalCodeStatus.OOS)
            {
                return new ResponseService<PromotionalCodeViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Can not use code because it out of stock",
                };
            }

            var codeuse = await _context.UserUsePromotionalCode.FirstOrDefaultAsync(x => x.promotionalcode_id == code.id && x.user_id == user_id);
            if (codeuse != null) 
            {
                return new ResponseService<PromotionalCodeViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Can not use code because you used it",
                };
            }

            var data = new PromotionalCodeViewModel
            {
                iPromotionalCode_id = code.id,
                sPromotionalCode_code = code.code,
                sPromotionalCode_name = code.name,
                sPromotionalCode_description = code.description,
                iPromotionalCode_discount_rate = code.discount_rate,
                iPromotionalCode_amount = code.amount,
                dtPromotionalCode_fromdate = code.fromdate,
                dtPromotionalCode_todate = code.todate,
                stPromotionalCode_status = code.status,
            };

            return new ResponseService<PromotionalCodeViewModel>
            {
                CodeStatus = 200,
                Status =true,
                Message = "Success",
                Data = data
            };
        }

        public async Task<ResponseService<PromotionalCodeViewModel>> PromotionalCode_GetById(int id)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.id == id);
            if (code == null)
            {
                return new ResponseService<PromotionalCodeViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find promotional code with id: {id}",
                };
            }

            var data = new PromotionalCodeViewModel
            {
                iPromotionalCode_id = code.id,
                sPromotionalCode_code = code.code,
                sPromotionalCode_name = code.name,
                sPromotionalCode_description = code.description,
                stPromotionalCode_status = code.status,
                dtPromotionalCode_fromdate = code.fromdate,
                dtPromotionalCode_todate = code.todate,
                iPromotionalCode_amount = code.amount,
                iPromotionalCode_discount_rate = code.discount_rate,
            };
            return new ResponseService<PromotionalCodeViewModel>
            {
                CodeStatus = 200,
                Status = true,
                Data = data,
                Message = "Success"
            };
        }
    }
}
