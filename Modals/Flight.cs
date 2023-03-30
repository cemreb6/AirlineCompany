using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany.Modals
{
    [Table("flight")]
    public class Flight
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("departure")]
        public string Departure { get; set; }

        [Column("destination")]
        public string Destination { get; set; }

        [Column("flight_no")]
        public string FlightNo { get; set; }

        [Column("price")]
        public Double Price { get; set; }

        [Column("seat_count")]
        public int SeatCount { get; set; }

        [Column("availableSeats")]
        public int AvailableSeats { get; set; }


    }
}
