using MW5.Api;
using MW5.Api.Interfaces;

namespace MW5.Plugins.ShapeEditor.Operations
{
    public static class RemoveOperation
    {
        // TODO: path Layer, rather than separately handle and featureset
        public static void Remove(IMuteMap map, IFeatureSet fs, int layerHandle)
        {
            var list = map.History;
            list.BeginBatch();

            var features = fs.Features;
            for (int i = features.Count - 1; i >= 0; i--)
            {
                if (features[i].Selected)
                {
                    list.Add(UndoOperation.RemoveShape, layerHandle, i);
                    features.EditDelete(i);
                }
            }
            list.EndBatch();
        }
    }
}
