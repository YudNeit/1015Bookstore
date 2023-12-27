using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
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
        public async Task<ResponseService<PromotionalCodeViewModel>> CreatePromotionalCode(PromotionalCodeCreateRequest request)
        {
            var promotionalCode = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == request.code);
            if (promotionalCode != null)
            {
                return new ResponseService<PromotionalCodeViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Code {request.code} is existed"
                };
            }

            var code = new PromotionalCode
            {
                code = request.code,
                name = request.name,
                description = request.description,
                discount_rate = request.discount_rate,
                amount = request.amount,
                fromdate = request.fromdate,
                todate = request.todate,
                createdby = "Hệ thống",
                datecreated = DateTime.Now,
                updatedby = "Hệ thống",
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
                    id = code.id,
                    code = code.code,
                    name = code.name,
                    description = code.description,
                    discount_rate = code.discount_rate,
                    amount = code.amount,
                    fromdate = code.fromdate,
                    todate = code.todate,
                    status = code.status,
                }
            };
        }

        public async Task<List<PromotionalCodeViewModel>> GetAll()
        {
            var data = await _context.PromotionCodes.Select(x => new PromotionalCodeViewModel
            {
                id = x.id,
                code = x.code,
                name = x.name,
                description = x.description,
                discount_rate = x.discount_rate,
                amount = x.amount,
                fromdate = x.fromdate,
                todate = x.todate,
                status = x.status,
            }).ToListAsync();
            return data;
        }

        public async Task<PromotionalCodeViewModel> GetByCode(string code)
        {
            var promotionalCode = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == code);
            if (promotionalCode == null)
            {
                throw new _1015Exception($"Can not find promotional code with code: {code}");
            }
            var data = new PromotionalCodeViewModel
            {
                id = promotionalCode.id,
                code = promotionalCode.code,
                name = promotionalCode.name,
                description = promotionalCode.description,
                discount_rate = promotionalCode.discount_rate,
                amount = promotionalCode.amount,
                fromdate = promotionalCode.fromdate,
                todate = promotionalCode.todate,
                status = promotionalCode.status,
            };
            return data;
        }

        public async Task<PromotionalCodeViewModel> GetById(int id)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.id == id);
            if (code == null)
            {
                throw new _1015Exception($"Can not find promotional code with id: {id}");
            }    
            var data = new PromotionalCodeViewModel
            {
                id = code.id,
                code = code.code,
                name = code.name,
                description = code.description,
                discount_rate = code.discount_rate,
                amount = code.amount,
                fromdate = code.fromdate,
                todate = code.todate,
                status = code.status,   
            }; 
            return data;
        }

        public async Task<int> DeletePromotionalCode(int id)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.id == id);
            if (code == null)
            {
                throw new _1015Exception($"Can not find promotional code with id: {id}");
            }
            code.status = PromotionalCodeStatus.InActive;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdataAmount(int id, int addedamount)
        {
            var code = await _context.PromotionCodes.FindAsync(id);
            if (code == null) throw new _1015Exception($"Cannot find a promotional code with id: {id}");
            if (code.amount + addedamount >= 1)
                code.amount += addedamount;
            else
            {
                code.amount = 0;
                code.status = PromotionalCodeStatus.OOS;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdataToDate(int id, DateTime todate)
        {
            var code = await _context.PromotionCodes.FindAsync(id);
            if (code == null) throw new _1015Exception($"Cannot find a promotional code with id: {id}");
            if (code.fromdate > todate) throw new _1015Exception($"Todate is less than Fromdate");
            else
            {
                code.todate = todate;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> UpdatePromotionalCode(PromotionalCodeUpdateRequest request)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.id == request.id);
            if (code == null)
            {
                throw new _1015Exception($"Can not find promotional code with id: {request.id}");
            }

            var promotionalCode = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == request.code);
            if (!((promotionalCode == null) || (promotionalCode != null && promotionalCode.code == code.code)))
            {
                throw new _1015Exception($"Code {request.code} is existed");
            }    

            code.name = request.name;
            code.description = request.description;
            code.code = request.code;
            code.discount_rate = request.discount_rate;
            code.amount = request.amount;
            code.fromdate = request.fromdate;
            code.todate = request.todate;

            return await _context.SaveChangesAsync();

        }

        public async Task<PromotionalCodeViewModel> CheckCode(string stringcode, Guid user_id)
        {
            var code = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == stringcode);
            if (code == null)
            {
                throw new _1015Exception($"Can not find promotional code with code: {stringcode}");
            }
            if (DateTime.Now < code.fromdate)
            {
                throw new _1015Exception("Can not use code because the release date hasn't arrived yet");
            }
            if (DateTime.Now > code.todate)
            {
                throw new _1015Exception("Can not use code because it has expired");
            }
            var codeuse = await _context.UserUsePromotionalCode.FirstOrDefaultAsync(x => x.promotionalcode_id == code.id && x.user_id == user_id);
            if (codeuse != null) 
            {
                throw new _1015Exception("Can not use code because you used it");
            }
            return new PromotionalCodeViewModel
            {
                id = code.id,
                code = code.code,
                name = code.name,
                description = code.description,
                discount_rate = code.discount_rate,
                amount = code.amount,
                fromdate = code.fromdate,
                todate = code.todate,
                status = code.status,
            };
        }
    }
}
