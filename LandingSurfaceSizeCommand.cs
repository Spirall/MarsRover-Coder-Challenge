
using System.Drawing;


namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre
{
    public interface LandingSurfaceSizeCommand : Commands
    {
        Size size { get; }
        void SetReceiver(LandingSurfaceSizeCommand aLandingSurface);
    }
}