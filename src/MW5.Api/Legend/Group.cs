//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source. 
//
//The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by 
//Utah State University and the Idaho National Engineering and Environmental Lab that were released as 
//public domain in March 2004.  
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//
//********************************************************************************************************

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MW5.Api.Concrete;

namespace MW5.Api.Legend
{
	/// <summary>
	/// Summary description for Group.
	/// </summary>
	public class Group
	{
		#region "Member Variables"

		private string _caption;

		/// <summary>
		/// A string that a developer can use to hold misc. information about this group
		/// </summary>
		public string Tag;
		private object _icon;
		private bool _expanded;
		private int _height;
		private LegendControl _legend;

		/// <summary>
		/// The Handle for this Group
		/// </summary>
		protected internal int _handle;

		/// <summary>
		/// The top position of this group
		/// </summary>
		protected internal int Top;

		/// <summary>
		/// List of All Layers contained within this group
		/// </summary>
		public List<LegendLayer> Layers;
		
		private Visibility _visibleState;

        private bool _stateLocked;

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Group(LegendControl leg)
		{
			//The next line MUST GO FIRST in the constructor
			_legend = leg;
			//The previous line MUST GO FIRST in the constructor

			Layers = new List<LegendLayer>();
			Expanded = true;
			VisibleState = Visibility.AllVisible;
			_handle = -1;
			Icon = null;
            _stateLocked = false;
		}

		/// <summary>
		/// Gets or sets the Text that appears in the legend for this group
		/// </summary>
		public string Text
		{
			get
			{
				return _caption;
			}
			set 
			{
				_caption = value;
				_legend.Redraw();
			}
		}

		/// <summary>
		/// Gets or sets the icon that appears next to this group in the legend.
		/// Setting this value to null(nothing) removes the icon from the legend
		/// </summary>
		public object Icon
		{
			get
			{
				return _icon;
			}
			set 
			{
				if(LegendHelper.IsSupportedPicture(value))
				{
					_icon = value;
					_legend.Redraw();
				}
				else
				{
					throw new System.Exception("LegendControl Error: Invalid Group Icon type");
				}
			}
		}

