using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Releasers;

namespace MW5.DI.Castle
{
    /// <summary>
    /// Inherits from the default ReleasePolicy; do not track our own transient objects.
    /// Only tracks components that have decommission steps
    /// registered or have pooled lifestyle.
    /// </summary>
    /// <remarks>http ://www.primordialcode.com/blog/post/castle-windsor-transient-objects-and-release-policies/</remarks>
    [Serializable]
    internal class TransientReleasePolicy : LifecycledComponentsReleasePolicy
    {
        public TransientReleasePolicy(IKernel kernel)
            : base(kernel)
        {
            
        }

        public override void Track(object instance, Burden burden)
        {
            ComponentModel model = burden.Model;

            // to modify the way Castle handles the Transient object uncomment the following lines
            if (model.LifestyleType == LifestyleType.Transient)
                return;

            base.Track(instance, burden);
        }
    }
}
