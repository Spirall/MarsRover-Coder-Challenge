using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Next24_Mars_Rover_Code_Challenge.NavCommandCentre;
using Next24_Mars_Rover_Code_Challenge.NavigationLocation;
using Next24_Mars_Rover_Code_Challenge.The_Rover;


namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre
{
    public class RoverExploreCommand : MarsRoverExploreCommand
    {
        public IList<Movement> Movements { get; private set; }
        private MarsRover rover;

        public RoverExploreCommand(IList<Movement> aMovements)
        {
            Movements = aMovements;
        }

        public CommandTypes GetCommandTypes()
        {
            return CommandTypes.RoverExploreCommand;
        }

        public void Excute()
        {
            rover.Move(Movements);
        }

        public void setReceiver(MarsRover aRover)
        {
            rover = aRover;
        }

        public void SetReceiver(MarsRover aRover)
        {
            throw new NotImplementedException();
        }
    }
}