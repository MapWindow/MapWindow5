using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Mvp
{
    /// <summary>
    /// Base presenter with command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public abstract class BasePresenter<TView, TCommand> : CommandDispatcher<TView, TCommand>, IPresenter
        where TCommand : struct, IConvertible
        where TView : IComplexView
    {
        protected BasePresenter(TView view)
            : base(view)
        {
        }

        public virtual void Run(bool dialog = true)
        {
            View.ShowView(dialog);
        }
    }

    /// <summary>
    /// Base presenter with command enumeration and argument.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TArg">The type of the argument.</typeparam>
    public abstract class BasePresenter<TView, TCommand, TArg> : CommandDispatcher<TView, TCommand>, IPresenter<TArg>
        where TCommand : struct, IConvertible
        where TView : IComplexView
    {
        protected BasePresenter(TView view)
            : base(view)
        {
        }

        public abstract void Run(TArg argument, bool dialog = true);
    }
}
