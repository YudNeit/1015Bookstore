using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.UserAddresses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.System.UserAddresses
{
    public class UserAddressService : IUserAddressService
    {
        private readonly _1015DbContext _context;

        public UserAddressService(_1015DbContext context)
        {
            _context = context;
        }

        public async Task<ResponseService<List<AddressViewModel>>> Address_GetByUserId(Guid user_id)
        {
            var addresses = await _context.UserAddresses.Where(a => a.user_id == user_id).Select(x => new AddressViewModel
            { 
                id = x.id,
                user_id = x.user_id,
                is_default = x.is_default,
                receiver_name = x.receiver_name,
                receiver_phone = x.receiver_phone,
                city = x.city,
                district = x.district,
                sub_district = x.sub_district,
                address_detail = x.address_detail,

            }).ToListAsync();
            return new ResponseService<List<AddressViewModel>>
            { 
                CodeStatus = 200,
                Status = true,
                Data = addresses,
                Message = $"Success"
            };
        }
        public async Task<ResponseService<AddressViewModel>> Address_GetById(int id)
        {
            var addresses = await _context.UserAddresses.FirstOrDefaultAsync(a => a.id == id);

            return new ResponseService<AddressViewModel>
            {
                CodeStatus = 200,
                Status = true,
                Data = new AddressViewModel
                {
                    id = addresses.id,
                    user_id = addresses.user_id,
                    is_default = addresses.is_default,
                    receiver_name = addresses.receiver_name,
                    receiver_phone = addresses.receiver_phone,
                    city = addresses.city,
                    district = addresses.district,
                    sub_district = addresses.sub_district,
                    address_detail = addresses.address_detail,

                },
                Message = $"Success"
            };
        }

        public async Task<ResponseService> Address_Delete(int id)
        {
            var addresses = await _context.UserAddresses.FirstOrDefaultAsync(a => a.id == id);
            _context.UserAddresses.Remove(addresses);
            await _context.SaveChangesAsync();
            return new ResponseService
            {
                CodeStatus = 200,
                Status = true,
                Message = $"Success"
            };
        }

        public async Task<ResponseService> Address_Update(UserAddressRequestUpdate request)
        {
            var addresses = await _context.UserAddresses.FirstOrDefaultAsync(a => a.id == request.id);
            if (request.is_default)
            {
                var address_default = await _context.UserAddresses.FirstOrDefaultAsync(x => x.user_id == addresses.user_id && x.is_default == true);
                address_default.is_default = false;
            }

            addresses.receiver_name = request.receiver_name;
            addresses.receiver_phone = request.receiver_phone;
            addresses.city = request.city;
            addresses.district = request.district;
            addresses.sub_district = request.sub_district;
            addresses.address_detail = request.address_detail;
            addresses.is_default = request.is_default;
                
            await _context.SaveChangesAsync();
            return new ResponseService
            {
                CodeStatus = 200,
                Status = true,
                Message = $"Success"
            };
        }

        public async Task<ResponseService> Address_Create(UserAddressRequestCreate request)
        {
            var address = new UserAddress
            {
                user_id = request.user_id,
                is_default = await _context.UserAddresses.Where(x => x.user_id == request.user_id).CountAsync() == 0 ? true : request.is_default,
                receiver_name = request.receiver_name,
                receiver_phone = request.receiver_phone,
                city = request.city,
                district = request.district,
                sub_district = request.sub_district,
                address_detail = request.address_detail,
                coordinates_X = 0,
                coordinates_Y = 0,
            };

            if (request.is_default)
            {
                var address_default = await _context.UserAddresses.FirstOrDefaultAsync(x => x.user_id == request.user_id && x.is_default == true);
                address_default.is_default = false;
            }

            await _context.UserAddresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return new ResponseService
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
            };

        }
    
        public async Task<ResponseService> Address_SetDefault(int id)
        {
            var addresses = await _context.UserAddresses.FirstOrDefaultAsync(a => a.id == id);
            
            var address_default = await _context.UserAddresses.FirstOrDefaultAsync(x => x.user_id == addresses.user_id && x.is_default == true);
            address_default.is_default = false;
            
            addresses.is_default = true;

            await _context.SaveChangesAsync();
            return new ResponseService
            {
                CodeStatus = 200,
                Status = true,
                Message = $"Success"
            };
        }
    }
}
