using _1015bookstore.data.EF;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.Reviews;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Reports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.System.Reports
{
    public class ReportService : IReportService
    {
        private readonly _1015DbContext _context;

        public ReportService(_1015DbContext context)
        {
            _context = context;
        }


        public async Task<ResponseService<decimal[]>> Report_GetSoldByMonth(int month)
        {
            var data = _context.ReportDatas.Where(x => x.time.Month == month && x.status == false);
            decimal[] result = new decimal[6];
            foreach (var row in data)
            {
                if (row.time.Day >= 1 && row.time.Day <= 5)
                {
                    result[0] += row.amount * row.price;
                }
                else if (row.time.Day >= 6 && row.time.Day <= 10)
                {
                    result[1] += row.amount * row.price;
                }
                else if (row.time.Day >= 11 && row.time.Day <= 15)
                {
                    result[2] += row.amount * row.price;
                }
                else if (row.time.Day >= 16 && row.time.Day <= 20)
                {
                    result[3] += row.amount * row.price;
                }
                else if (row.time.Day >= 21 && row.time.Day <= 25)
                {
                    result[4] += row.amount * row.price;
                }
                else if (row.time.Day >= 26 && row.time.Day <= 31)
                {
                    result[5] += row.amount * row.price;
                }
            }
            return new ResponseService<decimal[]>()
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = result
            };
        }

        public async Task<ResponseService<decimal[]>> Report_GetImportByMonth(int month)
        {
            var data = _context.ReportDatas.Where(x => x.time.Month == month && x.status == true);
            decimal[] result = new decimal[6];
            foreach (var row in data)
            {
                if (row.time.Day >= 1 && row.time.Day <= 5)
                {
                    result[0] += row.amount * row.price;
                }
                else if (row.time.Day >= 6 && row.time.Day <= 10)
                {
                    result[1] += row.amount * row.price;
                }
                else if (row.time.Day >= 11 && row.time.Day <= 15)
                {
                    result[2] += row.amount * row.price;
                }
                else if (row.time.Day >= 16 && row.time.Day <= 20)
                {
                    result[3] += row.amount * row.price;
                }
                else if (row.time.Day >= 21 && row.time.Day <= 25)
                {
                    result[4] += row.amount * row.price;
                }
                else if (row.time.Day >= 26 && row.time.Day <= 31)
                {
                    result[5] += row.amount * row.price;
                }
            }
            return new ResponseService<decimal[]>()
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = result
            };
        }

        public async Task<ResponseService<decimal[]>> Report_GetImportByWeek(DateTime date)
        {
            DateTime mondayOfWeek = date.AddDays(-(int)date.DayOfWeek).AddDays(1);
            DateTime[] currentWeekDays = Enumerable.Range(0, 7).Select(day => mondayOfWeek.AddDays(day)).ToArray();

            var data = _context.ReportDatas.Where(x => x.time >= currentWeekDays[0] && x.time <= currentWeekDays[6] && x.status == true);
            decimal[] result = new decimal[7];
            foreach (var row in data)
            {
                if (row.time.Day == currentWeekDays[0].Day)
                {
                    result[0] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[1].Day)
                {
                    result[1] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[2].Day)
                {
                    result[2] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[3].Day)
                {
                    result[3] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[4].Day)
                {
                    result[4] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[5].Day)
                {
                    result[5] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[6].Day)
                {
                    result[6] += row.amount * row.price;
                }
            }
            return new ResponseService<decimal[]>()
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = result
            };
        }

        public async Task<ResponseService<decimal[]>> Report_GetSoldByWeek(DateTime date)
        {
            DateTime mondayOfWeek = date.AddDays(-(int)date.DayOfWeek).AddDays(1);
            DateTime[] currentWeekDays = Enumerable.Range(0, 7).Select(day => mondayOfWeek.AddDays(day)).ToArray();

            var data = _context.ReportDatas.Where(x => x.time >= currentWeekDays[0] && x.time <= currentWeekDays[6] && x.status == false);
            decimal[] result = new decimal[7];
            foreach (var row in data)
            {
                if (row.time.Day == currentWeekDays[0].Day)
                {
                    result[0] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[1].Day)
                {
                    result[1] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[2].Day)
                {
                    result[2] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[3].Day)
                {
                    result[3] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[4].Day)
                {
                    result[4] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[5].Day)
                {
                    result[5] += row.amount * row.price;
                }
                else if (row.time.Day == currentWeekDays[6].Day)
                {
                    result[6] += row.amount * row.price;
                }
            }
            return new ResponseService<decimal[]>()
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = result
            };
        }

        public async Task<ResponseService<List<ProductTop10>>> Report_GetTop10ProductByMonth(int month)
        {
            var top10 = await _context.ReportDatas.Where(x=>x.time.Month == month && x.status == false).GroupBy(p => p.product_id).Select(g => new { 
                product_id = g.Key, 
                total = g.Sum(p => p.amount)})
                .OrderByDescending(result => result.total)
                .Take(10)
                .ToListAsync();

            var data = new List<ProductTop10>();
            foreach(var item in top10)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.id == item.product_id);
                data.Add(new ProductTop10
                {
                    amount = item.total,
                    product_id=item.product_id,
                    product_name= product.name
                });
            }
            return new ResponseService<List<ProductTop10>>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }

        public async Task<ResponseService<List<ProductTop10>>> Report_GetTop10ProductByWeek(DateTime date)
        {
            DateTime mondayOfWeek = date.AddDays(-(int)date.DayOfWeek).AddDays(1);
            DateTime[] currentWeekDays = Enumerable.Range(0, 7).Select(day => mondayOfWeek.AddDays(day)).ToArray();
            var top10 = await _context.ReportDatas.Where(x => x.time >= currentWeekDays[0] && x.time <= currentWeekDays[6] && x.status == false).GroupBy(p => p.product_id).Select(g => new {
                product_id = g.Key,
                total = g.Sum(p => p.amount)
            })
                .OrderByDescending(result => result.total)
                .Take(10)
                .ToListAsync();

            var data = new List<ProductTop10>();
            foreach (var item in top10)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.id == item.product_id);
                data.Add(new ProductTop10
                {
                    amount = item.total,
                    product_id = item.product_id,
                    product_name = product.name
                });
            }
            return new ResponseService<List<ProductTop10>>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }
    }
}
