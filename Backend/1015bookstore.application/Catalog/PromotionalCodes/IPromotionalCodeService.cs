using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
using _1015bookstore.viewmodel.Comon;

namespace _1015bookstore.application.Catalog.PromotionalCodes
{
    public interface IPromotionalCodeService
    {
        Task<ResponseService<PromotionalCodeViewModel>> CreatePromotionalCode(PromotionalCodeCreateRequest request);
        Task<List<PromotionalCodeViewModel>> GetAll();
        Task<PromotionalCodeViewModel> GetById(int id);
        Task<PromotionalCodeViewModel> GetByCode(string code);
        Task<int> DeletePromotionalCode(int id);
        Task<int> UpdatePromotionalCode(PromotionalCodeUpdateRequest request);
        Task<bool> UpdataAmount(int id, int addedamount);
        Task<bool> UpdataToDate(int id, DateTime todate);
        Task<PromotionalCodeViewModel> CheckCode(string stringcode, Guid user_id);
    } 
}
