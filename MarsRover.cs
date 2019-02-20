using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Next24_Mars_Rover_Code_Challenge.NavigationLocation;

namespace Next24_Mars_Rover_Code_Challenge.The_Rover
{
    public interface MarsRover
    {
        MovementPoints Position { get; set; }
        CardinalDirection CardinalDirection { get; set; }
        void Deploy(LandingSurface aLandingSurface, MovementPoints aPoint, CardinalDirection aDirection);
        void Move(IEnumerable<Movement> movements);
    }
}