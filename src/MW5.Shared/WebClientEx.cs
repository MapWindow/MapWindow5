using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Shared
{
    /// <summary>
    /// An extentsion of standard WebClient class.
    /// </summary>
    public class WebClientEx : WebClient
    {
        /// <summary>
        /// Gets or sets a value indicating whether HEAD rather than GET request must be sent.
        /// </summary>
        public bool HeadOnly { get; set; }
        
        /// <summary>
        /// Returns a <see cref="T:System.Net.WebRequest" /> object for the specified resource.
        /// </summary>
        /// <remarks>
        /// http ://stackoverflow.com/questions/153451/how-to-check-if-system-net-webclient-downloaddata-is-downloading-a-binary-file#156750
        /// </remarks>
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest req = base.GetWebRequest(address);
            if (HeadOnly && req.Method == "GET")
            {
                req.Method = "HEAD";
            }
            return req;
        }
    }
}
