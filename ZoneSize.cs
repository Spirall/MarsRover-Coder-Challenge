

/*
Mars’s surface can be thought of as a zone that is itself a two-dimensional grid of
square areas.*/

namespace Next24_Mars_Rover_Code_Challenge.NavigationLocation
{
    public struct ZoneSize
    {
        public int Width;
        public int Height;


        public ZoneSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

    }
}