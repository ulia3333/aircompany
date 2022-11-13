using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;
        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }
        public List<PassengerPlane> GetPassengersPlanes()
        {
            return Planes.OfType<PassengerPlane>().ToList();
        }
        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.OfType<MilitaryPlane>().ToList();
        }
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            List<PassengerPlane> passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((w, x) => w.GetPassengersCapacity() > x.GetPassengersCapacity() ? w : x);             
        }
        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            List<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();
            for (int i = 0; i < militaryPlanes.Count; i++)
            {
                MilitaryPlane plane = militaryPlanes[i];
                if (plane.GetPlaneType() == MilitaryType.Transport)
                {
                    transportMilitaryPlanes.Add(plane);
                }
            }
            return transportMilitaryPlanes;
        }
        public Airport SortPlanesByMaxFlightDistance()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxFlightDistance()));
        }
        public Airport SortPlanesByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxSpeed()));
        }
        public Airport SortPlanesByMaxLoadCapacity()
        {
          return new Airport(Planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }
        public IEnumerable<Plane> GetPlanes()
        {
            return Planes;
        }
        public override string ToString()
        {
            return "Airport{" + "planes=" + string.Join(", ", Planes.Select(x => x.GetModel())) + '}';
        }
    }
}
