using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _1015bookstore.web.Repository
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly MyDbContext dbcontext;

        public UserAddressRepository(MyDbContext _dbcontext) {
            dbcontext = _dbcontext;
        }
        public UserAddressVM Add(UserAddressModel address)
        {
            if (address.is_default == true)
            {
                var ad = dbcontext.UserAddresses.Where(h => h.user_id == address.user_id);
                foreach (var item in ad)
                {
                    item.is_default = false;
                }
            }    
            var _address = new UserAddress { 
                user_id = address.user_id,
                is_default = address.is_default,
                receiver_name = address.receiver_name,
                receiver_phone = address.receiver_phone,
                city = address.city,
                district = address.district,
                sub_district = address.sub_district,
                address_detail = address.address_detail,
                coordinates_X = address.coordinates_X,
                coordinates_Y = address.coordinates_Y,
            };
            dbcontext.Add(_address);
            dbcontext.SaveChanges();
            return new UserAddressVM { 
                id = _address.id,
                user_id = _address.user_id,
                is_default = _address.is_default,
                receiver_name = _address.receiver_name,
                receiver_phone = _address.receiver_phone,
                city = _address.city,
                district = _address.district,
                sub_district = _address.sub_district,
                address_detail = _address.address_detail,
                coordinates_X = _address.coordinates_X,
                coordinates_Y = _address.coordinates_Y,

            };
        }

        public void Delete(int id)
        {
            var address = dbcontext.UserAddresses.SingleOrDefault(a => a.id == id);
            if (address != null)
            {
                dbcontext.Remove(address);
                dbcontext.SaveChanges();
            }
        }

        public List<UserAddressVM> GetAll()
        {
            var address = dbcontext.UserAddresses.Select(e => new UserAddressVM
            {
                id = e.id,
                user_id = e.user_id,
                is_default = e.is_default,
                receiver_name = e.receiver_name,
                receiver_phone = e.receiver_phone,
                city = e.city,
                district = e.district,
                sub_district = e.sub_district,
                address_detail = e.address_detail,
                coordinates_X = e.coordinates_X,
                coordinates_Y = e.coordinates_Y,
            });
            return address.ToList();
        }

        public UserAddressVM GetById(int id)
        {
            var address = dbcontext.UserAddresses.SingleOrDefault(a => a.id == id);
            if (address != null)
            {
                return new UserAddressVM {
                    id = address.id,
                    user_id = address.user_id,
                    is_default = address.is_default,
                    receiver_name = address.receiver_name,
                    receiver_phone = address.receiver_phone,
                    city = address.city,
                    district = address.district,
                    sub_district = address.sub_district,
                    address_detail = address.address_detail,
                    coordinates_X = address.coordinates_X,
                    coordinates_Y = address.coordinates_Y,
                };
            }
            return null;
        }

        public List<UserAddressVM> GetByUserId(int userId)
        {
            var address = dbcontext.UserAddresses.Where(a => a.user_id == userId);
            if (address.Count() != 0)
            {
                List <UserAddressVM> addresses = new List<UserAddressVM>();
                foreach (var i in address)
                {
                    addresses.Add(new UserAddressVM
                    {
                        id = i.id,
                        user_id = i.user_id,
                        is_default = i.is_default,
                        receiver_name = i.receiver_name,
                        receiver_phone = i.receiver_phone,
                        city = i.city,
                        district = i.district,
                        sub_district = i.sub_district,
                        address_detail = i.address_detail,
                        coordinates_X = i.coordinates_X,
                        coordinates_Y = i.coordinates_Y,
                    });
                }
                return addresses;
            }
            return null;
        }

        public void Update(int id, UserAddressModel address)
        {
            var _address = dbcontext.UserAddresses.SingleOrDefault(a => a.id == id);
            if (_address != null)
            {
                _address.user_id = address.user_id;
                _address.is_default = address.is_default;
                _address.receiver_name = address.receiver_name;
                _address.receiver_phone = address.receiver_phone;
                _address.city = address.city;
                _address.district = address.district;
                _address.sub_district = address.sub_district;
                _address.address_detail = address.address_detail;
                _address.coordinates_X = address.coordinates_X;
                _address.coordinates_Y = address.coordinates_Y;
                _address.updatedtime = DateTime.Now;
                dbcontext.SaveChanges();
            }
        }
    }
}
