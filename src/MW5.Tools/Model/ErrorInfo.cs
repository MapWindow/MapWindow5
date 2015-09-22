using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Tools.Enums;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Holds information about invalid shape in the shapefile.
    /// </summary>
    internal class ErrorInfo
    {
        public ErrorInfo(int shapeIndex, string message)
        {
            ShapeIndex = shapeIndex;
            Message = message;
        }

        public string Message { get; private set; }

        public int ShapeIndex { get; private set; }

        public ValidationError ErrorType { get; set;}

        public ICoordinate Location { get; set; }
    }
}
