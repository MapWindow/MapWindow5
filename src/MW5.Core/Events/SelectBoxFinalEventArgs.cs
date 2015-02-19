﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Core.Events
{
    public class SelectBoxFinalEventArgs: EventArgs
    {
        private readonly _DMapEvents_SelectBoxFinalEvent _args;

        internal SelectBoxFinalEventArgs(_DMapEvents_SelectBoxFinalEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public int Bottom
        {
            get { return _args.bottom; }
        }

        public int Left
        {
            get { return _args.left; }
        }

        public int Right
        {
            get { return _args.right; }
        }

        public int Top
        {
            get { return _args.top; }
        }

        public Rectangle Bounds
        {
            // TODO: check if top / bottom is correct
            get { return new Rectangle(_args.left, _args.top, _args.right - _args.left, _args.top - _args.bottom); }
        }
    }
}
