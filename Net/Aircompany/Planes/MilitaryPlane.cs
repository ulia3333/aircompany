using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryType _type;

        public MilitaryPlane(string airplaneModel, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType airplaneType)
            : base(airplaneModel, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _type = airplaneType;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null && base.Equals(obj) && _type == plane._type;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _type.GetHashCode();
            return hashCode;
        }

        public MilitaryType GetMilitaryPlaneType()
        {
            return _type;
        }


        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + _type +
                    '}');
        }
    }
}
