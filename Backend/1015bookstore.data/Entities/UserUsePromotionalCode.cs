namespace _1015bookstore.data.Entities
{
    public class UserUsePromotionalCode
    {
        public int promotionalcode_id {  get; set; }
        public Guid user_id { get; set; }
        public DateTime useddate { get; set; }
        public User user { get; set; }
        public PromotionalCode promotionalcode { get; set; }
    }
}
