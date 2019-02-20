using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Next24_Mars_Rover_Code_Challenge.NavCommandCentre;

namespace Next24_Mars_Rover_Code_Challenge.NavigationLocation
{
    public interface LandingSurface : Commands
    {
        void SetSize(ZoneSize aSize);
        ZoneSize GetSize();
        bool IsValid(MovementPoints aPoints);
    }
}