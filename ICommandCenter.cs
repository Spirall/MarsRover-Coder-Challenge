using Next24_Mars_Rover_Code_Challenge.NavCommandCentre;
using Next24_Mars_Rover_Code_Challenge.NavigationLocation;
using Next24_Mars_Rover_Code_Challenge.The_Rover;
namespace Nasa.MarsRover
{
    public interface ICommandCenter
    {
        void Execute(string commandString);
        LandingSurface GetLandingSurface();
        string GetCombinedRoverReport();
    }
}
