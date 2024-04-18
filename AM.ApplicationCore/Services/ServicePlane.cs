using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane

    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlanes()
        {
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 365 * 10);
        }

        public IEnumerable<Passenger> GetPassengers(Plane plane)
        {
            return plane.Flights.SelectMany(p => p.Passengers);
        }

        public bool IsAvailablePlane(Flight flight, int n)
        {
          return flight.Plane.Capacity>= flight.Passengers.Count()+n;
        }

        public IEnumerable<Flight> GetFlights(int n)
        {
            return GetAll().SelectMany(p => p.Flights).OrderByDescending(p => p.FlightDate).Take(n);

        }

    }
}
