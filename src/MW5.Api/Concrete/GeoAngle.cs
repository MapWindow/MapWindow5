using System;

namespace MW5.Api.Concrete
{
    // from here: http ://stackoverflow.com/questions/6862684/converting-from-decimal-degrees-to-degrees-minutes-seconds-tenths
    public class GeoAngle
    {
        public bool IsNegative { get; set; }
        public int Degrees { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }

        public static GeoAngle FromDouble(double angleInDegrees)
        {
            //ensure the value will fall within the primary range [-180.0..+180.0]
            while (angleInDegrees < -180.0)
                angleInDegrees += 360.0;

            while (angleInDegrees > 180.0)
                angleInDegrees -= 360.0;

            var result = new GeoAngle {IsNegative = angleInDegrees < 0};

            //switch the value to positive
            angleInDegrees = Math.Abs(angleInDegrees);

            //gets the degree
            result.Degrees = (int) Math.Floor(angleInDegrees);
            var delta = angleInDegrees - result.Degrees;

            //gets minutes and seconds
            var seconds = (int) Math.Floor(3600.0*delta);
            result.Seconds = seconds%60;
            result.Minutes = (int) Math.Floor(seconds/60.0);
            delta = delta*3600.0 - seconds;

            //gets fractions
            result.Milliseconds = (int) (1000.0*delta);

            return result;
        }

        public override string ToString()
        {
            var degrees = IsNegative
                ? -Degrees
                : Degrees;

            return string.Format(
                "{0}° {1:00}' {2:00}\"",
                degrees,
                Minutes,
                Seconds);
        }

        public string ToString(string format)
        {
            switch (format)
            {
                case "NS":
                    return string.Format(
                        "{0}° {1:00}' {2:00}\".{3:000} {4}",
                        Degrees,
                        Minutes,
                        Seconds,
                        Milliseconds,
                        IsNegative ? 'S' : 'N');

                case "WE":
                    return string.Format(
                        "{0}° {1:00}' {2:00}\".{3:000} {4}",
                        Degrees,
                        Minutes,
                        Seconds,
                        Milliseconds,
                        IsNegative ? 'W' : 'E');

                default:
                    throw new NotImplementedException();
            }
        }
    }
}