using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Orders;
using _1015bookstore.viewmodel.Comon;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.EntityFrameworkCore;


namespace _1015bookstore.application.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly _1015DbContext _context;

        public OrderService(_1015DbContext context) {
            _context = context;
        }

        public async Task<ResponseService> Buy(OrderBuyRequest request)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.id == request.order_id);
            if (order == null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find order with id: {request.order_id}"
                };

            order.name_reciver = request.name_reciver;
            order.phone_reciver = request.phone_reciver;
            order.address_reciver = request.address_reciver;

            if (request.promotionalcode != null)
            {
                var promotionalcode = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == request.promotionalcode);
                if (promotionalcode != null)
                {
                    promotionalcode.amount -= 1;
                    if (promotionalcode.amount <= 0)
                    {
                        promotionalcode.status = PromotionalCodeStatus.OOS;
                    }

                    var codeused = new UserUsePromotionalCode
                    {
                        user_id = order.user_id,
                        promotionalcode_id = promotionalcode.id,
                        useddate = DateTime.UtcNow,
                    };
                    await _context.UserUsePromotionalCode.AddAsync(codeused);

                    order.total = order.total - (promotionalcode.discount_rate * order.total / 100);
                }
                request.promotionalcode = null;
            }

            order.promotionalcode = request.promotionalcode;

            

            order.status = OrderStatus.Success;
            order.paymentdate = DateTime.Now;
            order.completedate = DateTime.Now;
            order.deliverydate = DateTime.Now;


            var product_ids = await _context.OrderDetails.Where(x => x.order_id == request.order_id).Select(x => new { x.product_id , x.quantity}).ToListAsync();

            foreach (var item in product_ids)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.id == item.product_id);
                product.quanity -= item.quantity;
                var cart = await _context.Carts.FirstOrDefaultAsync(x => x.user_id == order.user_id && x.product_id == item.product_id);
                _context.Carts.Remove(cart);
            }

            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService()
                {
                    CodeStatus = 201,
                    Status = true,
                    Message = $"Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = $"Cannot buy with order id: {request.order_id}",
            };

        }

        public async Task<ResponseService<OrderViewModel>> CreateOrder(OrderCreateRequest request)
        {
            if (request.cart_ids.Count() == 0) 
                return new ResponseService<OrderViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Can not create order when not enough cart item"
                };

            
            var order = new Order
            {
                orderdate = DateTime.Now,
                user_id = request.user_id,
                status = OrderStatus.InProgress,
            };
            await _context.AddAsync(order);

            await _context.SaveChangesAsync();

            foreach (var item in request.cart_ids)
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(x => x.id == item);
                order.total += cart.price * cart.quantity;
                var orderdetail = new OrderDetail
                {
                    order_id = order.id,
                    product_id = cart.product_id,
                    quantity = cart.quantity,
                    price = cart.price,
                    product_name = cart.product_name,
                    imgpath = cart.imgpath,
                };
                await _context.OrderDetails.AddAsync(orderdetail);
            }    

            await _context.SaveChangesAsync();
            
            var data = new OrderViewModel
            {
                id = order.id,
                name_reciver = order.name_reciver,
                address_reciver = order.address_reciver,
                phone_reciver = order.phone_reciver,
                promoionalcode = order.promotionalcode,
                total = order.total,
                orderdetails = _context.OrderDetails.Where(x => x.order_id == order.id).Select(x => new OrderDetailViewModel
                {
                    name = x.product_name,
                    price = x.price,
                    quantity = x.quantity,
                    imgpath = x.imgpath
                }).ToList(),
            };

            return new ResponseService<OrderViewModel>
            {
                CodeStatus = 201,
                Status = true,
                Message = "Success",
                Data = data
            };
        }

        public async Task<ResponseService<OrderViewModel>> GetById(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.id == id);
            if (order == null)
                return new ResponseService<OrderViewModel>()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find order with id: {id}"
                };

            var data = new OrderViewModel
            {
                id = order.id,
                name_reciver = order.name_reciver,
                address_reciver= order.address_reciver,
                phone_reciver = order.phone_reciver,
                promoionalcode = order.promotionalcode,
                total = order.total,
                orderdetails = _context.OrderDetails.Where(x => x.order_id == id).Select(x => new OrderDetailViewModel
                {
                    name = x.product_name,
                    price = x.price, 
                    quantity = x.quantity,
                    imgpath = x.imgpath
                }).ToList(),
            };

            return new ResponseService<OrderViewModel>
            {
                CodeStatus = 201,
                Status = true,
                Message = "Success",
                Data = data
            };
        }
    }
}
