using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
using _1015bookstore.viewmodel.Comon;

namespace _1015bookstore.websiteadmin.Service
{
    public interface IPromotionalCodeAPIClient
    {
        Task<ResponseAPI<List<PromotionalCodeViewModel>>> GetCode(string session);
        Task<ResponseAPI<PromotionalCodeViewModel>> GetCodeById(string session, int id);
        Task<ResponseAPI<string>> CreateCode(string session, PromotionalCodeCreateRequest request, Guid? gUser_id);
        Task<ResponseAPI<string>> UpdateCode(string session, PromotionalCodeUpdateRequest request, Guid? gUser_id);
    }
}
