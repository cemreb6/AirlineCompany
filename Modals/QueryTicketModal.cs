namespace AirlineCompany.Modals
{
    public class QueryTicketModal
    {
        public DateTime Date { get; set; } 
        public string from { get; set; }
        public string to { get; set; }
        public int peopleCount { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; } 
    }
}
