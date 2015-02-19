namespace MW5.Core.Interfaces
{
    public interface ICoordinate: IComWrapper
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
        double M { get; set; }
    }
}