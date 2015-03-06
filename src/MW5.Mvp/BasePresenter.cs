using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;

namespace MW5.Mvp
{
    /// <summary>
    /// Base presenter without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    public abstract class BasePresenter<TView> : IPresenter
         where TView : IView
    {
        protected TView View { get; private set; }

        protected BasePresenter(TView view)
        {
            View = view;
        }

        public void Run()
        {
            View.ShowView();
        }
    }

    /// <summary>
    /// Base presenter with argument without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TArg">The type of the argument.</typeparam>
    public abstract class BasePresener<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }

        protected BasePresener( TView view)
        {
            View = view;
        }

        public abstract void Run(TArg argument);
    }
    
    /// <summary>
    /// Base presenter with command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public abstract class BasePresenter<TView, TCommand> : CommandPresenter<TView, TCommand>, IPresenter
        where TCommand : struct, IConvertible
        where TView : IComplexView
    {
        protected BasePresenter(TView view)
            : base(view)
        {
        }

        public void Run()
        {
            View.ShowView();
        }
    }

    /// <summary>
    /// Base presenter with command enumeration and argument.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TArg">The type of the argument.</typeparam>
    public abstract class BasePresenter<TView, TCommand, TArg> : CommandPresenter<TView, TCommand>, IPresenter<TArg>
        where TCommand : struct, IConvertible
        where TView : IComplexView
    {
        protected BasePresenter(TView view)
            : base(view)
        {
        }

        public void Run(TArg argument)
        {
            View.ShowView();
        }
    }
}
