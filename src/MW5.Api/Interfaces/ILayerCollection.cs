using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Interfaces
{
    public interface ILayerCollection<T> : IEnumerable<T> where T : ILayer
    {
        T this[int position] { get; }
        T ItemByHandle(int layerHandle);
        int Count { get; }
        IFeatureSet GetFeatureSet(int layerHandle);
        int Add(ILayerSource layerSource, bool visible = true);
        bool Move(int initialPosition, int targetPosition);
        bool MoveBottom(int initialPosition);
        bool MoveDown(int initialPosition);
        bool MoveTop(int initialPosition);
        bool MoveUp(int initialPosition);
        int AddFromDatabase(string connectionString, string layerNameOrQuery, bool visible = true);
        int AddFromFilename(string filename, FileOpenStrategy openStrategy = FileOpenStrategy.AutoDetect, bool visible = true);
        void RemoveAll();
        void Remove(int layerHandle);
        void RemoveWithoutClosing(int layerHandle);
        bool IsValidHandle(int layerHandle);
    }
}
