namespace MW5.Plugins.Services
{
    public interface IGeoprocessingService
    {
        /// <summary>
        /// Merges selected shapes
        /// </summary>
        void MergeShapes();

        /// <summary>
        /// Splits selected multipart shapes
        /// </summary>
        void ExplodeShapes();

        /// <summary>
        /// Removes selected shapes
        /// </summary>
        void RemoveShapes();

        bool BufferIsEmpty { get; }
        void CopyShapes();
        void PasteShapes();
        void CutShapes();

        void RemoveSelectedShapes(int layerHandle);
    }
}
