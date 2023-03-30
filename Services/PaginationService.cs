namespace AirlineCompany.Services
{
    public class PaginationService
    {
        private const int MAX_PAGE_SIZE= 10;
        private const int MIN_PAGE_SIZE = 1;
        public int minNumber { get; set; }
        public int maxNumber { get; set; }
        public PaginationService()
        {
            this.minNumber = MIN_PAGE_SIZE;
            this.maxNumber = MAX_PAGE_SIZE;
        }

        public PaginationService(int min,int max)
        {
            this.minNumber = min < MIN_PAGE_SIZE ? MIN_PAGE_SIZE : min;
            this.maxNumber = max > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : max;
        }
    }
}
