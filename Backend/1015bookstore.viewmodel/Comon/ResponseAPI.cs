namespace _1015bookstore.viewmodel.Comon
{

    public class ResponseAPI<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
