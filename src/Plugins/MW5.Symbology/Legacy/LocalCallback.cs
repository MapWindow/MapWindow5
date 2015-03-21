using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Legacy
{
    /// <summary>
    /// Implementation of callback interface to return progress information
    /// </summary>
    //internal class Callback : MapWinGIS.ICallback
    //{
    //    public void Error(string KeyOfSender, string ErrorMsg)
    //    {
    //        return;
    //    }
    //    public void Progress(string KeyOfSender, int Percent, string Message)
    //    {
    //        if (string.IsNullOrEmpty(Message)) {
    //            //MapWinUtility.Logger.Progress(Percent, 100);
    //        }
    //        else
    //            //MapWinUtility.Logger.Progress(Message, Percent, 100);
    //            Debug.Print("{0}: {1}", Message, Percent);
    //    }
    //    public void Clear()
    //    {
    //        //MapWinUtility.Logger.Progress("", 100, 100);
    //    }
    //}

    ///// <summary>
    ///// Implementation of callback interface to return progress information
    ///// </summary>
    //internal class CallbackLocal : MapWinGIS.ICallback
    //{
    //    ProgressBar _progress = null;
    //    public CallbackLocal(ProgressBar progress)
    //    {
    //        _progress = progress;
    //    }
    //    public void Error(string KeyOfSender, string ErrorMsg)
    //    {
    //        return;
    //    }
    //    public void Progress(string KeyOfSender, int Percent, string Message)
    //    {
    //        if (!_progress.Visible)
    //        {
    //            _progress.Visible = true;
    //        }
    //        _progress.Value = Percent;
    //        Application.DoEvents();
    //        if (Percent == 100)
    //        {
    //            this.Clear();
    //        }
    //    }
    //    public void Clear()
    //    {
    //        _progress.Value = 0;
    //        _progress.Visible = false;
    //        Application.DoEvents();
    //    }
    //}
}
