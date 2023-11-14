using _1015bookstore.web.Data.Entity;

namespace _1015bookstore.web.ViewModel
{
    public class TypedCategories_PromotionalsVM
    {
        public int category_id { get; set; }
        public int promotional_id { get; set; }
        public DateTime expirationdate { get; set; }
    }
}
