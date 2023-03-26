using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany.Modals
{
    [Table("flight")]
    public class Flight
    {
        public int Id { get; set; }
    }
}
