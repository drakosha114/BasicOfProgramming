namespace FiguresLibrary.Point
{
    class LibPoint : IPoint
    {
        public double XCoord { get; set; }

        public double YCoord { get; set; }

        public LibPoint(double XCoord, double YCoord) {
            this.XCoord = XCoord;
            this.YCoord = YCoord;
        }

    }
}
