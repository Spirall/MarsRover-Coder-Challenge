
using System.Collections.Generic;
using Next24_Mars_Rover_Code_Challenge.NavCommandCentre;
using Next24_Mars_Rover_Code_Challenge.The_Rover;


namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre
{
    public interface MarsRoverExploreCommand
    {
        IList<Movement> Movements { get; }
        void SetReceiver(MarsRover aRover); 
    }
}