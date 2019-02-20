using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Next24_Mars_Rover_Code_Challenge.NavigationLocation;
using Next24_Mars_Rover_Code_Challenge.The_Rover;

namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre
{
    public interface MarsRoverDeployCommand
    {
        MovementPoints DeployPoint { get; set; }
        void SetReceivers(MarsRover aRover, LandingSurface aLandingSurface);
    }
}