		/// <summary>
		/// Gets the number of layers within this group
		/// </summary>
		public int LayerCount
		{
			get
			{
				return Layers.Count;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public LegendLayer this[int layerPosition]
		{
			get
			{
				if(layerPosition >=0 && layerPosition < this.Layers.Count)
					return Layers[layerPosition];

				LegendHelper.LastError = "Invalid Layer Position within Group";
					return null;
			}	
		}

		/// <summary>
		/// Gets the Handle (a unique identifier) to this group
		/// </summary>
		public int Handle
		{
			get
			{
				return _handle;
			}
		}

		/// <summary>
		/// Looks up a Layer by Handle within this group
		/// </summary>
		/// <param name="Handle">Handle of the Layer to lookup</param>
		/// <returns>Layer item if successful, null (nothing) on failure</returns>
		protected internal Layer LayerByHandle(int Handle)
		{
			int count = Layers.Count;
			Layer lyr = null;
			for(int i = 0; i < count; i++)
			{
				lyr = (Layer)Layers[i];
				if (lyr.Handle == Handle)
					return lyr;
			}
			return null;
		}

		/// <summary>
		/// Gets the Layer's position (index) within a group
		/// </summary>
		/// <param name="Handle">Layer Handle</param>
		/// <returns>0-Based index of the Layer on success, -1 on failure</returns>
		protected internal int LayerPositionInGroup(int Handle)
		{
			int count = Layers.Count;
			Layer lyr = null;
			for(int i = 0; i < count; i++)
			{
				lyr = (Layer)Layers[i];
				if (lyr.Handle == Handle)
					return i;
			}
			return -1;
		}

		/// <summary>
		/// Gets the layer handle of the specified layer
		/// </summary>
		/// <param name="PositionInGroup">0 based index into list of layers</param>
		/// <returns>Layer's handle on success, -1 on failure</returns>
		public int LayerHandle(int PositionInGroup)
		{
			if(PositionInGroup >=0 && PositionInGroup < Layers.Count)
				return (Layers[PositionInGroup]).Handle;

			LegendHelper.LastError = "Invalid layer position within group";
			return -1;
		}

		/// <summary>
		/// Gets or sets whether or not the group is expanded.  This shows or hides the 
		/// layers within this group
		/// </summary>
		public bool Expanded
		{
			get
			{
				return _expanded;
			}
			set
			{
				if(value != _expanded)
				{
					_expanded = value;
					RecalcHeight();
					_legend.Redraw();
				}
			}
		}

		/// <summary>
		/// Gets the drawing height of the group
		/// </summary>
		protected internal int Height
		{
			get
			{
                RecalcHeight();
				return _height;
			}
		}

		/// <summary>
		/// Calculates the expanded height of the group
		/// </summary>
		protected internal int ExpandedHeight
		{
			get
			{
				int NumLayers = Layers.Count;
				//initialize the height to just the height of the group item
				int Retval = Constants.ITEM_HEIGHT;
				LegendLayer lyr;

				//now add all the heights of the Layers
				for(int i = 0; i < NumLayers; i++)
				{
					lyr = Layers[i];
					Retval += lyr.CalcHeight(true);
				}
				

				return Retval;
			}
		}


		/// <summary>
		/// Recalculates the Height of the Group
		/// </summary>
		protected internal void RecalcHeight()
		{
			int NumLayers = Layers.Count;
			
            //initialize the height to just the height of the group item
			_height = Constants.ITEM_HEIGHT;
			LegendLayer lyr;

			if(_expanded == true)
			{
				//now add all the heights of the Layers
				for(int i = 0; i < NumLayers; i++)
				{
					lyr = Layers[i];
					if (!lyr.HideFromLegend)
						_height += lyr.Height;
				}
			}
			else
			{
				_height = Constants.ITEM_HEIGHT;
			}
		}

		/// <summary>
		/// Gets or sets the visibility of the layers within this group.
		/// Note: When reading this property, it returns true if any layer is visible within
		/// this group
		/// </summary>
		public bool LayersVisible
		{
			get
			{
				if (VisibleState == Visibility.AllHidden)
					return false;
				else
					return true;
			}
			set
			{
				if(value == true)
					VisibleState = Visibility.AllVisible;
				else
					VisibleState = Visibility.AllHidden;
			}
		}

		/// <summary>
		/// Gets or Sets the Visibility State for this group
		/// Note: Set cannot be vsPARTIAL_VISIBLE
		/// </summary>
		protected internal Visibility VisibleState
		{
			get
			{
				return _visibleState;
			}
			set
			{
				if(value == Visibility.PartialVisible)
				{
					//not allowed
					throw new System.Exception("Invalid [Property set] value: vsPARTIAL_VISIBLE");					
				}
				
				_visibleState = value;
				UpdateLayerVisibility();
			}
		}

        /// <summary>
        /// gets or sets the locked property, which prevents the user from changing the visual state 
        /// except layer by layer
        /// </summary>
        public bool StateLocked
        {
            get
            {
                return _stateLocked;
            }
            set
            {
                _stateLocked = value;
            }
        }


		private void UpdateLayerVisibility()
		{
			int numLayers = Layers.Count;
			LegendLayer lyr = null;
		    bool visible = _visibleState == Visibility.AllVisible;

		    for(int i = 0; i < numLayers; i++)
			{
                lyr = Layers[i];
				bool oldState = _legend._map.get_LayerVisible(lyr.Handle);

				_legend._map.set_LayerVisible(lyr.Handle,visible);				

				if (oldState != visible)
				{
					bool cancel = false;
					
                    _legend.FireLayerVisibleChanged(lyr.Handle,visible, ref cancel);
					if (cancel == true)
						lyr.Visible = !(visible);
				}
			}
		}

		/// <summary>
		/// Updates the Visibility State for this group depending on the visibility of each layer within the group.
		/// </summary>
		protected internal void UpdateGroupVisibility()
		{
			int NumVisible = 0;
			int NumLayers = Layers.Count;
			Layer lyr = null;
			for(int i = 0; i < NumLayers; i++)
			{
				lyr = (Layer)Layers[i];
				if(_legend._map.get_LayerVisible(lyr.Handle) == true)
					NumVisible++;
			}

			if (NumVisible == NumLayers)
				_visibleState = Visibility.AllVisible;
			else if (NumVisible == 0)
				_visibleState = Visibility.AllHidden;
			else
				_visibleState = Visibility.PartialVisible;
		}

		/// <summary>
		/// Returns a snapshot image of this group
		/// </summary>
		/// <param name="imgWidth">Width in pixels of the returned image (height is determined by the number of layers in the group)</param>
		/// <returns>Bitmap of the group and sublayers (expanded)</returns>
		public System.Drawing.Bitmap Snapshot(int imgWidth)
		{
			Bitmap bmp = null;// = new Bitmap(imgWidth,imgHeight);
			Rectangle rect;

			System.Drawing.Graphics g;
					
			bmp = new Bitmap(imgWidth,this.ExpandedHeight);
			g = Graphics.FromImage(bmp);
			g.Clear(System.Drawing.Color.White);

			rect = new Rectangle(0,0,imgWidth,this.ExpandedHeight);

			_legend.DrawGroup(g,this,rect,true);

			return bmp;
		}

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font, int maxWidth)
        {
            return g.MeasureString(this.Text, font, maxWidth);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font)
        {
            return g.MeasureString(this.Text, font);
        }
	}
}
