using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Carts;
using _1015bookstore.viewmodel.Comon;
using Microsoft.EntityFrameworkCore;

namespace _1015bookstore.application.Catalog.Carts
{
    public class CartService : ICartService
    {
        private readonly _1015DbContext _context;

        public CartService(_1015DbContext context)
        {
            _context = context;
        }

        public async Task<ResponseService> DeleteProductInCart(int cart_id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.id == cart_id);
            if (cart == null)
            {
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find cart with id: {cart_id}"
                };
            }
            _context.Carts.Remove(cart);
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
                Message = $"Cannot delete a card with id: {cart_id}",
            };
        }

        public async Task<ResponseService<List<CartViewModel>>> GetCardOfUser(Guid user_id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == user_id);
            if (user == null)
                return new ResponseService<List<CartViewModel>>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find user with id: {user_id}"
                };

            var query = from c in _context.Carts
                        join p in _context.Products on c.product_id equals p.id
                        join pimg in _context.ProductImages on p.id equals pimg.product_id into ppimg
                        from pimg in ppimg.DefaultIfEmpty()
                        where c.user_id == user_id
                        select new { c, p, pimg };

            var listcart = await query.Select(x => new CartViewModel {
                cart_id = x.c.id,
                product_name = x.c.product_name,
                price = x.c.price,
                amount = x.c.quantity,
                pathimage = x.c.imgpath,
                status = x.p.status == ProductStatus.OOS ? CartStatus.OOS : x.c.status,
            }).ToListAsync();

            return new ResponseService<List<CartViewModel>> { 
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = listcart
            };
        }

        public async Task<ResponseService> SetProductInCart(ProductAdd productadd, Guid user_id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == user_id);
            if (user == null)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find user with id: {user_id}"
                };

            var product = await _context.Products.FirstOrDefaultAsync(x => x.id == productadd.product_id);
            if (product == null)
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find product with id: {productadd.product_id}"
                };

            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.product_id == productadd.product_id && x.user_id == user_id);
            if (cart != null) 
            {
                if (product.quanity < productadd.amount + cart.quantity)
                {
                    return new ResponseService
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = "Quantity is not enough to add to cart"
                    };
                }
                cart.quantity += productadd.amount;
            }
            else
            {
                if (product.quanity < productadd.amount)
                {
                    return new ResponseService
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = "Quantity is not enough to add to cart"
                    };
                }

                var imgproduct = await _context.ProductImages.FirstOrDefaultAsync(x => x.product_id == productadd.product_id);

                var newcart = new Cart
                {
                    product_id = productadd.product_id,
                    user_id = user_id,
                    product_name = product.name,
                    quantity = productadd.amount,
                    status = CartStatus.Normal,
                    price = product.price,
                    imgpath = imgproduct == null ? null : imgproduct.imagepath,
                    datecreated = DateTime.Now,
                };
                _context.Carts.Add(newcart);
            }

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
                Message = $"Cannot create a card with product id: {productadd.product_id}",
            };

        }

        public async Task<ResponseService> UpdateAmountCart(int cart_id, int amoutadd)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.id == cart_id);
            if (cart == null)
            {
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find cart with id: {cart_id}"
                };
            }
            var product = await _context.Products.FirstOrDefaultAsync(x => x.id == cart.product_id);

            if (product.quanity < cart.quantity + amoutadd)
            {
                return new ResponseService
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Quantity is not enough to add to cart"
                };
            }

            if (cart.quantity + amoutadd >= 1)
                cart.quantity += amoutadd;
            else
                _context.Carts.Remove(cart);

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
                Message = $"Cannot update amonut a card with card id: {cart_id}",
            };
        }
    }
}
