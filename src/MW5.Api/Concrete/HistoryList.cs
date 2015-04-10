using System;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class HistoryList: IComWrapper
    {
        private readonly UndoList _undoList;

        public HistoryList(UndoList undoList)
        {
            _undoList = undoList;
            if (undoList == null)
            {
                throw new NullReferenceException("Internal referencei is null");
            }
        }

        public object InternalObject
        {
            get { return _undoList; }
        }

        public string LastError
        {
            get { return _undoList.ErrorMsg[_undoList.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _undoList.Key; }
            set { _undoList.Key = value; }
        }

        public bool Undo(bool zoomToShape = true)
        {
            return _undoList.Undo(zoomToShape);
        }

        public bool Redo(bool zoomToShape = true)
        {
            return _undoList.Redo(zoomToShape);
        }

        public bool BeginBatch()
        {
            return _undoList.BeginBatch();
        }

        public int EndBatch()
        {
            return _undoList.EndBatch();
        }

        public bool Add(UndoOperation operationType, int layerHandle, int shapeIndex)
        {
            return _undoList.Add((tkUndoOperation)operationType, layerHandle, shapeIndex);
        }

        public void Clear()
        {
            _undoList.Clear();
        }

        public void ClearForLayer(int layerHandle)
        {
            _undoList.ClearForLayer(layerHandle);
        }

        public int UndoCount
        {
            get { return _undoList.UndoCount; }
        }

        public int RedoCount
        {
            get { return _undoList.RedoCount; }
        }

        public int TotalLength
        {
            get { return _undoList.TotalLength; }
        }
    }
}
