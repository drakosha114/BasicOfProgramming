using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9_triangles.CustomPoint
{
    interface ICustomPoint
    {
        double XCoord { get; set; }

        double YCoord { get; set; }

        ICustomPoint GetPointOnLine(ICustomPoint secondPoint, double scale);
    }
}
