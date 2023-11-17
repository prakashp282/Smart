namespace SMArT.Models
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Object { get; set; }
        public string ErrorMessage { get; set; }
    }
}