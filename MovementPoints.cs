
/*
● The zones have been very carefully surveyed ahead of time and are deemed safe for
exploration within the landing terrain bounds, as represented by a single cartesian
coordinate - for example: (5, 5).*/

namespace Next24_Mars_Rover_Code_Challenge.NavigationLocation
{
    public struct MovementPoints
    {
        public int X;
        public int Y;

        public MovementPoints(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}