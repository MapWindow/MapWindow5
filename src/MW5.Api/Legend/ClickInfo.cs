using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Legend.Events;

namespace MW5.Api.Legend
{
    internal class ClickInfo
    {
        private bool _doubleClickOnly;

        public event EventHandler<LayerEventArgs> LayerShowProperties;
        public event EventHandler<LayerEventArgs> LayerEditName;

        public ClickInfo()
        {
            _doubleClickOnly = false;
            ClickId = -1;
            LastLayerHandle = -1;
            IsFirstClick = true;
            IsDoubleClick = false;
            Milliseconds = 0;
            DoubleClickTimer = new Timer {Interval = 100};
            DoubleClickTimer.Tick += DoubleClickTimer_Tick;
        }

        public bool IsFirstClick { get; set; }

        public bool IsDoubleClick { get; set; }

        public Timer DoubleClickTimer { get; set; } 

        public int ClickId { get; set; }

        public int LastClickId { get; set; }

        public int LastLayerHandle { get; set; }

        public int Milliseconds { get; set; }

        public bool IsNextClick( int layerHandle)
        {
            return ClickId == LastClickId + 1 && LastLayerHandle == layerHandle;
        }

        public void StartTimer(int layerHandle, bool doubleClickOnly)
        {
            //Debug.WriteLine("Starting timer for layer: " + layerHandle + ". Double click only: " + doubleClickOnly);
            
            _doubleClickOnly = doubleClickOnly;
            DoubleClickTimer.Start();

            SetDefaults();

            IsFirstClick = false;
            LastLayerHandle = layerHandle;
            LastClickId = ClickId;
        }

        public void Abort()
        {
            DoubleClickTimer.Stop();
            SetDefaults();
            //Debug.Print("Aborting the timer.");
        }

        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            Milliseconds += 100;

            if (Milliseconds >= SystemInformation.DoubleClickTime)
            {
                DoubleClickTimer.Stop();

                if (_doubleClickOnly && !IsDoubleClick)
                {
                    //Debug.Print("Double click was timed out.");
                }
                else
                {
                    //Debug.WriteLine("Timer finnished; is double click: " + IsDoubleClick);
                    FireEvent(IsDoubleClick ? LayerShowProperties : LayerEditName, new LayerEventArgs(LastLayerHandle));
                }

                SetDefaults();
            }
        }

        private void SetDefaults()
        {
            Milliseconds = 0;
            IsFirstClick = true;
            IsDoubleClick = false;
        }

        private void FireEvent(EventHandler<LayerEventArgs> handler, LayerEventArgs args)
        {
            if (handler != null)
            {
                handler(null, args);
            }
        }
    }
}
