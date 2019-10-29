using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace MW5.Plugins.AdvancedSnapping.ViewModels
{
    public abstract partial class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        #region Static Properties

        protected ViewModelBase()
        {
            InitializeDispatcher();
        }

        #endregion

        #region Properties
        partial void InitializeDispatcher();

        /// <summary>
        /// The UI Thread Dispatcher
        /// </summary>
        /// <remarks>You are responsible to set this property to the associated View's Dispatcher. When not set, 
        /// it will return Application.Current.Dispatcher. When integrated in non WPF application, it is mandatory
        /// to hold the UI Thread Dispatcher here.
        /// </remarks>
        /// 
        private Dispatcher m_dispatcher;

        public Dispatcher Dispatcher
        {
            get { return s_dispatcher; }
            set { s_dispatcher = value; }
        }

        /// <summary>
        /// Returns the user-friendly name of this object.
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </summary>
        public virtual string DisplayName { get; protected set; }

        private static Dispatcher s_dispatcher;
        public static Dispatcher UIDispatcher
        {
            get { return s_dispatcher; }
        }

        #endregion // DisplayName

        #region Debugging Aides

        ///// <summary>
        ///// Warns the developer if this object does not have
        ///// a public property with the specified name. This 
        ///// method does not exist in a Release build.
        ///// </summary>
        //[Conditional("DEBUG")]
        //[DebuggerStepThrough]
        //public void VerifyPropertyName(string propertyName)
        //{
        //    // Verify that the property name matches a real,  
        //    // public, instance property on this object.
        //    if (TypeDescriptor.GetProperties(this)[propertyName] == null)
        //    {
        //        string msg = "Invalid property name: " + propertyName;

        //        if (this.ThrowOnInvalidPropertyName)
        //            throw new Exception(msg);
        //        else
        //            Debug.Fail(msg);
        //    }
        //}

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Debugging Aides

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler == null) return;
            var e = new PropertyChangedEventArgs(propertyName);

            if (Dispatcher != null && !Dispatcher.CheckAccess())
                Dispatcher.BeginInvoke(handler, this, e);
            else
                handler(this, e);
        }

        #endregion // INotifyPropertyChanged Members

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

#if DEBUG
        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            //string msg = string.Format("{0} ({1}) ({2}) Finalized", GetType().Name, DisplayName, GetHashCode());
            //System.Diagnostics.Debug.WriteLine(msg);
        }
#endif

        #endregion // IDisposable Members

        partial void InitializeDispatcher()
        {
            if (System.Windows.Application.Current != null)
            {
                Dispatcher = System.Windows.Application.Current.Dispatcher;
            }
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
        }


        public void DispatcherRun(Action action)
        {
            action.Invoke();
        }

    }
}
