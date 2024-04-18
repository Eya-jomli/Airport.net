using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class ReservationTicket
    {
        public DateTime DateReservation { get; set; }
        public virtual int TicketFk { get; set; }
        public float Prix { get; set; }
        [ForeignKey("TicketFk")]

       
        public virtual string PassengerFk { get; set; }
        public virtual Ticket Ticket { get; set; }
        [ForeignKey("PassengerFk")]
        public virtual Passenger Passenger { get; set; }
    }
}

