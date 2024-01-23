using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.UserAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.System.UserAddresses
{
    public interface IUserAddressService
    {
        Task<ResponseService<List<AddressViewModel>>> Address_GetByUserId(Guid user_id);
        Task<ResponseService> Address_Create(UserAddressRequestCreate request);
        Task<ResponseService> Address_Delete(int id);
        Task<ResponseService> Address_Update(UserAddressRequestUpdate request);

        Task<ResponseService<AddressViewModel>> Address_GetById(int id);
        Task<ResponseService> Address_SetDefault(int id);
    }
}
