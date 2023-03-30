namespace AirlineCompany.Modals
{
    public class LogicResponseDTO<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
