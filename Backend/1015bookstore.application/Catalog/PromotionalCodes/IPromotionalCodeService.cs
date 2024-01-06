using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
using _1015bookstore.viewmodel.Comon;

namespace _1015bookstore.application.Catalog.PromotionalCodes
{
    public interface IPromotionalCodeService
    {
        Task<ResponseService<PromotionalCodeViewModel>> PromotionalCode_Create(PromotionalCodeCreateRequest request, Guid? creator_id);
        Task<ResponseService<List<PromotionalCodeViewModel>>> PromotionalCode_GetAll();
        Task<ResponseService> PromotionalCode_Delete(int id, Guid? updater_id);
        Task<ResponseService> PromotionalCode_UpdataAmount(int id, Guid? updater_id, int addedamount);
        Task<ResponseService> PromotionalCode_UpdataToDate(int id, Guid? updater_id, DateTime todate);
        Task<ResponseService> PromotionalCode_Update(PromotionalCodeUpdateRequest request, Guid? updater_id);
        Task<ResponseService<PromotionalCodeViewModel>> PromotionalCode_CheckCode(string stringcode, Guid user_id);

        Task<ResponseService<PromotionalCodeViewModel>> PromotionalCode_GetById(int id);
    } 
}
