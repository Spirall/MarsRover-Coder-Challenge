using Next24_Mars_Rover_Code_Challenge.NavigationLocation;
using Next24_Mars_Rover_Code_Challenge.The_Rover;

namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre
{
    public class RoverDeployCommand
    {
        public MovementPoints DeployPoint { get; set; }
        public CardinalDirection DeployDirection { get; set; }
        private MarsRover Rover;
        private LandingSurface LandingSurface;

        public RoverDeployCommand(MovementPoints aPoint, CardinalDirection aDirection)
        {
            DeployPoint = aPoint;
            DeployDirection = aDirection;        
        }

        public CommandTypes GetCommandType()
        {
            return CommandTypes.RoverDeployCommand;
        }

        public void Execute()
        {
            Rover.Deploy(LandingSurface, DeployPoint, DeployDirection);
        }

        public void SetReceivers(MarsRover aRover, LandingSurface aLandingSurface)
        {
            Rover = aRover;
            LandingSurface = aLandingSurface;
        }

    }
}