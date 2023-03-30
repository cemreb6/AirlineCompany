using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany.Modals
{
    [Table("passengerFlight")]
    public class UserFlight
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("flight_id")]
        public int Flight_id { get; set; }
        [Column("client_id")]
        public int User_id { get; set; }
        [Column("passengerFullName")]
        public string PassengerFullName { get; set; }
    }
}
