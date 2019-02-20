namespace Next24_Mars_Rover_Code_Challenge.NavigationLocation
{
    public class Plateau : LandingSurface
    {
        private ZoneSize size { get; set; }

        public void SetSize(ZoneSize aSize)
        {
            size = aSize;
        }

        public ZoneSize GetZone()
        {
            return size;
        }

        public bool IsValid(MovementPoints aPoint)
        {
            var isValidX = aPoint.X >= 0 && aPoint.X <= size.Width;
            var isValidY = aPoint.Y >= 0 && aPoint.Y <= size.Height;

            return isValidX && isValidY;
        }

        public ZoneSize GetSize()
        {
            throw new System.NotImplementedException();
        }
    }
}