using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9_triangles.CustomPoint
{
    class CPoint : ICustomPoint
    {
        public double XCoord { get; set; }

        public double YCoord { get; set; }

        public CPoint(double x, double y)
        {
            XCoord = x;
            YCoord = y;
        }

        public ICustomPoint GetPointOnLine(ICustomPoint secondPoint, double scale)
        {

            double newX = _calculateCoordinate(XCoord, secondPoint.XCoord, scale);
            double newY = _calculateCoordinate(YCoord, secondPoint.YCoord, scale);

            return new CPoint(newX, newY);

        }

        private double _calculateCoordinate(double x, double y, double scale)
        {
            return x + (y - x) * scale;
        }
    }
}
