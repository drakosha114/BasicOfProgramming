using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_squares.CustomPoint
{
    interface ICustomPoint
    {
        double XCoord { get; set; }

        double YCoord { get; set; }

        ICustomPoint GetPointOnLine(ICustomPoint secondPoint, double scale);
    }
}
