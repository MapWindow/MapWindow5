namespace MW5.Core.Interfaces
{
    public interface IGeometryStyle: IComWrapper
    {
        IGeometryFillStyle Fill { get; }

        IGeometryLineStyle Line { get; }

        IGeometryMarkerStyle Marker { get; }

        IGeometryVertexStyle Vertices { get; }

        bool DynamicVisibility { get; set; }
        double MaxVisibleScale { get; set; }
        double MinVisibleScale { get; set; }
        bool Visible { get; set; }

        IGeometryStyle Clone();
        void Deserialize(string newVal);
        string Serialize();

        /*
        bool DrawLine(Graphics g, float x, float y, int width, int height, bool drawVertices, int clipWidth, int clipHeight, uint backColor = 16777215);

        bool DrawPoint(Graphics g, float x, float y, int clipWidth = 0, int clipHeight = 0, uint backColor = 16777215);
        
        bool DrawRectangle(Graphics g, float x, float y, int width, int height, bool drawVertices, int clipWidth = 0, int clipHeight = 0, uint backColor = 16777215);

        bool DrawShape(Graphics g, float x, float y, Shape Shape, bool drawVertices, int clipWidth, int clipHeight, uint backColor = 16777215);
         */
    }
}