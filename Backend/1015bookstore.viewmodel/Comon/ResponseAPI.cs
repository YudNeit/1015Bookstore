namespace _1015bookstore.viewmodel.Comon
{

    public class ResponseAPI<T> where T : class
    {
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
