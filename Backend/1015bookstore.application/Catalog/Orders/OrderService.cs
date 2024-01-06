using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Categories;
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

        public async Task<ResponseService> Order_Buy(OrderBuyRequest request)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.id == request.iOrder_id);
            if (order == null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find order with id: {request.iOrder_id}"
                };

            order.name_reciver = request.sOrder_name_receiver;
            order.phone_reciver = request.sOrder_phone_receiver;
            order.address_reciver = request.sOrder_address_receiver;

            if (!string.IsNullOrEmpty(request.sPromotionalCode_code))
            {
                var promotionalcode = await _context.PromotionCodes.FirstOrDefaultAsync(x => x.code == request.sPromotionalCode_code);
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
                else
                {
                    return new ResponseService()
                    {
                        CodeStatus = 400,
                        Status = false,
                        Message = $"Can not find promotional code with code: {request.sPromotionalCode_code}"
                    };
                }    
            }

            order.promotionalcode = request.sPromotionalCode_code;


            order.status = OrderStatus.Success;
            order.paymentdate = DateTime.Now;
            order.completedate = DateTime.Now;
            order.deliverydate = DateTime.Now;


            var product_ids = await _context.OrderDetails.Where(x => x.order_id == request.iOrder_id).Select(x => new { x.product_id , x.quantity}).ToListAsync();

            foreach (var item in product_ids)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.id == item.product_id);
                
                //NOTE
                product.quanity -= item.quantity;
                if (product.quanity <= 0)
                {
                    product.status = ProductStatus.OOS;
                }    

                var report = new ReportData
                {
                    product_id = product.id,
                    price = product.price,
                    amount = item.quantity,
                    status = false,
                    time = DateTime.Now,
                };
                await _context.ReportDatas.AddAsync(report);

                var cart = await _context.Carts.FirstOrDefaultAsync(x => x.user_id == order.user_id && x.product_id == item.product_id);
                _context.Carts.Remove(cart);
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
                Message = $"Cannot buy with order id: {request.iOrder_id}",
            };

        }

        public async Task<ResponseService<OrderViewModel>> Order_Create(OrderCreateRequest request)
        {
            if (request.lCart_ids.Count() == 0) 
                return new ResponseService<OrderViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Can not create order when not enough cart item"
                };

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.gUser_id);
            if (user == null)
                return new ResponseService<OrderViewModel>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find user with id: {request.gUser_id}"
                };

            var order = new Order
            {
                orderdate = DateTime.Now,
                user_id = request.gUser_id,
                status = OrderStatus.InProgress,
            };
            await _context.AddAsync(order);

            await _context.SaveChangesAsync();

            foreach (var item in request.lCart_ids)
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
            order.total += 30000;
            await _context.SaveChangesAsync();
            
            var data = new OrderViewModel
            {
                iOrder_id = order.id,
                sOrder_name_receiver = order.name_reciver,
                sOrder_address_receiver = order.address_reciver,
                sOrder_phone_receiver = order.phone_reciver,
                sPromoionalCode_code = order.promotionalcode,
                vOrder_total = order.total,
                dtOrrder_dateorder = order.orderdate,
                bOrder_review = order.isreview,
                lOrder_items = _context.OrderDetails.Where(x => x.order_id == order.id).Select(x => new OrderDetailViewModel
                {
                    iProduct_id = x.product_id,
                    sProduct_name = x.product_name,
                    vProduct_price = x.price,
                    iProduct_amount = x.quantity,
                    sImage_path = x.imgpath
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

        public async Task<ResponseService<OrderViewModel>> Order_GetById(int iOrder_id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.id == iOrder_id);
            if (order == null)
                return new ResponseService<OrderViewModel>()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find order with id: {iOrder_id}"
                };
            var data = new OrderViewModel
            {
                iOrder_id = order.id,
                sOrder_name_receiver = order.name_reciver,
                sOrder_address_receiver = order.address_reciver,
                sOrder_phone_receiver = order.phone_reciver,
                sPromoionalCode_code = order.promotionalcode,
                vOrder_total = order.total,
                dtOrrder_dateorder = order.orderdate,
                bOrder_review = order.isreview,
                lOrder_items = _context.OrderDetails.Where(x => x.order_id == order.id).Select(x => new OrderDetailViewModel
                {
                    iProduct_id = x.product_id,
                    sProduct_name = x.product_name,
                    vProduct_price = x.price,
                    iProduct_amount = x.quantity,
                    sImage_path = x.imgpath
                }).ToList(),
            };
            return new ResponseService<OrderViewModel>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }

        public async Task<ResponseService<List<OrderViewModel>>> Order_HistoryOfUser(Guid user_id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == user_id);
            if (user == null)
                return new ResponseService<List<OrderViewModel>>
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find user with id: {user_id}"
                };

            var data = await _context.Orders.Where(x => x.user_id == user_id && x.status == OrderStatus.Success).Select(x => new OrderViewModel {
                iOrder_id = x.id,
                sOrder_name_receiver = x.name_reciver,
                sOrder_address_receiver = x.address_reciver,
                sOrder_phone_receiver = x.phone_reciver,
                sPromoionalCode_code = x.promotionalcode,
                vOrder_total = x.total,
                dtOrrder_dateorder = x.orderdate,
                bOrder_review = x.isreview,
                lOrder_items = _context.OrderDetails.Where(e => e.order_id == x.id).Select(e => new OrderDetailViewModel
                {
                    iProduct_id = e.product_id,
                    sProduct_name = e.product_name,
                    vProduct_price = e.price,
                    iProduct_amount = e.quantity,
                    sImage_path = e.imgpath,
                }).ToList()
            }).ToListAsync();

            return new ResponseService<List<OrderViewModel>>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }
    }
}
