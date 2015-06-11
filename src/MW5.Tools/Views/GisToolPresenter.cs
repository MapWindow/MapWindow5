// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GisToolPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The gis tool presenter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Views
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MW5.Plugins.Interfaces;
    using MW5.Plugins.Mvp;
    using MW5.Tools.Model;
    using MW5.Tools.Model.Parameters;

    #endregion

    /// <summary>
    /// The gis tool presenter.
    /// </summary>
    public class GisToolPresenter : BasePresenter<IGisToolView, GisToolBase>
    {
        #region Fields

        private readonly IAppContext _context;
        private bool _requiredInitialized;
        private bool _optionalInitialized;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GisToolPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="context">The context.</param>
        public GisToolPresenter(IGisToolView view, IAppContext context)
            : base(view)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the required parameters.
        /// </summary>
        private IEnumerable<BaseParameter> RequiredParameters
        {
            get
            {
                if (_requiredInitialized)
                {
                    throw new ApplicationException("RequiredParameters must be read only once");
                }

                var properties = Model.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    if (!typeof(BaseParameter).IsAssignableFrom(prop.PropertyType))
                    {
                        continue;
                    }

                    var param = Activator.CreateInstance(prop.PropertyType) as BaseParameter;
                    if (param != null)
                    {
                        prop.SetValue(this.Model, param);

                        var attr =
                            Attribute.GetCustomAttribute(prop, typeof(RequiredParameterAttribute)) as
                            RequiredParameterAttribute;
                        if (attr != null)
                        {
                            param.Index = attr.Index;
                            param.DisplayName = attr.DisplayName;
                        }
                    }

                    yield return param;
                }

                _requiredInitialized = true;
            }
        }

        /// <summary>
        /// Gets the required parameters.
        /// </summary>
        private IEnumerable<BaseParameter> OptionalParameters
        {
            get
            {
                if (_optionalInitialized)
                {
                    throw new ApplicationException("OptionalParameters must be read only once");
                }

                var properties = Model.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    if (!typeof(BaseParameter).IsAssignableFrom(prop.PropertyType))
                    {
                        continue;
                    }

                    var param = Activator.CreateInstance(prop.PropertyType) as BaseParameter;
                    if (param != null)
                    {
                        prop.SetValue(this.Model, param);

                        var attr =
                            Attribute.GetCustomAttribute(prop, typeof(OptionalParameterAttribute)) as
                            OptionalParameterAttribute;
                        if (attr != null)
                        {
                            param.Index = attr.Index;
                            param.DisplayName = attr.DisplayName;
                        }
                    }

                    yield return param;
                }

                _optionalInitialized = true;
            }
        }
        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The initialize.
        /// </summary>
        public override void Initialize()
        {
            var requiredParameters = this.RequiredParameters.ToList();
            var optionalParameters = this.OptionalParameters.ToList();

            InitParameters(requiredParameters);
            InitParameters(optionalParameters);

            View.GenerateControls(requiredParameters, optionalParameters);
        }

        /// <summary>
        /// The view ok clicked.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool ViewOkClicked()
        {
            // TODO: validate
            return Model.Run();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize the parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        private void InitParameters(IEnumerable<BaseParameter> parameters)
        {
            foreach (var layerParameter in parameters.OfType<LayerParameter>())
            {
                layerParameter.SetLayers(_context.Layers);
            }

            Model.Initialize(_context);
        }

        #endregion
    }
}